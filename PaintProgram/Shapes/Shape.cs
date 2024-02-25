/* Project: Paint
 * Authors: Austin Bryan, Lucius Miller, Noah Curtis
 * Class: Foundations in App Development
 * Date: February 24th, 2024
 */

using static PaintProgram.Shapes.Handle;

namespace PaintProgram.Shapes;

enum Handle { TopLeft, TopMiddle, TopRight, CenterRight, BottomRight, BottomMiddle, BottomLeft, CenterLeft }
public enum State { Idle, Resizing, ChangingAlpha, Moving}

/* Purpose: Shape is designed to be very easy to create child classes. All that needs to be done is to override the GetPoints function. 
 * Every point in the array of points thats generated is based on width and height, allowing it to be stretched and the unique algorithm for each shape
 * Will be redrawn. Since the shapes are just changed values here and there and override the GetPoints function, I won't be commenting them since
 * There's nothing meaningful for me to add. 
 */

public partial class Shape : Form
{
    // ---- Properties ---- //
    // - Public - //
    public bool IsFocused => this == ActiveForm;
    public virtual bool ShowAlphaBox => false;

    // Z order is used for changing the order of the forms
    private int _zOrder;
    public int ZOrder
    {
        get => _zOrder;
        set
        {
            if (!zOrderMap.ContainsKey(value))
                zOrderMap.Add(value, this);

            _zOrder = value;
            zOrderLabel.Text = value.ToString();
        }
    }

    private bool _useBorder = true;
    public bool UseBorder
    {
        get => _useBorder;
        set
        {
            _useBorder = value;
            Refresh();
        }
    }

    private int _borderThickness = 2;
    public int BorderThickness
    {
        get => _borderThickness;
        set
        {
            _borderThickness = value;
            Refresh();
        }
    }
    private Color shapeColor = Color.FromArgb(255, 90, 90, 150);
    public Color ShapeColor
    {
        get => shapeColor;
        set
        {
            shapeColor = value;
            Refresh();
        }
    }
    private Color borderColor = Color.Black;
    public Color BorderColor
    {
        get => borderColor;
        set
        {
            borderColor = value;
            Refresh();  
        }
    }

    // - Protected - //
    protected bool ShouldShowHandles { get; private set; } = false;
    protected const int Gap = 10;                                       // The gap between the edge of the form and the shape gives room for resize handles
    protected Point resizeStart, moveStart;
    protected Point[] points;
    protected State State;

    // - Private - //
    private const int HandleSize = 8;
    private static readonly List<Shape> shapes = new();
    private static readonly Dictionary<int, Shape> zOrderMap = new();   // Used for zordering

    private Rectangle[] resizeHandles;      // Resize handles allow the user to click and drag to change the proportions of the shape
    private Handle activeHandle;            // The handle being dragged
    private readonly ClickDragMover clickDragMover = new();

    // ---- Methods ---- //
    // - Public - //
    public Shape() : base()
    {
        DoubleBuffered = true; // Enable double buffering to reduce flickering during resizing

        InitializeComponent();
        Width = Height = 300;

        OnResize(default);
        FormAsControlStyler.StyleFormAsControl(this);

        shapes.Add(this);
        ZOrder = shapes.Count - 1;
    }
    public void HideHandles()
    {
        ShouldShowHandles = false;
        Refresh();
    }

    // - Protected - //
    protected static float Lerp(float start, float end, float t) => start + t * (end - start);

