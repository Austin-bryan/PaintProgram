/* Project: Paint
 * Authors: Austin Bryan, Lucius Miller, Noah Curtis
 * Class: Foundations in App Development
 * Date: February 24th, 2024
 */

using PaintProgram.Shapes;
namespace PaintProgram;

/*
 * Purpose: Allows the player to edit the shape by using a custom color wheel, and a property pane that edits some details about the shape. 
 * This was inspired by the color pickers in adobe photoshop, though they use a slightly different system. I find this color picker much more
 * intuitive, and it avoids an annoying dialog window. With an embedded color picker the user is more easily able to change the color and get
 * real time feedback. The user is able to select a shape, click the color, and drag around in the wheel in to see real time feed back on the 
 * color change. 
 */

public partial class ShapeEditor : Form
{
    // The shape currently being edited, the one the user clicked on.
    // If it is null while this is open, then the user is in brush mode
    private Shape _activeShape;
    public Shape ActiveShape
    {
        get => _activeShape;
        set
        {
            _activeShape = value;
            propertiesPanel.Visible = ActiveShape != null;  // The visibility of the properties pane is dependent on if a shape is being edited

            if (value == null)  
                return;
            // If is editing shape:
            RefreshShapeEditor();
            ShowAlphaBoxes(value.ShowAlphaBox);
        }
    }

    public Action<Color> OnSelectColor { get; set; } // This is assigned to so when called the client can access the selected color

    // This set-only property changes the cursor to a circle if dragging
    // The primary point of the circle cursor is to show when the cursor goes far out of bounds of the circular wheel.
    // Photoshop uses a similar system
    private bool IsDragging { set => Cursor = value ? Cursors.Default : MainForm.GetCircularCursor(20); }
    private const int cursorDiameter = 12;

    // The cursor positions for the wheel (which selects Hue and Saturation) and value slider (which selects value).
    // The HSV is then calculated based off both cursors
    private Point wheelCursorPoint, valueCursorPoint;
    private bool sliderMouseDown, wheelMouseDown;   // Maintains states for the mouse down
    private bool propotionanEditing = false;        // If true, height and width will be linked
    private bool shouldUpdate = true;               // This is used later to prevent in an infinite loop when the text is modified
    private float sliderValue = 1.0f;               // Slider value ranges from 0 to 1, 1 is white
    private Color currentColor;                     

    // The color is created dynamically, while its not very expensive to create, there is a lot of lag when dragging around the cursor
    // Since value ranges from 0 : 255, there are 256 possible color wheels. This caches all of them, so that once created it is stored forever
    // Adjusting the value slider then merely switches which of the colorWheels tos how
    private readonly Dictionary<float, Bitmap> cachedColorWheels = new();       
    private readonly int sliderMin = 1, sliderMax;                              // Used to clamp the value slider cursor position
    private readonly Color unlinkedColor = Color.FromArgb(255, 120, 120, 120);  // Color for the link button when its deactive
    private readonly List<PixelTextBox> alphaBoxes = new();
    private readonly ClickDragMover clickDragMover = new();

    // Prevents a flicker from occuring when Shape Editor is being opened the first time
    protected override CreateParams CreateParams
    {
        get
        {
            CreateParams cp = base.CreateParams;
            cp.ExStyle |= 0x02000000; // WS_EX_COMPOSITED
            return cp;
        }
    }

