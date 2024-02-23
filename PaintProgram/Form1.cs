using PaintProgram.Shapes;
using PaintProgram.Shapes.NGons;
using System.Drawing.Design;

namespace PaintProgram;

public partial class Form1 : Form
{
    private readonly List<Shape> shapes      = new();
    private readonly TitleBar    titleBar    = new();
    private readonly ColorWheel  colorWheel  = new();
    private readonly ToolBarForm toolBarForm = new();
    private readonly ShapeEditor shapeEditor = new();

    public void DeleteMe(Dictionary<int, Shape> zOrderMap)
    {
        label2.Text = "";
        foreach (var (zOrder, Shape) in zOrderMap)
        {
            string s = Shape.GetType().Name;
            label2.Text += (zOrder, Shape.GetType().Name).ToString() + "\n";
        }
    }
    public Form1()
    {
        InitializeComponent();
        WindowState = FormWindowState.Maximized;

        //CreateShape<ChevronShape>();
        //CreateShape<DoubleArrowShape>();
        //CreateShape<ArrowShape>();
        //CreateShape<MapShape>();
        //CreateShape<PentagonShape>();
        //CreateShape<HexagonShape>();
        //CreateShape<SeptagonShape>();
        //CreateShape<OctagonShape>();
        //CreateShape<DecagonShape>();
        //CreateShape<RectangleShape>();
        //CreateShape<TriangleShape>();
        //CreateShape<RightTriangleShape>();
        //CreateShape<CrossShape>();
        //CreateShape<Star4Points>();
        //CreateShape<Star5Points>();
        //CreateShape<Star6Points>();
        //CreateShape<TrapazoidShape>();
        //CreateShape<EllipseShape>();

        InitializeCustomTitleBar();
        toolBarForm.Show();
        toolBarForm.Owner = this;
        toolBarForm.Location = new Point(10, 40);
        toolBarForm.InitOwner();

        titleBar.Show();
        titleBar.Owner = this;
        shapeEditor.Owner = this;
        
        resizerF();
    }
    
    public void ShowShapeEditor(Shape shape)
    {
        shapeEditor.Show();
        shapeEditor.Location = titleBar.ExitButtonLocation.Subtract(new Point(shapeEditor.Width - 20, -50));
        shapeEditor.ActiveShape = shape;
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

    public void BringTitleBarToFront()
    {
        titleBar.BringToFront();
        toolBarForm.BringToFront();
        shapeEditor.BringToFront();
    }

    private void InitializeCustomTitleBar() => (FormBorderStyle, ControlBox) = (FormBorderStyle.None, false);
    private void Form1_Click(object sender, EventArgs e)
    {
        shapes.ForEach(s => s.HideHandles());
        shapeEditor.Hide();
    }

    private void shapeButton4_Load(object sender, EventArgs e)
    {

    }

    private void toolBar1_Load(object sender, EventArgs e)
    {
    }

    public enum EPaintTool { None, Brush, Spray, Fountain, Eraser }

    public int AbsoluteRadius = 20;
    public bool mouseIsDown = false;

    public EPaintTool PaintTool { get; set; } = EPaintTool.Fountain;
    private Graphics g;
    private Color absoluteColor = Color.Black;
    private int x = -1;
    private int y = -1;
    private Brush brush;
    private Pen pen;

    public void resizerF()
    {
        //Cursors(Cursors.)
        g = paintPanel.CreateGraphics();
        g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
        brush = new SolidBrush(absoluteColor);
        pen = new Pen(absoluteColor, 3);
        pen.StartCap = pen.EndCap = System.Drawing.Drawing2D.LineCap.Round;
    }

    private (int, int, int) randomPoint(int x, int y, int radius)
    {
        Random random = new();
        x = random.Next(x - radius, x + radius);
        y = random.Next(y - radius, y + radius);
        return (x, y, 0);
    }

    private int DetermineFountainThickness(int x3, int y3)
    {
        double x1 = x3; double y1 = y3;
        double x2 = x; double y2 = y;
        x2 -= x1; y2 -= y1;
        x2 *= x2; y2 *= y2;
        double sX = Math.Sqrt(x2);
        double sY = Math.Sqrt(y2);

        return sX < sY ? 10 : 2;
    }


    //the function which draws onto the panel
    private int PaintScreen(int x, int y)
    {
        switch (PaintTool)
        {
            case EPaintTool.Brush:
                g.DrawLine(pen, new PointF(this.x, this.y), new PointF(x, y));
                break;
            case EPaintTool.Spray:
                for (int i = 0; i < 100; i++)
                {
                    var imposter = randomPoint(x, y, AbsoluteRadius);
                    g.FillEllipse(brush, imposter.Item1, imposter.Item2, 2, 2);
                }
                break;
            case EPaintTool.Fountain:
                int width = DetermineFountainThickness(x, y);
                g.FillRectangle(brush, x, y, width, 3);
                break;
            case EPaintTool.Eraser:

                brush = new SolidBrush(paintPanel.BackColor);
                g.FillEllipse(brush, x, y, AbsoluteRadius, AbsoluteRadius);
                break;
            default:
                MessageBox.Show("def");
                break;

        }
        return 0;
    }


    //this lets the expanded canvas be useable.
    private void panel1_Resize(object sender, EventArgs e)
    {
        //InitializeComponent();
        resizerF();
    }

    //erases the canvas
    private void eraser()
    {
        paintPanel.Invalidate();
    }

    private void paintPanel_MouseDown(object sender, MouseEventArgs e)
    {
        (x, y) = (e.X, e.Y);
        PaintScreen(e.X, e.Y);
        mouseIsDown = true;
    }

    private void paintPanel_MouseMove(object sender, MouseEventArgs e)
    {
        Cursor.Current = Cursors.WaitCursor;
        if (mouseIsDown && x != -1 && y != -1)
        {
            PaintScreen(e.X, e.Y);
            (x, y) = (e.X, e.Y);
        }
    }

    private void paintPanel_MouseUp(object sender, MouseEventArgs e) => mouseIsDown = false;

    private void paintPanel_MouseEnter(object sender, EventArgs e) => Cursor.Show();

    private void paintPanel_MouseLeave(object sender, EventArgs e) => Cursor.Show();

    private void paintPanel_MouseHover(object sender, EventArgs e)
    {
        //Cursor.Current = Cursors.Default;
    }
}

