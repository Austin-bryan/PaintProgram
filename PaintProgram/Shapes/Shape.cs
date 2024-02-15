using System.Runtime.InteropServices;
using System.Security.Cryptography;
using static PaintProgram.Shapes.Handle;

namespace PaintProgram.Shapes;

enum Handle { TopLeft, TopMiddle, TopRight, CenterRight, BottomRight, BottomMiddle, BottomLeft, CenterLeft }
public enum State { Idle, Resizing, ChangingAlpha, Moving}

public partial class Shape : Form
{
    public bool IsFocused => this == ActiveForm;
    protected const int Gap = 10;
    protected bool shouldShowHandles = false;
    protected Point resizeStart, moveStart;
    protected Point[] points;
    protected State State;

    private const int HandleSize = 8;
    private Rectangle[] resizeHandles;
    private Handle activeHandle;
    private static readonly List<Shape> shapes = new();

    static int foo;
    public bool hasFocus;
    private System.Windows.Forms.Timer delayTimer;

    public Shape() : base()
    {
        DoubleBuffered = true; // Enable double buffering to reduce flickering during resizing

        InitializeComponent();
        InitializeHandles();

        Width = Height = 350;

        OnResize(default);

        BackColor = Color.LimeGreen;
        TransparencyKey = BackColor;
        ShowInTaskbar = false;
        FormBorderStyle = FormBorderStyle.None;

        shapes.Add(this);
    }

    public void HideHandles()
    {
        shouldShowHandles = false;
        Refresh();
    }

    protected static float Lerp(float start, float end, float t) => start + t * (end - start);

    protected override void WndProc(ref Message m)
    {
        const int WM_MOUSEACTIVATE = 0x0021;

        // Intercept mouse activation message
        if (m.Msg == WM_MOUSEACTIVATE)
        {
            // Suppress activation to prevent the form from being brought to the front
            m.Result = (IntPtr)3; // Returns MA_NOACTIVATE
            return;
        }

        // Call base WndProc for default processing of other messages
        base.WndProc(ref m);
    }

