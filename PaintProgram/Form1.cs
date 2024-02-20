using PaintProgram.Shapes;

namespace PaintProgram;

public partial class Form1 : Form
{
    private readonly List<Shape> shapes     = new();
    private readonly TitleBar    titleBar   = new();
    private readonly ColorWheel  colorWheel = new();
    private readonly Stupid stupid = new();

    public Form1()
    {
        InitializeComponent();
        WindowState = FormWindowState.Maximized;

        titleBar.Show();
        titleBar.Owner = this;

        stupid.Show();
        stupid.Owner = this;

        //CreateShape<RectangleShape>();
        //CreateShape<TriangleShape>();
        //CreateShape<RightTriangleShape>();
        //CreateShape<CrossShape>();
        //CreateShape<Star4Points>();
        //CreateShape<Star5Points>();
        //CreateShape<Star6Points>();
        //CreateShape<TrapazoidShape>();

        InitializeCustomTitleBar();
    }
    
    private void CreateShape<T>() where T : Shape, new()
    {
        var shape = new T { Owner = this };
        shape.Show();
        shapes.Add(shape);
        BringTitleBarToFront();
    }

    public void BringTitleBarToFront()
    {
        colorWheel.BringToFront();
        titleBar.BringToFront();
    }

    private void InitializeCustomTitleBar()
    {
        FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
        ControlBox = false;
    }
    private void Form1_Click(object sender, EventArgs e) => shapes.ForEach(s => s.HideHandles());
}
