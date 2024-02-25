/* Project: Paint
 * Authors: Austin Bryan, Lucius Miller, Noah Curtis
 * Class: Foundations in App Development
 * Date: February 24th, 2024*/




using PaintProgram.Shapes;
namespace PaintProgram;

public partial class ShapeEditor : Form
{
    private Shape _activeShape;
    public Shape ActiveShape
    {
        get => _activeShape;
        set
        {
            _activeShape = value;
            propertiesPanel.Visible = ActiveShape != null;

            if (value == null)
                return;
            RefreshShapeEditor();
            ShowAlphaBox(value.ShowAlphaBox);
        }
    }

    public Action<Color> OnSelectColor { get; set; }

    private bool CursorVisible
    {
        set
        {
            if (value)
                 Cursor = Cursors.Default;
            else Cursor = Form1.GetCircularCursor(20);
        }
    }
    private const int cursorDiameter = 12;

    private Point wheelCursorPoint, valueCursorPoint;
    private bool sliderMouseDown, wheelMouseDown;
    private bool linkedEnabled = false;
    private bool shouldUpdate = true;
    private float sliderValue = 1.0f;
    private Color currentColor;
    private Point moveStart;
    private bool isMoving;
    private Graphics graphics;
    private Point adjustedPoint;
    private Point cursorPointingToClient;
    private readonly Dictionary<float, Bitmap> cachedBitmaps = new();
    private readonly int sliderMin, sliderMax;
    private readonly Color unlinkedColor = Color.FromArgb(255, 120, 120, 120);
    private readonly List<PixelTextBox> alphaBoxes = new();
    private readonly ClickDragMover clickDragMover = new();

    // Prevents a flicker from occuring when being opened the first time
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
        DoubleBuffered = true;
        InitializeComponent();

        FormHider.Hide(this);

        valueSliderPictureBox.Image = GenerateValueSlider();

        wheelCursorPoint = new Point(colorWheelPictureBox.Width / 2 - cursorDiameter / 2,
                                     colorWheelPictureBox.Height / 2 - cursorDiameter / 2);
        valueCursorPoint = new Point(1, 1);
        sliderMin = 1;
        sliderMax = valueSliderPictureBox.Height - 1 - cursorDiameter;

        colorWheelPictureBox.Refresh();
        valueSliderPictureBox.Refresh();
        colorWheelPictureBox.BackColor = colorWheelBackground.BackColor;

        // Generate the bitmaps for the color wheel for every possible value.
        // This dramatically improves performance of the color wheel slider
        for (int i = 0; i < 255; i++)
        {
            sliderValue = (float)i / 255;
            colorWheelPictureBox.Image = GenerateColorWheel();
        }

        Bitmap bitmap = new(linkButton.Image, 15, 30);
        linkButton.Image = bitmap;
        linkButton.BackColor = unlinkedColor;

