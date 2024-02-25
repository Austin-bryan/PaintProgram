/* Project: Paint
 * Authors: Austin Bryan, Lucius Miller, Noah Curtis
 * Class: Foundations in App Development
 * Date: February 24th, 2024*/



namespace PaintProgram.Shapes;

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
