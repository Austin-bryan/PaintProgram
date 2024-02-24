using PaintProgram.Shapes;

namespace PaintProgram;

public partial class Form1 : Form
{
    public enum EPaintTool { None, Brush, Spray, Fountain, Eraser }

    private EPaintTool paintTool = EPaintTool.None;
    public EPaintTool ActivePaintTool
    {
        get => paintTool;
        set
        {
            paintTool = value;
            Cursor = value == EPaintTool.None ? Cursors.Default : GetCircularCursor(paintSizes[ActivePaintTool]);
        }
    }
    
    private Color paintColor = Color.Black;
    public Color PaintColor
    {
        get => paintColor;
        set
        {
            paintColor = value;
            pen.Color = value;
            brush = new SolidBrush(value);
        }
    }

    public Dictionary<EPaintTool, int> PaintSizes => paintSizes;

    private readonly List<Shape> shapes      = new();
    private readonly TitleBar    titleBar    = new();
    private readonly ColorWheel  colorWheel  = new();
    private readonly ToolBarForm toolBarForm = new();
    private readonly ShapeEditor shapeEditor = new();
    private readonly Dictionary<EPaintTool, int> paintSizes = new()
    {
        { EPaintTool.None, 0 },
        { EPaintTool.Brush, 10 },
        { EPaintTool.Spray, 32 },
        { EPaintTool.Eraser, 20 },
        { EPaintTool.Fountain, 3 }
    };

    private Graphics g;
    private int x = -1;
    private int y = -1;
    private bool mouseIsDown = false;
    private Brush brush, eraserBrush;
    private Pen pen;

    public Form1()
    {
        InitializeComponent();
        WindowState = FormWindowState.Maximized;

        paintPanel.Size = Size;
        paintPanel.Size += new Size(200, 200);
        paintPanel.BackColor = BackColor;

        InitializeCustomTitleBar();
        toolBarForm.Show();
        toolBarForm.Owner = this;
        toolBarForm.Location = new Point(10, 40);

        // Set the form's cursor to the circular cursor
        titleBar.Show();
        titleBar.Owner = this;
        shapeEditor.Owner = this;

        eraserBrush = new SolidBrush(BackColor);

        ResizerF();
    }

    public void HideShapeEditor() => shapeEditor.Hide();
    public void ShowShapeEditor(Action<Color> onSelectColor, Shape shape = null)
    {
        shapeEditor.Show();
        shapeEditor.OnSelectColor = onSelectColor;
        shapeEditor.Location      = titleBar.ExitButtonLocation.Subtract(new Point(shapeEditor.Width - 20, -50));
        shapeEditor.ActiveShape   = shape;
    }
    public void RefreshShapeEditor() => shapeEditor?.RefreshShapeEditor();
    public void AddShape(Shape shape) => shapes.Add(shape);
    public void CreateShape<T>() where T : Shape, new()
    {
        var shape = new T { Owner = this };
        shape.Show();
        shapes.Add(shape);
        BringTitleBarToFront();
    }
    public void SetBrushSize(int newSize)
    {
        paintSizes[ActivePaintTool] = newSize;
        Cursor = GetCircularCursor(newSize);
    }
    public void BringTitleBarToFront()
    {
        titleBar.BringToFront();
        toolBarForm.BringToFront();
        shapeEditor.BringToFront();
    }

    private static Cursor GetCircularCursor(int diameter)
    {
        // Creates a circular bitmap image for the cursor
        Bitmap cursorImage = new (diameter + 10, diameter + 10);
        using (Graphics g = Graphics.FromImage(cursorImage))
        {
            g.Clear(Color.Transparent);
            g.DrawEllipse(new Pen(Brushes.Black, 2), 5, 5, diameter, diameter); // Draw a black circle
        }

        return new Cursor(cursorImage.GetHicon());
    }
    private static (int, int, int) GetRandomPoint(int x, int y, int radius)
    {
        Random random = new Random();
        double angle = random.NextDouble() * 2 * Math.PI;              // Random angle between 0 and 2*pi
        double randomRadius = Math.Sqrt(random.NextDouble()) * radius; // Random radius between 0 and maxRadius

        // Calculate the x and y coordinates using polar to Cartesian conversion
        int randomX = x + (int)(randomRadius * Math.Cos(angle));
        int randomY = y + (int)(randomRadius * Math.Sin(angle));

        return (randomX, randomY, 0);
    }

