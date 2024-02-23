using PaintProgram.Shapes;
using PaintProgram.Shapes.NGons;

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
}