    public ShapeEditor()
    {
        DoubleBuffered = true;      // Improves rendering
        InitializeComponent();

        FormAsControlStyler.StyleFormAsControl(this);

        valueSliderPictureBox.Image = GenerateValueSlider();

        // Start the wheel cursor point to be the center
        wheelCursorPoint = new Point(colorWheelPictureBox.Width / 2 - cursorDiameter / 2,
                                     colorWheelPictureBox.Height / 2 - cursorDiameter / 2);
        // Start the slider at the top
        valueCursorPoint = new Point(1, 1);

        sliderMax = valueSliderPictureBox.Height - 1 - cursorDiameter;

        // Trigger the onpaint events
        colorWheelPictureBox.Refresh();
        valueSliderPictureBox.Refresh();
        colorWheelPictureBox.BackColor = colorWheelBackground.BackColor;

        // Generate the bitmaps for the color wheel for every possible value.
        // This dramatically improves performance of the color wheel slider. 
        // Creating them at the beginnig of the application has no noticable effect
        for (int i = 0; i < 255; i++)
        {
            sliderValue = (float)i / 255;
            colorWheelPictureBox.Image = GenerateColorWheel();
        }

        // The link texture is too big, so this properly scales it
        Bitmap bitmap = new(linkButton.Image, 15, 30);
        linkButton.Image = bitmap;
        linkButton.BackColor = unlinkedColor;

        // Alpha boxes control the alpha handles for the shapes that have them
        alphaBoxes.Add(alpha1_PixelBox);
        alphaBoxes.Add(alpha2_PixelBox);

    }
    public void RefreshShapeEditor()
    {
        // Everything that needs to be refreshed involves the Active Shape, so exit here if there isnt one
        if (ActiveShape == null)
            return;

        widthPixelBox.TextBoxText     = ActiveShape.Width.ToString();
        heightPixelBox.TextBoxText    = ActiveShape.Height.ToString();
        xPixelBox.TextBoxText         = ActiveShape.Location.X.ToString();
        yPixelBox.TextBoxText         = ActiveShape.Location.Y.ToString();
        thicknessPixelBox.TextBoxText = ActiveShape.BorderThickness.ToString();

        // Parametric shapes have one or two parameters, which require their own text boxes
        if (ActiveShape is ParametricShape parametricShape)
        {
            UpdateAlphaBoxes(); 

            for (int i = 0; i < parametricShape.AlphaHandles.Count; i++)
                alphaBoxes[i].UpdateAlphaBounds(parametricShape.AlphaHandles[i]);
        }

        // Update border information
        borderColorBtn.BackColor = ActiveShape.BorderColor;
        borderCheckBox.Checked   = ActiveShape.UseBorder;
    }
    public void ShowAlphaBoxes(bool showAlpha)
    {
        alpha1_PixelBox.Visible = showAlpha;                    // alpha1 is always shown for parametric shapes

        if (ActiveShape is ParametricShape parametricShape)     
        {
            // Show alpha2 if the shape as a second parameter
            alpha2_PixelBox.Visible = parametricShape.AlphaHandles.Count > 1 && showAlpha;

            if (showAlpha)
                UpdateAlphaBoxes();
        }
        else alpha2_PixelBox.Visible = false;
    }

    protected override void OnShown(EventArgs e)
    {
        base.OnShown(e);
        RefreshShapeEditor();
    }
    // Creates the bitmap for the value slider
    private Bitmap GenerateValueSlider()
    {
        var (length, width) = (valueSliderPictureBox.Height, valueSliderPictureBox.Width);

        Bitmap valueSlider = new(width, length);

        for (int y = 0; y < length; y++)
        {
            double value = (double)y / (length - 1); // Calculates value from top (1.0) to bottom (0.0)

            Color color = Color.FromArgb((int)(255 * value), (int)(255 * value), (int)(255 * value));

            for (int x = 0; x < width; x++)
                valueSlider.SetPixel(x, length - 1 - y, color); // Sets pixel from bottom to top
        }

        return valueSlider;
    }
    private Bitmap GenerateColorWheel()
    {
        if (cachedColorWheels.ContainsKey(sliderValue))
            return cachedColorWheels[sliderValue];

        int radius = Math.Min(colorWheelPictureBox.Width, colorWheelPictureBox.Height) / 2;
        Bitmap colorWheel = new(radius * 2, radius * 2);

        for (int y = -radius; y < radius; y++)
            for (int x = -radius; x < radius; x++)
            {
                double distance = Math.Sqrt(x * x + y * y);

                if (distance > radius)
                    continue;
                double hue = Math.Atan2(y, x) / (2 * Math.PI) + 0.5; // Normalize to range [0, 1]
                double saturation = distance / radius;               // Increase saturation as distance from center increases

                Color color = ColorFromHSV(hue, saturation, sliderValue);
                colorWheel.SetPixel(radius + x, radius + y, color);
            }

        cachedColorWheels.Add(sliderValue, colorWheel);    

        return colorWheel;
    }
    private static Color ColorFromHSV(double hue, double saturation, double value)
    {
        int sector = (int)(Math.Floor(hue * 6)) % 6;            // Each hue belongs to one of 6 color sectors
        double fractionalPart = hue * 6 - Math.Floor(hue * 6);  // Determines where the hue belongs relative to its sector

        value *= 255;
        int maxSaturation  = (int)value;                                             
        int minSaturation  = (int)(value * (1 - saturation));                        
        int midSaturation1 = (int)(value * (1 - fractionalPart * saturation));       
        int midSaturation2 = (int)(value * (1 - (1 - fractionalPart) * saturation)); 

        return sector switch
        {
            0 => Color.FromArgb(255, maxSaturation,  midSaturation2, minSaturation),            // Orange Sector
            1 => Color.FromArgb(255, midSaturation1, maxSaturation,  minSaturation),            // Yellow Sector
            2 => Color.FromArgb(255, minSaturation,  maxSaturation,  midSaturation2),           // Green Sector
            3 => Color.FromArgb(255, minSaturation,  midSaturation1, maxSaturation),            // Blue Sector
            4 => Color.FromArgb(255, midSaturation2, minSaturation,  maxSaturation),            // Deep Blue/Purple Sector
            _ => Color.FromArgb(255, maxSaturation,  minSaturation,  midSaturation1)            // Pink/Purple Sector
        };
    }
    private static float ClampToNearestMultiple(float value)
    {
        float scaledValue  = value * 255;                            // Scale up to range [0, 255]
        float roundedValue = (float)Math.Round((double)scaledValue); // Round to nearest integer
        float clampedValue = roundedValue / 255;                     // Scale back down to range [0, 1]

        return clampedValue;
    }