    private void InitializeCustomTitleBar() => (FormBorderStyle, ControlBox) = (FormBorderStyle.None, false);
    private void Form1_Click(object sender, EventArgs e)
    {
        shapes.ForEach(s => s.HideHandles());
        shapeEditor.Hide();
    }
    private void ResizerF()
    {
        g                 = paintPanel.CreateGraphics();
        g.SmoothingMode   = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
        brush             = new SolidBrush(PaintColor);
        pen          = new Pen(PaintColor, paintSizes[EPaintTool.Brush]);
        pen.StartCap = pen.EndCap = System.Drawing.Drawing2D.LineCap.Round;
    }
    private int DetermineFountainThickness(int x3, int y3)
    {
        double x1 = x3; double y1 = y3;
        double x2 = x; double y2 = y;
        x2       -= x1; y2 -= y1;
        x2       *= x2; y2 *= y2;
        double sX = Math.Sqrt(x2);
        double sY = Math.Sqrt(y2);

        return sX < sY ? 10 : 2;
    }

    // The function which draws onto the panel
    private int PaintScreen(int x, int y)
    {
        switch (ActivePaintTool)
        {
            case EPaintTool.Brush:
                pen.Width = paintSizes[EPaintTool.Brush];
                g.DrawLine(pen, new PointF(this.x, this.y), new PointF(x, y));
                break;
            case EPaintTool.Spray:
                
                for (int i = 0; i < 100; i++)
                {
                    var imposter = GetRandomPoint(x, y, paintSizes[EPaintTool.Spray]);
                    g.FillEllipse(brush, imposter.Item1, imposter.Item2, 2, 2);
                }
                break;
            case EPaintTool.Fountain:
                int fountainRadius = paintSizes[EPaintTool.Fountain];
                int width = DetermineFountainThickness(x, y);
                g.FillRectangle(brush, x, y, (int)(width), fountainRadius);
                break;
            case EPaintTool.Eraser:

                int eraserRadius = paintSizes[EPaintTool.Eraser];
                g.FillEllipse(eraserBrush, x - eraserRadius / 2, y - eraserRadius / 2, eraserRadius, eraserRadius);
                break;
            default:
                break;

        }
        return 0;
    }

    // This lets the expanded canvas be useable.
    private void panel1_Resize(object sender, EventArgs e) => ResizerF();

    private void paintPanel_MouseDown(object sender, MouseEventArgs e)
    {
        shapes.ForEach(s => s.HideHandles());
        
        if (ActivePaintTool == EPaintTool.None)
            HideShapeEditor();
        else
            brush = new SolidBrush(paintColor);

        (x, y) = (e.X, e.Y);
        PaintScreen(e.X, e.Y);
        mouseIsDown = true;
    }
    private void paintPanel_MouseMove(object sender, MouseEventArgs e)
    {
        if (mouseIsDown && x != -1 && y != -1)
        {
            PaintScreen(e.X, e.Y);
            (x, y) = (e.X, e.Y);
        }
    }
    private void paintPanel_MouseUp(object sender, MouseEventArgs e) => mouseIsDown = false;
    private void paintPanel_MouseEnter(object sender, EventArgs e)
    {
        //Cursor.Show();
    }
    private void paintPanel_MouseLeave(object sender, EventArgs e)
    {
        //Cursor.Show();
    }
    private void paintPanel_MouseHover(object sender, EventArgs e)
    {
        //Cursor.Current = Cursors.Default;
    }
}