using System.Runtime.InteropServices;
using System.Security.Cryptography;
using static PaintProgram.Shapes.Handle;

namespace PaintProgram.Shapes;

enum Handle { TopLeft, TopMiddle, TopRight, CenterRight, BottomRight, BottomMiddle, BottomLeft, CenterLeft }

public partial class Shape : Form
{
    protected const int Gap = 50;
    protected bool shouldShowHandles = false;
    protected Point resizeStart, moveStart;
    protected Point[] points;

    private const int HandleSize = 8;
    private bool isResizing = false, isMoving = false;
    private Rectangle[] resizeHandles;
    private Rectangle rotateHandle;
    private Handle activeHandle;
    private bool isRotating;
    private static readonly List<Shape> shapes = new();
    private double rotationDegrees;
    protected bool isAdjustingAlpha = false;

    public Shape()
    {
        DoubleBuffered = true; // Enable double buffering to reduce flickering during resizing

        InitializeComponent();
        InitializeHandles();

        Width = Height = 350;

        OnResize(default);

        BackColor       = Color.LimeGreen;
        TransparencyKey = BackColor;
        ControlBox      = false;
        ShowInTaskbar   = false;
        DisableFormShadow();
        BringToFront();
        shapes.Add(this);
    }

    // Import necessary WinAPI functions
    [DllImport("dwmapi.dll")]
    private static extern int DwmSetWindowAttribute(IntPtr hwnd, int attr, ref int attrValue, int attrSize);

    private const int DWMWA_NCRENDERING_POLICY = 2;
    private const int DWMNCRP_DISABLED = 1;

    private void DisableFormShadow()
    {
        try
        {
            // Disable shadow effect
            int value = DWMNCRP_DISABLED;
            DwmSetWindowAttribute(this.Handle, DWMWA_NCRENDERING_POLICY, ref value, sizeof(int));
            FormBorderStyle = FormBorderStyle.None;

        }
        catch (Exception ex)
        {
            // Handle any exceptions, such as when the DwmSetWindowAttribute function is not available
            Console.WriteLine("Error disabling form shadow: " + ex.Message);
        }
    }
    private void ChildForm_SizeChanged(object sender, EventArgs e)
    {
        // Check if the child form's boundaries exceed Form1's boundaries
        if (Right > Owner.Right)
        {
            // Adjust the child form's width to fit within the bounds of Form1
            Width = Owner.Width - (Left - Owner.Left);
        }
        if (Bottom > Owner.Bottom)
        {
            // Adjust the child form's height to fit within the bounds of Form1
            Height = Owner.Height - (Top - Owner.Top);
        }
    }

    protected static float Lerp(float start, float end, float t) => start + t * (end - start);
    private static Cursor GetCursorForHandle(int handleIndex) => handleIndex switch
    {
        0 or 4 => Cursors.SizeNWSE,
        1 or 5 => Cursors.SizeNS,
        2 or 6 => Cursors.SizeNESW,
        3 or 7 => Cursors.SizeWE,
        _      => Cursors.Default,
    };

    protected virtual Point[] GetPoints() => Array.Empty<Point>();

