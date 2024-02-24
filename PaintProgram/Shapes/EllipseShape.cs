/* Project: Paint
 * Authors: Noah Curtis, Austin Bryan, Lucius Miller
 * Class: Foundations in App Development
 * Date: February 24th, 2024*/





namespace PaintProgram.Shapes;

public partial class EllipseShape : RectangleShape
{
    public EllipseShape() => InitializeComponent();

    protected override void DrawShape(PaintEventArgs e)
    {
        Rectangle rect = new (new Point(Gap, Gap), new Size(Width - Gap * 2, Height - Gap * 2));

        e.Graphics.FillEllipse(new SolidBrush(ShapeColor), rect);
        e.Graphics.DrawEllipse(new Pen(new SolidBrush(BorderColor), BorderThickness), rect);
    }
}