    protected virtual Point[] GetPoints() => Array.Empty<Point>();
    protected virtual void DrawShape(PaintEventArgs e)
    {
        const int shade = 90;
        e.Graphics.FillPolygon(new SolidBrush(Color.FromArgb(255, shade, shade, shade + 60)), points);
        //e.Graphics.FillPolygon(new SolidBrush(Color.FromArgb(255, 206, 226, 242)), points);
        e.Graphics.DrawPolygon(new Pen(Color.Black, 4), points);
    }
    protected virtual void AdjustAlpha(MouseEventArgs e) { }
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
    protected virtual void InitializeHandles()
    {
        resizeHandles = new Rectangle[8];
        for (int i = 0; i < 8; i++)
            resizeHandles[i] = new Rectangle(0, 0, HandleSize, HandleSize);
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
        }
    }
    protected override void OnMouseDown(MouseEventArgs e)
    {
        // Check if the mouse is within any of the resize handles
        for (int i = 0; i < resizeHandles.Length; i++)
        {
            if (!resizeHandles[i].Contains(e.Location))
                continue;

            State = State.Resizing;
            resizeStart = e.Location;
            Cursor = GetCursorForHandle(i);
            activeHandle = (Handle)i;

            return;
        }
        shapes.ForEach(s => s.HideHandles());
        State = State.Moving;
        shouldShowHandles = true;
        Refresh();

        moveStart = e.Location;
        ((Form1)Owner).BringTitleBarToFront();
    }
    protected override void OnMouseMove(MouseEventArgs e)
    {
        base.OnMouseMove(e);

        // Resize the control if the left mouse button is pressed and the cursor is over a resize handle
        switch (State)
        {
            case State.Resizing:
                {
                    var (deltaX, deltaY) = GetDelta(resizeStart);
                    switch (activeHandle)
                    {
                        case TopLeft: ResizeControl(sizeDelta: (-deltaX, -deltaY), positionDelta: (deltaX, deltaY)); break;
                        case TopMiddle: ResizeControl(sizeDelta: (0, -deltaY), positionDelta: (0, deltaY)); break;
                        case TopRight: ResizeControl(sizeDelta: (deltaX, -deltaY), positionDelta: (0, deltaY), new(e.X, resizeStart.Y)); break;
                        case CenterLeft: ResizeControl(sizeDelta: (-deltaX, 0), positionDelta: (deltaX, 0)); break;
                        case CenterRight: ResizeControl(sizeDelta: (deltaX, 0), positionDelta: (0, 0), e.Location); break;
                        case BottomLeft: ResizeControl(sizeDelta: (-deltaX, deltaY), positionDelta: (deltaX, 0), new(resizeStart.X, e.Y)); break;
                        case BottomMiddle: ResizeControl(sizeDelta: (0, deltaY), positionDelta: (0, 0), e.Location); break;
                        case BottomRight: ResizeControl(sizeDelta: (deltaX, deltaY), positionDelta: (0, 0), e.Location); break;
                    }
                    break;
                }
            case State.ChangingAlpha:
                AdjustAlpha(e);
                break;
            case State.Moving:
                {
                    var (deltaX, deltaY) = GetDelta(moveStart);
                    Location = new Point(Location.X + deltaX, Location.Y + deltaY);
                    break;
                }
            default:
                UpdateCursor(e);
                break;

        }

        (int, int) GetDelta(Point point) => (e.X - point.X, e.Y - point.Y);
    }
    protected override void OnMouseUp(MouseEventArgs e)
    {
        base.OnMouseUp(e);

        State = State.Idle;
        Cursor = Cursors.Default;
    }
    protected override void OnResize(EventArgs e)
    {
        base.OnResize(e);

        const int gap = 5;

        // Update positions of resize handles
        resizeHandles[(int)TopLeft].Location = new Point(gap, gap);
        resizeHandles[(int)TopMiddle].Location = new Point((Width - HandleSize) / 2, gap);
        resizeHandles[(int)TopRight].Location = new Point(Width - HandleSize - gap, gap);
        resizeHandles[(int)CenterRight].Location = new Point(Width - HandleSize - gap, (Height - HandleSize) / 2);
        resizeHandles[(int)BottomRight].Location = new Point(Width - HandleSize - gap, Height - HandleSize - gap);
        resizeHandles[(int)BottomMiddle].Location = new Point((Width - HandleSize) / 2, Height - HandleSize - gap);
        resizeHandles[(int)BottomLeft].Location = new Point(gap, Height - HandleSize - gap);
        resizeHandles[(int)CenterLeft].Location = new Point(gap, (Height - HandleSize) / 2);

        Invalidate();
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
    private void ResizeControl((int width, int height) sizeDelta, (int left, int top) positionDelta) => ResizeControl(sizeDelta, positionDelta, new(0, 0));
    private void ResizeControl((int width, int height) sizeDelta, (int left, int top) positionDelta, Point newResizeStart)
    {
        const int minSize = 12;

        if (Width + sizeDelta.width > minSize)
        {
            Width += sizeDelta.width;
            Left += positionDelta.left;
        }
        if (Height + sizeDelta.height > minSize)
        {
            Height += sizeDelta.height;
            Top += positionDelta.top;
        }
        if (newResizeStart != Point.Empty)
            resizeStart = newResizeStart;
    }
    private static Cursor GetCursorForHandle(int handleIndex) => handleIndex switch
    {
        0 or 4 => Cursors.SizeNWSE,
        1 or 5 => Cursors.SizeNS,
        2 or 6 => Cursors.SizeNESW,
        3 or 7 => Cursors.SizeWE,
        _ => Cursors.Default,
    };

    private void Shape_MouseClick(object sender, MouseEventArgs e)
    {
        if (e.Button != MouseButtons.Right)
            return;

        contextMenuStrip1.Show(this, e.Location);
    }

    private void sendToBackToolStripMenuItem_Click(object sender, EventArgs e)
    {
        foreach(var shape in shapes)
        {
            if (shape == this)
                continue;
            shape.BringToFront();
        }
    }

    private void bringToFrontToolStripMenuItem_Click(object sender, EventArgs e)
    {
        BringToFront();
        ((Form1)Owner).BringTitleBarToFront();
    }
}