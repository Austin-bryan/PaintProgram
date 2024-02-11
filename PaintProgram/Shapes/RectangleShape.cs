namespace PaintProgram.Shapes;

public partial class RectangleShape : Shape
{
    public RectangleShape() => InitializeComponent();

    protected override Point[] GetPoints() => new Point[]
    {
        new(Gap, Gap),                   // Top-left corner
        new(Width - Gap, Gap),           // Top-right corner
        new(Width - Gap, Height - Gap),  // Bottom-right corner
        new(Gap, Height - Gap)           // Bottom-left corner
    };
}
