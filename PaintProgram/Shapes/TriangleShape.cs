namespace PaintProgram;

public partial class TriangleShape : Shape
{
    public TriangleShape() => InitializeComponent();

    protected override Point[] GetPoints() => new Point[]
    {
        new(Width / 2, Gap),             // Top-middle corner
        new(Width - Gap, Height - Gap),  // Bottom-right corner
        new(Gap, Height - Gap)           // Bottom-left corner
    };
}
