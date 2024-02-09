using System.Drawing.Drawing2D;
using System.Windows.Forms.VisualStyles;
using static PaintProgram.Handle;

namespace PaintProgram;

enum Handle { TopLeft, TopMiddle, TopRight, CenterRight, BottomRight, BottomMiddle, BottomLeft, CenterLeft }

public partial class Shape : UserControl
{
    protected int Gap = 5;
    protected float Alpha = 0.25f;

    private const int HandleSize = 8;
    private bool isResizing = false, isMoving = false, isAdjustingAlpha = false;
    private Point resizeStart, moveStart;
    private Rectangle[] resizeHandles;
    private Handle activeHandle;
    private Rectangle[] alphaHandles;

    public Shape()
    {
        DoubleBuffered = true; // Enable double buffering to reduce flickering during resizing

        InitializeComponent();
        InitializeResizeHandles();

        OnResize(default);
    }

    private static float Lerp(float start, float end, float t) => start + t * (end - start);
    private static Cursor GetCursorForHandle(int handleIndex) => handleIndex switch
    {
        0 or 4 => Cursors.SizeNWSE,
        1 or 5 => Cursors.SizeNS,
        2 or 6 => Cursors.SizeNESW,
        3 or 7 => Cursors.SizeWE,
        _      => Cursors.Default,
    };

    protected virtual Point[] GetPoints() => Array.Empty<Point>();

    protected override void OnPaint(PaintEventArgs e)
    {
        base.OnPaint(e);
        BackColor = Color.Transparent;

        //SetStyle(ControlStyles.SupportsTransparentBackColor, true);
        //SetStyle(ControlStyles.Opaque, true);
        //SetStyle(ControlStyles.ResizeRedraw, true);
        //this.BackColor = Color.Transparent;

        // Cross
        //const int diamondRadius = 5;
        //Point[] diamondPoints = new Point[]
        //{
        //    points[0].Add(new(0, -diamondRadius)),
        //    points[0].Add(new(diamondRadius, 0)),
        //    points[0].Add(new(0, diamondRadius)),
        //    points[0].Add(new(-diamondRadius, 0))
        //};
        //e.Graphics.FillPolygon(Brushes.MediumBlue, points);
        //e.Graphics.DrawPolygon(new Pen(Color.Black, 2), diamondPoints);
        //e.Graphics.FillPolygon(Brushes.Orange, diamondPoints);
        //alphaHandles[0] = new Rectangle(points[0].X - diamondRadius, points[0].Y - diamondRadius, 10, 10);

        // David Star
        //int numSides = 12;

        //// Initialize the points array with the appropriate size
        //Point[] points = new Point[numSides];

        //// Calculate the coordinates of each vertex
        //for (int i = 0; i < numSides; i++)
        //{
        //    // Calculate the angle for each vertex
        //    double angle = 2 * Math.PI * i / numSides;

        //    // Calculate the coordinates of the vertex
        //    int x = (int)(Width  / 2 + (Width  / 2 * Math.Cos(angle))); // Center x-coordinate + (radius * cos(angle))
        //    int y = (int)(Height / 2 + (Height / 2 * Math.Sin(angle))); // Center y-coordinate + (radius * sin(angle))

        //    if (i % 2 == 0)
        //    {
        //        x = (int)Lerp(x, Width / 2, alpha);
        //        y = (int)Lerp(y, Height / 2, alpha);
        //    }

        //    // Store the vertex coordinates in the points array
        //    points[i] = new Point(x, y);
        //}
        //const int diamondRadius = 5;
        //Point[] diamondPoints = new Point[]
        //{
        //    points[6].Add(new(0, -diamondRadius)),
        //    points[6].Add(new(diamondRadius, 0)),
        //    points[6].Add(new(0, diamondRadius)),
        //    points[6].Add(new(-diamondRadius, 0))
        //};
        //e.Graphics.FillPolygon(Brushes.MediumBlue, points);
        //e.Graphics.DrawPolygon(new Pen(Color.Black, 2), diamondPoints);
        //e.Graphics.FillPolygon(Brushes.Orange, diamondPoints);
        //alphaHandles[0] = new Rectangle(points[6].X - diamondRadius, points[6].Y - diamondRadius, 10, 10);

        Point[] points = GetPoints();
        DrawShape(e, ref points);

        // Define a pen for drawing the border
        var borderPen = new Pen(Color.Black, 2);

        // Draw the border of each rectangle
        foreach (Rectangle handle in resizeHandles)
            e.Graphics.DrawRectangle(borderPen, handle);

        // Draw resize handles
        foreach (Rectangle handle in resizeHandles)
            e.Graphics.FillRectangle(Brushes.White, handle);
    }
    protected virtual void DrawShape(PaintEventArgs e, ref Point[] points)
    {
        e.Graphics.FillPolygon(Brushes.MediumBlue, points);
    }
    protected void DrawAlphaHandle(PaintEventArgs e, ref Point[] points, int pointIndex)
    {
        const int diamondRadius = 5;
        Point[] diamondPoints = new Point[]
        {
            points[pointIndex].Add(new(0, -diamondRadius)),
            points[pointIndex].Add(new(diamondRadius, 0)),
            points[pointIndex].Add(new(0, diamondRadius)),
            points[pointIndex].Add(new(-diamondRadius, 0))
        };
        e.Graphics.DrawPolygon(new Pen(Color.Black, 2), diamondPoints);
        e.Graphics.FillPolygon(Brushes.Orange, diamondPoints);

        alphaHandles[0] = new Rectangle(points[pointIndex].X - diamondRadius, points[pointIndex].Y - diamondRadius, 10, 10);
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
        if (alphaHandles.Length > 0 && alphaHandles[0].Contains(e.Location))
             isAdjustingAlpha = true;
        else isMoving = true;

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
        else if (isMoving)
        {
            int deltaX = e.X - moveStart.X;
            int deltaY = e.Y - moveStart.Y;

            Location = new Point(Location.X + deltaX, Location.Y + deltaY);
        }
        else if (isAdjustingAlpha)
        {
            Alpha = Lerp(0, 0.49f, (GetAlphaHandleX(e)) / (float)Width * 2);
            Alpha = Math.Min(Alpha, 1);
            Alpha = Math.Max(Alpha, 0);
            Refresh();
        }
        else
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
            if (alphaHandles.Length > 0 && alphaHandles[0].Contains(e.Location))
            {
                Cursor = Cursors.Cross;
                return;
            }
            Cursor = Cursors.SizeAll;
        }
    }

    protected virtual int GetAlphaHandleX(MouseEventArgs e) => e.X + moveStart.X;

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

    private void InitializeResizeHandles()
    {
        resizeHandles = new Rectangle[8];
        for (int i = 0; i < 8; i++)
            resizeHandles[i] = new Rectangle(0, 0, HandleSize, HandleSize);

        alphaHandles = new Rectangle[1];
    }
    private void ResizeControl((int width, int height) sizeDelta, (int left, int top) positionDelta) => ResizeControl(sizeDelta, positionDelta, new(0, 0));
    private void ResizeControl((int width, int height) sizeDelta, (int left, int top) positionDelta, Point newResizeStart)
    {
        (Width, Height) = (Width + sizeDelta.width, Height + sizeDelta.height);
        (Left, Top)     = (Left + positionDelta.left, Top + positionDelta.top);

        if (newResizeStart != Point.Empty)
            resizeStart = newResizeStart;
    }
}