    protected virtual void DrawShape(PaintEventArgs e)
    {
        // Convert degrees to radians
        double rotationRadians = rotationDegrees * Math.PI / 180.0;

        // Calculate the new coordinates after rotation
        //int newX = (int)(originalPoint.X * Math.Cos(rotationRadians) - originalPoint.Y * Math.Sin(rotationRadians));
        //int newY = (int)(originalPoint.X * Math.Sin(rotationRadians) + originalPoint.Y * Math.Cos(rotationRadians));

        for (int i = 0; i < points.Length; i++)
        {
            Point point = points[i];
            points[i] = new ((int)(point.X + Math.Cos(rotationRadians) - point.Y * Math.Sin(rotationRadians)),
                             (int)(point.X * Math.Sin(rotationRadians) + point.Y * Math.Cos(rotationRadians)));
        }


        e.Graphics.FillPolygon(new SolidBrush(Color.FromArgb(255, 206, 226, 242)), points);
        e.Graphics.DrawPolygon(new Pen(Color.Black, 2), points);
    }
    protected override void OnPaint(PaintEventArgs e)
    {
        base.OnPaint(e);
        
        points = GetPoints();
        DrawShape(e);

        // Draw resize handles
        if (shouldShowHandles)
        {

            // Define a pen for drawing the border
            var borderPen = new Pen(Color.RebeccaPurple, 2);
            var linePen = new Pen(Color.RebeccaPurple, 2);
            
            for (int i = 0; i < resizeHandles.Length; i++)
            {
                int j = i + 1;
                if (j >= resizeHandles.Length)
                    j = 0;

                e.Graphics.DrawLine(linePen,
                    resizeHandles[i].Location.Add(new(resizeHandles[i].Width / 2, resizeHandles[i].Height / 2)), 
                    resizeHandles[j].Location.Add(new(resizeHandles[j].Width / 2, resizeHandles[j].Height / 2)));
            }

            foreach (Rectangle handleRectangle in resizeHandles)
            {
                e.Graphics.DrawRectangle(borderPen, handleRectangle);
                e.Graphics.FillRectangle(Brushes.CornflowerBlue, handleRectangle);
            }

            e.Graphics.DrawEllipse(borderPen, rotateHandle);
            e.Graphics.FillEllipse(Brushes.MediumVioletRed, rotateHandle);

            var rect = new Rectangle((resizeHandles[(int)CenterLeft].X + resizeHandles[(int)CenterRight].X) / 2, resizeHandles[(int)CenterLeft].Y, 10, 10);
            e.Graphics.FillEllipse(Brushes.Black, rect);
        }
    }
    protected override void OnMouseDown(MouseEventArgs e)
    {
        base.OnMouseDown(e);

        // Check if the mouse is within any of the resize handles
        for (int i = 0; i < resizeHandles.Length; i++)
        {
            if (!resizeHandles[i].Contains(e.Location))
                continue;

            isResizing   = true;
            resizeStart  = e.Location;
            Cursor       = GetCursorForHandle(i);
            activeHandle = (Handle)i;

            return;
        }
        if (rotateHandle.Contains(e.Location))
        {
            isRotating = true;
            moveStart = e.Location;
            return;
        }
        shapes.ForEach(s => s.HideHandles());
        isMoving = shouldShowHandles = true;
        Refresh();

        moveStart = e.Location;
    }
    protected override void OnMouseMove(MouseEventArgs e)
    {
        base.OnMouseMove(e);

        // Resize the control if the left mouse button is pressed and the cursor is over a resize handle
        if (isResizing)
        {
            int deltaX = e.X - resizeStart.X;
            int deltaY = e.Y - resizeStart.Y;

            switch (activeHandle)
            {
                case TopLeft:      ResizeControl(sizeDelta: (-deltaX, -deltaY), positionDelta: (deltaX, deltaY)); break;
                case TopMiddle:    ResizeControl(sizeDelta: (0, -deltaY),       positionDelta: (0, deltaY)); break;
                case TopRight:     ResizeControl(sizeDelta: (deltaX, -deltaY),  positionDelta: (0, deltaY), new(e.X, resizeStart.Y)); break;
                case CenterLeft:   ResizeControl(sizeDelta: (-deltaX, 0),       positionDelta: (deltaX, 0)); break;
                case CenterRight:  ResizeControl(sizeDelta: (deltaX, 0),        positionDelta: (0, 0), e.Location); break;
                case BottomLeft:   ResizeControl(sizeDelta: (-deltaX, deltaY),  positionDelta: (deltaX, 0), new(resizeStart.X, e.Y)); break;
                case BottomMiddle: ResizeControl(sizeDelta: (0, deltaY),        positionDelta: (0, 0), e.Location); break;
                case BottomRight:  ResizeControl(sizeDelta: (deltaX, deltaY),   positionDelta: (0, 0), e.Location); break;
            }
        }
        else if (isAdjustingAlpha)
        {
            AdjustAlpha(e);
        }
        else if (isMoving)
        {
            int deltaX = e.X - moveStart.X;
            int deltaY = e.Y - moveStart.Y;

            Location = new Point(Location.X + deltaX, Location.Y + deltaY);
        }
        else if (isRotating)
        {
            Point origin = new((resizeHandles[(int)CenterLeft].X + resizeHandles[(int)CenterRight].X) / 2, resizeHandles[(int)CenterLeft].Y);

            double currentRotation = GetRotation(e.Location, origin);
            double startRotation = GetRotation(moveStart, origin);

            rotationDegrees = currentRotation - startRotation;
            if (rotationDegrees < 0)
                rotationDegrees += 360;
            label1.Text = rotationDegrees.ToString();
        }
        else UpdateCursor(e);
    }
    protected void HideHandles()
    {
        shouldShowHandles = false;
        Refresh();
    }
    private double GetRotation(Point a, Point b)
    {
        int dx = a.X - b.X;
        int dy = a.Y - b.Y;

        // Calculate the rotation angle in radians
        double rotationRadians = Math.Atan2(dy, dx);

        // Convert radians to degrees
        double degrees = rotationRadians * (180 / Math.PI);

        // Ensure the angle is between 0 and 360 degrees
        if (degrees < 0)
            degrees += 360;

        return degrees;
    }