    protected virtual Point[] GetPoints() => Array.Empty<Point>();  
    protected virtual void DrawShape(PaintEventArgs e)
    {
        e.Graphics.FillPolygon(new SolidBrush(ShapeColor), points);
     
        if (UseBorder)
            e.Graphics.DrawPolygon(new Pen(BorderColor, BorderThickness), points);
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

        if (!ShouldShowHandles)     // Only show handles if the user clicked on the shape
            return;
        
        // Draw resize handles
        // Define a pen for drawing the border
        var borderPen = new Pen(Color.RebeccaPurple, 2);
        var linePen = new Pen(Color.RebeccaPurple, 2);

        // Draw lines that connect each size handle
        for (int i = 0; i < resizeHandles.Length; i++)
        {
            int j = i + 1;
            if (j >= resizeHandles.Length)
                j = 0;

            e.Graphics.DrawLine(linePen,
                resizeHandles[i].Location.Add(new(resizeHandles[i].Width / 2, resizeHandles[i].Height / 2)),
                resizeHandles[j].Location.Add(new(resizeHandles[j].Width / 2, resizeHandles[j].Height / 2)));
        }
        // Draw the actual size handles
        foreach (Rectangle handleRectangle in resizeHandles)
        {
            e.Graphics.DrawRectangle(borderPen, handleRectangle);
            e.Graphics.FillRectangle(Brushes.CornflowerBlue, handleRectangle);
        }
    }
    protected override void OnMouseDown(MouseEventArgs e)
    {
        // Check if the mouse is within any of the resize handles
        for (int i = 0; i < resizeHandles.Length; i++)
        {
            if (!resizeHandles[i].Contains(e.Location))     // Skip if the mouse is not over the ith handle
                continue;

            // Resize start
            State        = State.Resizing;
            resizeStart  = e.Location;
            Cursor       = GetCursorForHandle(i);
            activeHandle = (Handle)i;

            return;
        }
        
        shapes.ForEach(s => s.HideHandles());   // Hide all other shapes' handles
        State = State.Moving;
        ShouldShowHandles = true;
        Refresh();

        clickDragMover.OnMouseDown(e);
        moveStart = e.Location;

        ((MainForm)Owner).ShowShapeEditor((color) => ShapeColor = color, this);
        ((MainForm)Owner).BringTopUIToFront();
    }
    protected override void OnMouseMove(MouseEventArgs e)
    {
        base.OnMouseMove(e);

        switch (State)
        {
        // Resize the control if the left mouse button is pressed and the cursor is over a resize handle
        case State.Resizing:
        {
            var (deltaX, deltaY) = GetDelta(resizeStart);

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
                    
            ((MainForm)Owner).RefreshShapeEditor();
            break;
        }
        // Adjust the custom parameter of the shape
        case State.ChangingAlpha:
            AdjustAlpha(e);

            OnAlphaChange();
            ((MainForm)Owner).RefreshShapeEditor();
            break;
        case State.Moving:
        {
            Location = clickDragMover.OnMouseMove(Location, e, (MainForm)Owner) ?? Location;
            ((MainForm)Owner).RefreshShapeEditor();
            break;
        }
        default:
            UpdateCursor(e);
            break;

        }
        (int, int) GetDelta(Point point) => (e.X - point.X, e.Y - point.Y);
    }
    protected virtual void OnAlphaChange() { }
    protected override void OnMouseUp(MouseEventArgs e)
    {
        base.OnMouseUp(e);

        clickDragMover.OnMouseDown(e);
        (State, Cursor) = (State.Idle, Cursors.Default);
    }
    protected override void OnResize(EventArgs e)
    {
        base.OnResize(e);

        if (resizeHandles == null)
            InitializeHandles();

        const int gap = 5;

        // Update positions of resize handles
        resizeHandles[(int)TopLeft]     .Location = new Point(gap, gap);
        resizeHandles[(int)TopMiddle]   .Location = new Point((Width - HandleSize) / 2, gap);
        resizeHandles[(int)TopRight]    .Location = new Point( Width - HandleSize - gap, gap);
        resizeHandles[(int)CenterRight] .Location = new Point( Width - HandleSize - gap, (Height - HandleSize) / 2);
        resizeHandles[(int)BottomRight] .Location = new Point( Width - HandleSize - gap, Height - HandleSize - gap);
        resizeHandles[(int)BottomMiddle].Location = new Point((Width - HandleSize) / 2, Height - HandleSize - gap);
        resizeHandles[(int)BottomLeft]  .Location = new Point(gap,  Height - HandleSize - gap);
        resizeHandles[(int)CenterLeft]  .Location = new Point(gap, (Height - HandleSize) / 2);

        Invalidate();
    }
    // Normally clicking on a form brings it to the front by default. This felt uninuitive, so I modeling my behaviour by Google Drawings. 
    // The way Google Drawings handles it is a mouse down event doesn't bring to front, it stays in the order it was
    protected override void WndProc(ref Message m)
    {
        const int WM_MOUSEACTIVATE = 0x0021;

        // Intercepts mouse activation message
        if (m.Msg == WM_MOUSEACTIVATE)
        {
            // Here we surpress the activation to prevent the form from being brought to the front
            m.Result = (IntPtr)3; // Returns MA_NOACTIVATE
            return;
        }

        // Call base WndProc for default processing of other messages
        base.WndProc(ref m);
    }

