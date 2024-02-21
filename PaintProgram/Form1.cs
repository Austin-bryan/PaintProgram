using PaintProgram.Shapes;

namespace PaintProgram;

public partial class Form1 : Form
{
    private readonly List<Shape> shapes     = new();
    private readonly TitleBar    titleBar   = new();
    private readonly ColorWheel  colorWheel = new();
    private readonly Stupid      stupid = new();

    public Form1()
    {
        InitializeComponent();
        WindowState = FormWindowState.Maximized;

        CreateShape<RectangleShape>();
        CreateShape<TriangleShape>();
        CreateShape<RightTriangleShape>();
        CreateShape<CrossShape>();
        CreateShape<Star4Points>();
        CreateShape<Star5Points>();
        CreateShape<Star6Points>();
        CreateShape<TrapazoidShape>();
        CreateShape<EllipseShape>();

        InitializeCustomTitleBar();
        titleBar.Show();
        titleBar.Owner  = this;
        stupid.Owner    = this;
        stupid.Location = titleBar.ExitButtonLocation.Subtract(new Point(stupid.Width, 0));
        stupid.Location = new (0, 0);
    }
    
    public void ShowShapeEditor(Shape shape)
    {
        stupid.Show();
        stupid.Location = new(0, 0); 
        stupid.Location = titleBar.ExitButtonLocation.Subtract(new Point(stupid.Width - 20, -50));

        stupid.ActiveShape = shape;
    }
    public void RefreshShapeEditor() => stupid?.RefreshPixelBoxes();
    private void CreateShape<T>() where T : Shape, new()
    {
        var shape = new T { Owner = this };
        shape.Show();
        shapes.Add(shape);
        BringTitleBarToFront();
    }

    public void BringTitleBarToFront()
    {
        stupid.BringToFront();
        titleBar.BringToFront();
    }

    private void InitializeCustomTitleBar() => (FormBorderStyle, ControlBox) = (FormBorderStyle.None, false);
    private void Form1_Click(object sender, EventArgs e)
    {
        shapes.ForEach(s => s.HideHandles());
        stupid.Hide();
    }
}
