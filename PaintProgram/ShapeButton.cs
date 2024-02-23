using PaintProgram.Shapes;
using System.ComponentModel;

namespace PaintProgram;

public partial class ShapeButton : ToolBarButton
{
    public enum EShape { Cross, Ellipse, Rectangle, RightTriangle, Star4, Star5, Star6, Triangle, Trapazoid, Pentagon, Hexagon, Septagon, Octagon, Decagon, Arrow, Chevron, DoubleArrow }

    [Browsable(true)]
    [Category("Shapes")]
    [EditorBrowsable(EditorBrowsableState.Always)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    private EShape shape;
    public EShape Shape
    {
        get => shape;
        set => shape = value;
    }
    public Form1 Form1Instance { get; set; }

    public ShapeButton()
    {
        int @char = 3;
        InitializeComponent();
        button1.Text = String.Empty;
    }
    private void ShapeButton_Click(object sender, EventArgs e)
    {
        switch (Shape)
        {
            case EShape.Cross: CreateShape<CrossShape>(); break;
            case EShape.Ellipse: CreateShape<EllipseShape>(); break;
            case EShape.Rectangle: CreateShape<RectangleShape>(); break;
            case EShape.RightTriangle: CreateShape<RightTriangleShape>(); break;
            case EShape.Trapazoid: CreateShape<TrapazoidShape>(); break;
            case EShape.Star4: CreateShape<Star4Points>(); break;
            case EShape.Star5: CreateShape<Star5Points>(); break;
            case EShape.Star6: CreateShape<Star6Points>(); break;
            case EShape.Triangle: CreateShape<TriangleShape>(); break;
            default: MessageBox.Show("Not implemented"); break;
        }
    }
    private void CreateShape<T>() where T : Shape, new()
    {
        var shape = new T { Owner = Form1Instance };
        shape.Show();
        Form1Instance.AddShape(shape);
        Form1Instance.BringTitleBarToFront();
    }
}