    private static void DrawCursor(PaintEventArgs e, Point point)
    {
        /*
         * I was wondering how to make it so the circle cursor would be black over a white image, and black of a white image. 
         * I tried doing this progamatically, but its very jarring (I used the slider value and said the cursor should be black if less than 0.25),
         * But whats worse is for a circle its much more complicated because theres many values like bright yellows and greens that will make it harder
         * to see, and it would require sampling the bitmap and comparing the hue and making judgements based of that to set it manually. 
         * 
         * I turned to photoshop, and they had a very simple and elegant solution: create two circles. A white circle, and a black circle inside
         * the white circle that has a radius of 1 pixel less. Both circles can be seen on medium grey values, but generally only one will be seen
         * at a time. This allows a smooth transition to occur automatically with no code additional code required. 
         */
        int offset = 2;
        e.Graphics.DrawEllipse(new Pen(Brushes.White, 1.6f), x: point.X, point.Y, cursorDiameter, cursorDiameter);
        e.Graphics.DrawEllipse(new Pen(Brushes.Black, 1.6f), x: point.X + offset / 2, point.Y + offset / 2, cursorDiameter - offset, cursorDiameter - offset);
    }
    private void UpdateAlphaBoxes()
    {
        if (ActiveShape is ParametricShape parametricShape)
            for (int i = 0; i < parametricShape.AlphaHandles.Count; i++)
                UpdateAlphaBox(alphaBoxes[i], parametricShape, i);
        return;

        // ---- Local Functions ---- //
        static void UpdateAlphaBox(PixelTextBox ptb, ParametricShape ps, int i) => ptb.TextBoxText = ps.AlphaHandles[i].Alpha.ToString();
    }
    private void UpdateAlpha(int index, double parsedValue)
    {
        if (ActiveShape is ParametricShape ps)
        {
            ps.SetAlpha(index, (float)parsedValue);
            ActiveShape.Refresh();
        }
    }
    private void UpdateSliderCursor(MouseEventArgs e)
    {
        valueCursorPoint = new Point(valueCursorPoint.X, Math.Clamp(e.Y, sliderMin, sliderMax));

        sliderValue = (1 - valueCursorPoint.Y / (float)(sliderMax));
        sliderValue = ClampToNearestMultiple(sliderValue);  // Makes it a multiple of 1/255 to use the cached bitmaps
        valueSliderPictureBox.Refresh();                    // Force repaint
        colorWheelPictureBox.Image = GenerateColorWheel();  
        SelectColor();
    }
    private void UpdateWheelCursor(MouseEventArgs e)
    {
        // wheelCursorPoint needs an offset from e.Location to account for the radius of the cursor
        wheelCursorPoint = e.Location.Subtract(new (cursorDiameter / 2, cursorDiameter / 2));

        int radius = colorWheelPictureBox.Width / 2 - cursorDiameter;
        var (centerX, centerY, cursorX, cursorY) = (radius, radius, wheelCursorPoint.X, wheelCursorPoint.Y);

        double distance = Math.Sqrt(Math.Pow((cursorX - centerX), 2) + Math.Pow((cursorY - centerY), 2));

        if (distance > radius)
        {
            // Clamp the distance so that where ever the user moves, the cursor will always be within the circle
            double angle = Math.Atan2(cursorY - centerY, cursorX - centerX);

            int clampedX = centerX + (int)(radius * Math.Cos(angle) + 5);
            int clampedY = centerY + (int)(radius * Math.Sin(angle) + 5);

            wheelCursorPoint = new Point(clampedX, clampedY);
        }

        colorWheelPictureBox.Refresh();
    }
    private void SelectColor()
    {
        var currentColorWheel = cachedColorWheels[sliderValue];
        Point adjustedPoint = new(wheelCursorPoint.X + cursorDiameter / 4, wheelCursorPoint.Y + cursorDiameter / 4);

        // Ensures that the sampled point wont be outside the bounds of the picture box
        if (adjustedPoint.X >= 0 && adjustedPoint.X < colorWheelPictureBox.Width &&
            adjustedPoint.Y >= 0 && adjustedPoint.Y < colorWheelPictureBox.Height)
        {
            currentColor = currentColorWheel.GetPixel(adjustedPoint.X, adjustedPoint.Y);

            if (currentColor == Color.FromArgb(0, 0, 0, 0)) // Ignore transparent colors
                return;

            colorPreviewPictureBox.BackColor = currentColor;

            if (ActiveShape != null)
                OnSelectColor(currentColor);
        }
    }