    protected virtual void AdjustAlpha(MouseEventArgs e) {  }
    protected virtual void UpdateCursor(MouseEventArgs e)
    {
        // Change cursor if the mouse is over a resize handle
        for (int i = 0; i < resizeHandles.Length; i++)
        {
            if (resizeHandles[i].Contains(e.Location))
            {
                Cursor = GetCursorForHandle(i);
                return;
            }
        }
        if (rotateHandle.Contains(e.Location))
        {
            Cursor = Cursors.Cross;
            return;
        }
        Cursor = Cursors.SizeAll;
    }
    protected override void OnMouseUp(MouseEventArgs e)
    {
        base.OnMouseUp(e);

        isResizing = isMoving = isAdjustingAlpha = false;
        Cursor = Cursors.Default;
    }
    protected override void OnResize(EventArgs e)
    {
        base.OnResize(e);

        const int gap = 45;

        // Update positions of resize handles
        resizeHandles[(int)TopLeft]     .Location = new Point(gap, gap);
        resizeHandles[(int)TopMiddle]   .Location = new Point((Width - HandleSize) / 2, gap);
        resizeHandles[(int)TopRight]    .Location = new Point( Width - HandleSize - gap, gap);
        resizeHandles[(int)CenterRight] .Location = new Point( Width - HandleSize - gap, (Height - HandleSize) / 2);
        resizeHandles[(int)BottomRight] .Location = new Point( Width - HandleSize - gap,  Height - HandleSize - gap);
        resizeHandles[(int)BottomMiddle].Location = new Point((Width - HandleSize) / 2, Height - HandleSize - gap);
        resizeHandles[(int)BottomLeft]  .Location = new Point(gap,  Height - HandleSize - gap);
        resizeHandles[(int)CenterLeft]  .Location = new Point(gap, (Height - HandleSize) / 2);
        rotateHandle.Location = resizeHandles[(int)TopMiddle].Location.Subtract(new(0, 40));

        Invalidate();
    }

    protected virtual void InitializeHandles()
    {
        resizeHandles = new Rectangle[8];
        for (int i = 0; i < 8; i++)
            resizeHandles[i] = new Rectangle(0, 0, HandleSize, HandleSize);
        rotateHandle = new Rectangle(0, 0, HandleSize, HandleSize); 
    }
    private void ResizeControl((int width, int height) sizeDelta, (int left, int top) positionDelta) => ResizeControl(sizeDelta, positionDelta, new(0, 0));
    private void ResizeControl((int width, int height) sizeDelta, (int left, int top) positionDelta, Point newResizeStart)
    {
        const int minSize = 12;

        if (Width + sizeDelta.width > minSize)
        {
            Width += sizeDelta.width;
            Left  += positionDelta.left;
        }
        if (Height + sizeDelta.height > minSize)
        {
            Height += sizeDelta.height;
            Top    += positionDelta.top;
        }

        if (newResizeStart != Point.Empty)
            resizeStart = newResizeStart;
    }

    private void Shape_MouseHover(object sender, EventArgs e)
    {
        //isHovered = true;
        //Refresh();
    }
    private void Shape_MouseLeave(object sender, EventArgs e)
    {
        //isHovered = false;
        //Refresh();
    }
    private void Shape_Load_1(object sender, EventArgs e)
    {

    }
}