        alphaBoxes.Add(alpha1_PixelBox);
        alphaBoxes.Add(alpha2_PixelBox);

    }
    public void RefreshShapeEditor()
    {
        if (ActiveShape == null)
            return;
        widthPixelBox.TextBoxText = ActiveShape.Width.ToString();
        heightPixelBox.TextBoxText = ActiveShape.Height.ToString();
        xPixelBox.TextBoxText = ActiveShape.Location.X.ToString();
        yPixelBox.TextBoxText = ActiveShape.Location.Y.ToString();
        thicknessPixelBox.TextBoxText = ActiveShape.BorderThickness.ToString();

        if (ActiveShape is ParametricShape parametricShape)
        {
            UpdateAlphaBoxes();

            for (int i = 0; i < parametricShape.AlphaHandles.Count; i++)
                alphaBoxes[i].UpdateAlphaBounds(parametricShape.AlphaHandles[i]);
        }

        borderColorBtn.BackColor = ActiveShape.BorderColor;
        borderCheckBox.Checked = ActiveShape.UseBorder;
    }
    public void ShowAlphaBox(bool isVisible)
    {
        alpha1_PixelBox.Visible = isVisible;

        if (ActiveShape is ParametricShape parametricShape)
        {
            alpha2_PixelBox.Visible = parametricShape.AlphaHandles.Count > 1 && isVisible;

            if (isVisible)
                UpdateAlphaBoxes();
        }
        else alpha2_PixelBox.Visible = false;
    }

    protected override void OnShown(EventArgs e)
    {
        base.OnShown(e);
        RefreshShapeEditor();
    }
    private Bitmap GenerateValueSlider()
    {
        int length = valueSliderPictureBox.Height;
        int width = valueSliderPictureBox.Width;

        Bitmap valueSlider = new(width, length);

        for (int y = 0; y < length; y++)
        {
            double value = (double)y / (length - 1); // Calculate value from top (1.0) to bottom (0.0)

            Color color = Color.FromArgb((int)(255 * value), (int)(255 * value), (int)(255 * value));

            for (int x = 0; x < width; x++)
                valueSlider.SetPixel(x, length - 1 - y, color); // Set pixel from bottom to top
        }

        return valueSlider;
    }
    private Bitmap GenerateColorWheel()
    {
        if (cachedBitmaps.ContainsKey(sliderValue))
            return cachedBitmaps[sliderValue];

        int radius = Math.Min(colorWheelPictureBox.Width, colorWheelPictureBox.Height) / 2;
        Bitmap colorWheel = new(radius * 2, radius * 2);

        int centerX = radius;
        int centerY = radius;

        for (int y = -radius; y < radius; y++)
            for (int x = -radius; x < radius; x++)
            {
                double distance = Math.Sqrt(x * x + y * y);

                if (distance > radius)
                    continue;
                double hue = Math.Atan2(y, x) / (2 * Math.PI) + 0.5; // Normalize to range [0, 1]
                double saturation = distance / radius;               // Increase saturation as distance from center increases

                Color color = ColorFromHSV(hue, saturation, sliderValue);
                colorWheel.SetPixel(centerX + x, centerY + y, color);
            }

        cachedBitmaps.Add(sliderValue, colorWheel);

        return colorWheel;
    }
    private static Color ColorFromHSV(double hue, double saturation, double value)
    {
        int hi = Convert.ToInt32(Math.Floor(hue * 6)) % 6;
        double f = hue * 6 - Math.Floor(hue * 6);

        value *= 255;
        int v = Convert.ToInt32(value);
        int p = Convert.ToInt32(value * (1 - saturation));
        int q = Convert.ToInt32(value * (1 - f * saturation));
        int t = Convert.ToInt32(value * (1 - (1 - f) * saturation));

        return hi switch
        {
            0 => Color.FromArgb(255, v, t, p),
            1 => Color.FromArgb(255, q, v, p),
            2 => Color.FromArgb(255, p, v, t),
            3 => Color.FromArgb(255, p, q, v),
            4 => Color.FromArgb(255, t, p, v),
            _ => Color.FromArgb(255, v, p, q)
        };
    }
    private static float ClampToNearestMultiple(float value)
    {
        float scaledValue  = value * 255;                            // Scale up to range [0, 255]
        float roundedValue = (float)Math.Round((double)scaledValue); // Round to nearest integer
        float clampedValue = roundedValue / 255;                     // Scale back down to range [0, 1]

        return clampedValue;
    }

    private void DrawCursor(PaintEventArgs e, Brush brush, Point point)
    {
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
        void UpdateAlphaBox(PixelTextBox ptb, ParametricShape ps, int i) => ptb.TextBoxText = ps.AlphaHandles[i].Alpha.ToString();
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
        sliderMouseDown = true;
        valueCursorPoint = new Point(valueCursorPoint.X, Math.Clamp(e.Y, sliderMin, sliderMax));

        sliderValue = (1 - valueCursorPoint.Y / (float)(sliderMax));
        sliderValue = ClampToNearestMultiple(sliderValue);
        valueSliderPictureBox.Refresh();
        colorWheelPictureBox.Image = GenerateColorWheel();
        SelectColor();
    }
    private void UpdateWheelCursor(MouseEventArgs e)
    {
        wheelCursorPoint = e.Location.Subtract(new (cursorDiameter / 2, cursorDiameter / 2));

        int radius = colorWheelPictureBox.Width / 2 - cursorDiameter;
        var (centerX, centerY, cursorX, cursorY) = (radius, radius, wheelCursorPoint.X, wheelCursorPoint.Y);

        double distance = Math.Sqrt(Math.Pow((cursorX - centerX), 2) + Math.Pow((cursorY - centerY), 2));

        if (distance > radius)
        {
            double angle = Math.Atan2(cursorY - centerY, cursorX - centerX);

            int clampedX = centerX + (int)(radius * Math.Cos(angle) + 5);
            int clampedY = centerY + (int)(radius * Math.Sin(angle) + 5);

            wheelCursorPoint = new Point(clampedX, clampedY);
        }

        colorWheelPictureBox.Refresh();
    }
    private void SelectColor()
    {
        var colorWheelBitmap = cachedBitmaps[sliderValue];
        adjustedPoint = new(wheelCursorPoint.X + cursorDiameter / 4, wheelCursorPoint.Y + cursorDiameter / 4);

        if (adjustedPoint.X >= 0 && adjustedPoint.X < colorWheelPictureBox.Width &&
            adjustedPoint.Y >= 0 && adjustedPoint.Y < colorWheelPictureBox.Height)
        {
            currentColor = colorWheelBitmap.GetPixel(adjustedPoint.X, adjustedPoint.Y);

            if (currentColor == Color.FromArgb(0, 0, 0, 0))
                return;

            colorPreviewPictureBox.BackColor = currentColor;

            if (ActiveShape != null)
                OnSelectColor(currentColor);
        }
    }

    private void colorWheelPictureBox_MouseEnter(object sender, EventArgs e) => Cursor = Cursors.Cross;
    private void colorWheelPictureBox_MouseDown(object sender, MouseEventArgs e)
    {
        (wheelMouseDown, CursorVisible) = (true, false);
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
        (wheelMouseDown, CursorVisible) = (false, true);
        if (ActiveShape == null)
            OnSelectColor(currentColor);
    }
    private void colorWheelPictureBox_MouseLeave(object sender, EventArgs e) => Cursor = Cursors.Default;
    private void colorWheelPictureBox_Paint(object sender, PaintEventArgs e) => DrawCursor(e, Brushes.Black, wheelCursorPoint);

    private void valueSliderPictureBox_MouseEnter(object sender, EventArgs e) => Cursor = Cursors.Cross;
    private void valueSliderPictureBox_MouseDown(object sender, MouseEventArgs e)
    {
        UpdateSliderCursor(e);
        CursorVisible = false;
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
        (sliderMouseDown, CursorVisible) = (false, true);
        if (ActiveShape == null)
            OnSelectColor(currentColor);
    }
    private void valueSliderPictureBox_MouseLeave(object sender, EventArgs e) => Cursor = Cursors.Default;
    private void valueSliderPictureBox_Paint(object sender, PaintEventArgs e) => DrawCursor(e, Brushes.Black, valueCursorPoint);

    private void colorPreviewPictureBox_Paint(object sender, PaintEventArgs e)
    {
        var (width, height) = (colorPreviewPictureBox.Width, colorPreviewPictureBox.Height);

        e.Graphics.DrawRectangle(new Pen(Brushes.White, 8), 0, 0, width, height);
        e.Graphics.DrawRectangle(new Pen(Brushes.Black, 4), 0, 0, width, height);
    }

    private void linkButton_MouseClick(object sender, MouseEventArgs e)
    {
        linkedEnabled = !linkedEnabled;
        linkButton.BackColor = linkedEnabled ? Color.FromArgb(255, 45, 45, 45) : unlinkedColor;
    }
    private void bringToFrontBtn_Click(object sender, EventArgs e) => ActiveShape.MoveToFront();
    private void bringForwardBtn_Click(object sender, EventArgs e) => ActiveShape.MoveForwards();
    private void sendBackwardsBtn_Click(object sender, EventArgs e) => ActiveShape.MoveBackwards();
    private void sendToBackBtn_Click(object sender, EventArgs e) => ActiveShape.MoveToBack();

    private void widthPixelBox_InputSubmit(double parsedValue)
    {
        if (!linkedEnabled)
            ActiveShape.Width = (int)parsedValue;
        else if (shouldUpdate)
        {
            shouldUpdate = false;
            double ratio = ActiveShape.Height / (double)ActiveShape.Width;

            ActiveShape.Width = (int)parsedValue;
            ActiveShape.Height = (int)(ActiveShape.Width * ratio);

            heightPixelBox.TextBoxText = ActiveShape.Height.ToString();
        }
        else shouldUpdate = true;
    }
    private void heightPixelBox_InputSubmit(double parsedValue)
    {
        if (!linkedEnabled)
            ActiveShape.Height = (int)parsedValue;
        else if (shouldUpdate)
        {
            shouldUpdate = false;
            double ratio = ActiveShape.Width / (double)ActiveShape.Height;

            ActiveShape.Height = (int)parsedValue;
            ActiveShape.Width = (int)(ActiveShape.Height * ratio);

            widthPixelBox.TextBoxText = ActiveShape.Width.ToString();
        }
        else shouldUpdate = true;
    }
    private void xPixelBox_InputSubmit(double parsedValue) => ActiveShape.Location = new((int)parsedValue, ActiveShape.Location.Y);
    private void yPixelBox_InputSubmit(double parsedValue) => ActiveShape.Location = new(ActiveShape.Location.X, (int)parsedValue);
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
    private void colorWheelTabBackground_MouseMove(object sender, MouseEventArgs e) => Location = clickDragMover.OnMouseMove(Location, e, (Form1)Owner,true) ?? Location;
    private void colorWheelTabBackground_MouseEnter(object sender, EventArgs e) => Cursor = Cursors.SizeAll;
    private void colorWheelTabBackground_MouseLeave(object sender, EventArgs e) => Cursor = Cursors.Default;
}