    private void colorWheelPictureBox_MouseEnter(object sender, EventArgs e) => Cursor = Cursors.Cross;
    private void colorWheelPictureBox_MouseDown(object sender, MouseEventArgs e)
    {
        (wheelMouseDown, IsDragging) = (true, false);
        UpdateWheelCursor(e);
        SelectColor();
    }
    private void colorWheelPictureBox_MouseMove(object sender, MouseEventArgs e)
    {
        if (!wheelMouseDown)
            return;

        SelectColor();
        UpdateWheelCursor(e);
    }
    private void colorWheelPictureBox_MouseUp(object sender, MouseEventArgs e)
    {
        (wheelMouseDown, IsDragging) = (false, true);
        if (ActiveShape == null)
            OnSelectColor(currentColor);
    }
    private void colorWheelPictureBox_MouseLeave(object sender, EventArgs e) => Cursor = Cursors.Default;
    private void colorWheelPictureBox_Paint(object sender, PaintEventArgs e) => DrawCursor(e, wheelCursorPoint);

    private void valueSliderPictureBox_MouseEnter(object sender, EventArgs e) => Cursor = Cursors.Cross;
    private void valueSliderPictureBox_MouseDown(object sender, MouseEventArgs e)
    {
        sliderMouseDown = true;
        UpdateSliderCursor(e);
        IsDragging = false;
    }
    private void valueSliderPictureBox_MouseMove(object sender, MouseEventArgs e)
    {
        if (!sliderMouseDown)
            return;
        SelectColor();
        UpdateSliderCursor(e);
    }
    private void valueSliderPictureBox_MouseUp(object sender, MouseEventArgs e)
    {
        (sliderMouseDown, IsDragging) = (false, true);
        if (ActiveShape == null)
            OnSelectColor(currentColor);
    }
    private void valueSliderPictureBox_MouseLeave(object sender, EventArgs e) => Cursor = Cursors.Default;
    private void valueSliderPictureBox_Paint(object sender, PaintEventArgs e) => DrawCursor(e, valueCursorPoint);

