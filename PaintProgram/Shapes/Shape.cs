using System.Runtime.InteropServices;
using System.Security.Cryptography;
using static PaintProgram.Shapes.Handle;

namespace PaintProgram.Shapes;

enum Handle { TopLeft, TopMiddle, TopRight, CenterRight, BottomRight, BottomMiddle, BottomLeft, CenterLeft }

public partial class Shape : Form
{
    protected const int Gap = 5;
    protected bool shouldShowHandles = false;
    protected Point resizeStart, moveStart;
    protected Point[] points;

    private const int HandleSize = 8;
    private bool isResizing = false, isMoving = false;
    private Rectangle[] resizeHandles;
    private Handle activeHandle;
    private static readonly List<Shape> shapes = new();
    protected bool isAdjustingAlpha = false;

    public Shape()
    {
        DoubleBuffered = true; // Enable double buffering to reduce flickering during resizing

        InitializeComponent();
        InitializeResizeHandles();

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

    protected virtual void DrawShape(PaintEventArgs e, ref Point[] points)
    {
        e.Graphics.FillPolygon(Brushes.MediumBlue, points);
    }
    protected override void OnPaint(PaintEventArgs e)
    {
        base.OnPaint(e);
        
        points = GetPoints();
        DrawShape(e, ref points);

        // Draw resize handles
        if (shouldShowHandles)
        {
            // Define a pen for drawing the border
            var borderPen = new Pen(Color.Black, 2);

            // Draw the border of each rectangle
            foreach (Rectangle handle in resizeHandles)
                e.Graphics.DrawRectangle(borderPen, handle);

            foreach (Rectangle handle in resizeHandles)
                e.Graphics.FillRectangle(Brushes.White, handle);
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
        else UpdateCursor(e);
    }
    protected void HideHandles()
    {
        shouldShowHandles = false;
        Refresh();
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

        const int gap = 2;

        // Update positions of resize handles
        resizeHandles[(int)TopLeft]     .Location = new Point(gap, gap);
        resizeHandles[(int)TopMiddle]   .Location = new Point((Width - HandleSize - gap) / 2, gap);
        resizeHandles[(int)TopRight]    .Location = new Point( Width - HandleSize - gap, gap);
        resizeHandles[(int)CenterRight] .Location = new Point( Width - HandleSize - gap, (Height - HandleSize - gap) / 2);
        resizeHandles[(int)BottomRight] .Location = new Point( Width - HandleSize - gap,  Height - HandleSize - gap);
        resizeHandles[(int)BottomMiddle].Location = new Point((Width - HandleSize - gap) / 2, Height - HandleSize - gap);
        resizeHandles[(int)BottomLeft]  .Location = new Point(gap,  Height - HandleSize - gap);
        resizeHandles[(int)CenterLeft]  .Location = new Point(gap, (Height - HandleSize - gap) / 2);

        Invalidate();
    }

    protected virtual void InitializeResizeHandles()
    {
        resizeHandles = new Rectangle[8];
        for (int i = 0; i < 8; i++)
            resizeHandles[i] = new Rectangle(0, 0, HandleSize, HandleSize);
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