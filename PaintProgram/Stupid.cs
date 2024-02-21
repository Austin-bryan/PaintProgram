using PaintProgram.Shapes;

namespace PaintProgram;

public partial class Stupid : Form
{
    private Shape _activeShape;
    public Shape ActiveShape
    {
        get => _activeShape;
        set
        {
            _activeShape = value;
            RefreshPixelBoxes();
            ShowAlphaBox(value.ShowAlphaBox);
        }
    }

    private const int cursorDiameter = 12;
    
    private Point wheelCursorPoint, valueCursorPoint;
    private bool sliderMouseDown, wheelMouseDown;
    private bool linkedEnabled = false;
    private bool shouldUpdate = true;
    private float sliderValue = 1.0f;
    private readonly Dictionary<float, Bitmap> cachedBitmaps = new();
    private readonly int sliderMin, sliderMax;
    private readonly int diameter = 200;
    private readonly Color unlinkedColor = Color.FromArgb(255, 110, 110, 110);
    
    private int Radius => diameter / 2;

    private static bool CursorVisible
    {
        set
        {
            if (value)
                Cursor.Show();
            else Cursor.Hide();
        }
    }

    public Stupid()
    {
        InitializeComponent();

        BackColor = Color.LimeGreen;
        TransparencyKey = BackColor;
        ShowInTaskbar = false;
        FormBorderStyle = FormBorderStyle.None;

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
        // This dramatically improves preformance of the color wheel slider
        for (int i = 0; i < 255; i++)
        {
            sliderValue = (float)i / 255;
            colorWheelPictureBox.Image = GenerateColorWheel();
        }

        Bitmap bitmap = new(linkButton.Image, 15, 30);
        linkButton.Image = bitmap;
        linkButton.BackColor = unlinkedColor;
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

        int radius = colorWheelPictureBox.Height / 2;
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

        if (hi == 0)
            return Color.FromArgb(255, v, t, p);
        else if (hi == 1)
            return Color.FromArgb(255, q, v, p);
        else if (hi == 2)
            return Color.FromArgb(255, p, v, t);
        else if (hi == 3)
            return Color.FromArgb(255, p, q, v);
        else if (hi == 4)
            return Color.FromArgb(255, t, p, v);
        else return Color.FromArgb(255, v, p, q);
    }

    private void colorWheelPictureBox_Paint(object sender, PaintEventArgs e) => DrawCursor(e, Brushes.Black, wheelCursorPoint);
    private void valueSliderPictureBox_Paint(object sender, PaintEventArgs e) => DrawCursor(e, Brushes.Black, valueCursorPoint);

    private void DrawCursor(PaintEventArgs e, Brush brush, Point point)
    {
        int offset = 2;
        e.Graphics.DrawEllipse(new Pen(Brushes.White, 1.6f), x: point.X, point.Y, cursorDiameter, cursorDiameter);
        e.Graphics.DrawEllipse(new Pen(Brushes.Black, 1.6f), x: point.X + offset / 2, point.Y + offset / 2, cursorDiameter - offset, cursorDiameter - offset);
    }

    private void colorWheelPictureBox_MouseEnter  (object sender, EventArgs e) => Cursor = Cursors.Cross;
    private void colorWheelPictureBox_MouseLeave  (object sender, EventArgs e) => Cursor = Cursors.Default;
    private void valueSliderPictureBox_MouseEnter (object sender, EventArgs e) => Cursor = Cursors.Cross;
    private void valueSliderPictureBox_MouseLeave (object sender, EventArgs e) => Cursor = Cursors.Default;
    private void valueSliderPictureBox_MouseUp    (object sender, MouseEventArgs e) => (sliderMouseDown, CursorVisible) = (false, true);