    private void colorPreviewPictureBox_Paint(object sender, PaintEventArgs e)
    {
        var (width, height) = (colorPreviewPictureBox.Width, colorPreviewPictureBox.Height);

        // Draws the borders of the picture box. Two borders are used so always one is always visible
        e.Graphics.DrawRectangle(new Pen(Brushes.White, 8), 0, 0, width, height);
        e.Graphics.DrawRectangle(new Pen(Brushes.Black, 4), 0, 0, width, height);
    }

    private void linkButton_MouseClick(object sender, MouseEventArgs e)
    {
        propotionanEditing = !propotionanEditing;
        linkButton.BackColor = propotionanEditing ? Color.FromArgb(255, 45, 45, 45) : unlinkedColor;
    }
    private void bringToFrontBtn_Click  (object sender, EventArgs e) => ActiveShape.MoveToFront();
    private void bringForwardBtn_Click  (object sender, EventArgs e) => ActiveShape.MoveForwards();
    private void sendBackwardsBtn_Click (object sender, EventArgs e) => ActiveShape.MoveBackwards();
    private void sendToBackBtn_Click    (object sender, EventArgs e) => ActiveShape.MoveToBack();

    private void widthPixelBox_InputSubmit(double parsedValue)
    {
        if (!propotionanEditing)
            ActiveShape.Width = (int)parsedValue;
        else if (shouldUpdate)  // Prevents an infinite loop
        {
            shouldUpdate = false;
            double ratio = ActiveShape.Height / (double)ActiveShape.Width;

            ActiveShape.Width  = (int)parsedValue;
            ActiveShape.Height = (int)(ActiveShape.Width * ratio);

            heightPixelBox.TextBoxText = ActiveShape.Height.ToString();
        }
        else shouldUpdate = true;
    }
    private void heightPixelBox_InputSubmit(double parsedValue)
    {
        if (!propotionanEditing)
            ActiveShape.Height = (int)parsedValue;
        else if (shouldUpdate)  // Prevents an infinite loop
        {
            shouldUpdate = false;
            double ratio = ActiveShape.Width / (double)ActiveShape.Height;

            ActiveShape.Height = (int)parsedValue;
            ActiveShape.Width  = (int)(ActiveShape.Height * ratio);

            widthPixelBox.TextBoxText = ActiveShape.Width.ToString();
        }
        else shouldUpdate = true;
    }
    private void xPixelBox_InputSubmit(double parsedValue)         => ActiveShape.Location = new((int)parsedValue, ActiveShape.Location.Y);
    private void yPixelBox_InputSubmit(double parsedValue)         => ActiveShape.Location = new(ActiveShape.Location.X, (int)parsedValue);
    private void thicknessPixelBox_InputSubmit(double parsedValue) => ActiveShape.BorderThickness = (int)parsedValue;

    private void alpha1_PixelBox_InputSubmit(double parsedValue) => UpdateAlpha(0, parsedValue);
    private void alpha2_PixelBox_InputSubmit(double parsedValue) => UpdateAlpha(1, parsedValue);
    private void borderColorBtn_Click(object sender, EventArgs e)
    {
        ColorDialog colorDialog = new() { Color = borderColorBtn.BackColor };

        if (colorDialog.ShowDialog() == DialogResult.OK)
            borderColorBtn.BackColor = ActiveShape.BorderColor = colorDialog.Color;
    }
    private void borderCheckBox_CheckedChanged(object sender, EventArgs e) => ActiveShape.UseBorder = borderCheckBox.Checked;
    private void hideButton_Click(object sender, EventArgs e) => Hide();

    private void colorWheelTabBackground_MouseDown(object sender, MouseEventArgs e) => clickDragMover.OnMouseDown(e);
    private void colorWheelTabBackground_MouseUp(object sender, MouseEventArgs e) => clickDragMover.OnMouseUp(e);
    private void colorWheelTabBackground_MouseMove(object sender, MouseEventArgs e) => Location = clickDragMover.OnMouseMove(Location, e, (MainForm)Owner,true) ?? Location;
    private void colorWheelTabBackground_MouseEnter(object sender, EventArgs e) => Cursor = Cursors.SizeAll;
    private void colorWheelTabBackground_MouseLeave(object sender, EventArgs e) => Cursor = Cursors.Default;
}