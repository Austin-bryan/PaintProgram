namespace PaintProgram;

public partial class EllipseShape : RectangleShape
{
    public EllipseShape() => InitializeComponent();

    protected override void DrawShape(PaintEventArgs e, ref Point[] points)
    {
        e.Graphics.FillEllipse(Brushes.MediumBlue, new Rectangle(new Point(Gap, Gap), new Size(Width - Gap * 2, Height - Gap * 2)));
    }
}