    private static float ClampToNearestMultiple(float value)
    {
        float scaledValue = value * 255;                            // Scale up to range [0, 255]
        float roundedValue = (float)Math.Round((double)scaledValue); // Round to nearest integer
        float clampedValue = roundedValue / 255;                     // Scale back down to range [0, 1]

        return clampedValue;
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
    private void valueSliderPictureBox_MouseDown(object sender, MouseEventArgs e)
    {
        UpdateSliderCursor(e);
        CursorVisible = false;
    }
    private void valueSliderPictureBox_MouseMove(object sender, MouseEventArgs e)
    {
        if (!sliderMouseDown)
            return;
        UpdateSliderCursor(e);
    }
    private void colorWheelPictureBox_MouseDown(object sender, MouseEventArgs e)
    {
        (wheelMouseDown, CursorVisible) = (true, false);
        SelectColor();
        UpdateWheelCursor(e);
    }

    private void UpdateWheelCursor(MouseEventArgs e)
    {
        wheelCursorPoint = new Point(e.Location.X - cursorDiameter / 2, e.Location.Y - cursorDiameter / 2);

        int radius = 200 / 2;
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
        const int cursorOffset = 17;
        var colorWheelBitmap = cachedBitmaps[sliderValue];
        Point adjustedPoint = new(wheelCursorPoint.X + Location.X + cursorOffset, wheelCursorPoint.Y + Location.Y + cursorOffset);
        Point cursorPosition = colorWheelPictureBox.PointToClient(adjustedPoint);

        if (cursorPosition.X >= 0 && cursorPosition.X < colorWheelPictureBox.Width &&
            cursorPosition.Y >= 0 && cursorPosition.Y < colorWheelPictureBox.Height)
        {
            Color currentColor = colorWheelBitmap.GetPixel(cursorPosition.X, cursorPosition.Y);

            if (currentColor == Color.FromArgb(0, 0, 0, 0))
                return;
            colorPreviewPictureBox.BackColor = currentColor;

            ActiveShape.ShapeColor = currentColor;
        }
    }

    private void colorWheelPictureBox_MouseMove(object sender, MouseEventArgs e)
    {
        if (!wheelMouseDown)
            return;

        SelectColor();
        UpdateWheelCursor(e);
    }
    private void colorPreviewPictureBox_Paint(object sender, PaintEventArgs e)
    {
        var (width, height) = (colorPreviewPictureBox.Width, colorPreviewPictureBox.Height);

        e.Graphics.DrawRectangle(new Pen(Brushes.White, 8), 0, 0, width, height);
        e.Graphics.DrawRectangle(new Pen(Brushes.Black, 4), 0, 0, width, height);
    }
    private void colorWheelPictureBox_MouseUp(object sender, MouseEventArgs e) => (wheelMouseDown, CursorVisible) = (false, true);

    private void linkButton_MouseClick(object sender, MouseEventArgs e)
    {
        linkedEnabled = !linkedEnabled;
        linkButton.BackColor = linkedEnabled ? Color.FromArgb(255, 45, 45, 45) : unlinkedColor;
    }

    private void bringToFrontBtn_Click  (object sender, EventArgs e) => ActiveShape.MoveToFront();
    private void bringForwardBtn_Click  (object sender, EventArgs e) => ActiveShape.MoveForwards();
    private void sendBackwardsBtn_Click (object sender, EventArgs e) => ActiveShape.MoveBackwards();
    private void sendToBackBtn_Click    (object sender, EventArgs e) => ActiveShape.MoveToBack();

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

    protected override void OnShown(EventArgs e)
    {
        base.OnShown(e);
        RefreshPixelBoxes();
    }

    public void RefreshPixelBoxes()
    {
        widthPixelBox.TextBoxText     = ActiveShape.Width.ToString();
        heightPixelBox.TextBoxText    = ActiveShape.Height.ToString();
        xPixelBox.TextBoxText         = ActiveShape.Location.X.ToString();
        yPixelBox.TextBoxText         = ActiveShape.Location.Y.ToString();
        thicknessPixelBox.TextBoxText = ActiveShape.BorderThickness.ToString();

        if (ActiveShape is ParametetricShape parametetricShape)
            alphaPixelBox.TextBoxText = parametetricShape.Alpha.ToString();
        borderColorBtn.BackColor = ActiveShape.BorderColor;
    }

    private void borderColorBtn_Click(object sender, EventArgs e)
    {
        ColorDialog colorDialog = new() { Color = borderColorBtn.BackColor };

        if (colorDialog.ShowDialog() == DialogResult.OK)
            borderColorBtn.BackColor = ActiveShape.BorderColor = colorDialog.Color;
    }
    public void ShowAlphaBox(bool isVisible)
    {
        alphaPixelBox.Visible = isVisible;

        if (isVisible)
            alphaPixelBox.TextBoxText = ((ParametetricShape)ActiveShape).Alpha.ToString();
    }

    private void alphaPixelBox_InputSubmit(double parsedValue)
    {
        ((ParametetricShape)ActiveShape).Alpha = (float)parsedValue;
        ActiveShape.Refresh();
    }
}