    // - Private - //
    private static Cursor GetCursorForHandle(int handleIndex) => handleIndex switch
    {
        0 or 4 => Cursors.SizeNWSE,
        1 or 5 => Cursors.SizeNS,
        2 or 6 => Cursors.SizeNESW,
        3 or 7 => Cursors.SizeWE,
        _      => Cursors.Default,
    };
    private void ResizeControl((int width, int height) sizeDelta, (int left, int top) positionDelta) => ResizeControl(sizeDelta, positionDelta, new(0, 0));
    private void ResizeControl((int width, int height) sizeDelta, (int left, int top) positionDelta, Point newResizeStart)
    {
        const int minSize = 12;

        // Adjusting the height, will expand from the bottom, but if the user is dragging from the top, this feels wrong. 
        // Therefor, if the user drags from the top, the height is increased by x amount, but the location needs to be decreased by x amount
        // To create the illusion that its being stretched from the top. Dragging from left also requires the shape to be moved to the left.
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

    private void Shape_MouseClick(object sender, MouseEventArgs e)
    {
        // Show right click menu
        if (e.Button == MouseButtons.Right)
            contextMenuStrip1.Show(this, e.Location);
    }
    // Events for context menu
    private void sendToBackToolStripMenuItem_Click   (object sender, EventArgs e) => MoveToBack();
    private void bringToFrontToolStripMenuItem_Click (object sender, EventArgs e) => MoveToFront();
    private void sendBackwardsToolStripMenuItem_Click(object sender, EventArgs e) => MoveBackwards();
    private void bringForwardsToolStripMenuItem_Click(object sender, EventArgs e) => MoveForwards();

    // Another oddity I ran into in WinForms is that forms don't have a built int functions for SendBackwards() and BringForwards()
    // Even though BringToFront() and SendToBack() exists. Despite SendToBack() existing, when I used it had the same exact after as
    // BringToFront(). My guess is that this only exists because Form : Control, and calling this function calls some function that automatically
    // Sets the form on top. So I had the pleasure of Implimenting SendToBack(), SendBackwards() and BringForwards() using only BringToFront()
    public void MoveToBack()
    {
        if (ZOrder == 0)    // Prevent moving back if already last in line
            return;
        zOrderMap.Clear();  // Clearing the zOrderMap prevents duplicate entries being added to the map later. 

        // Calls BringToFront() on all forms in the correct order to maintain previous order
        shapes.OrderBy(s => s.ZOrder).ToList().ForEach(s =>
        {
            if (s != this)  // Ignoring this to push it to back
            {
                s.ZOrder++;
                s.BringToFront();
            }
        });
        ZOrder = 0;
    }
    public void MoveToFront()
    {
        BringToFront();
        ((MainForm)Owner).BringTopUIToFront();

        // Cache all the shapes above this one, before the move occured
        var above = shapes.Where(s => s.ZOrder > ZOrder).ToList();
        above.ForEach(s => zOrderMap.Remove(s.ZOrder));

        // Decrement the shapes that used to be above this shape
        zOrderMap.Remove(ZOrder);
        above.ForEach(s => s.ZOrder--);

        ZOrder = shapes.Count - 1;
    }
    public void MoveForwards()
    {
        if (!zOrderMap.ContainsKey(ZOrder + 1)) // Prevent moving front if already first in line
            return;
        
        // Swaps zOrders with the shape directly above
        Shape shapeAboveThis = zOrderMap[ZOrder + 1];

        zOrderMap.Remove(ZOrder);
        zOrderMap.Remove(ZOrder + 1);

        BringToFront();
        shapeAboveThis.ZOrder--;
        ZOrder++;

        // Bring to front all the shapes that should be on top of this in the correct order
        shapes.Where(s => s._zOrder > _zOrder).ToList().ForEach(shape => shape.BringToFront());
    }

    public void MoveBackwards()
    {
        if (ZOrder == 0) // Prevent moving front if already first in line
            return;

        // Swap z order with the shape below this
        Shape shapeBelowTHis = zOrderMap[ZOrder - 1];

        zOrderMap.Remove(ZOrder);
        zOrderMap.Remove(ZOrder - 1);

        shapeBelowTHis.BringToFront();
        shapeBelowTHis.ZOrder++;
        ZOrder--;

        shapes.Where(s => s._zOrder > _zOrder).ToList().ForEach(shape => shape.BringToFront());
    }
}