/* Project: Paint
 * Authors: Noah Curtis, Austin Bryan, Lucius Miller
 * Class: Foundations in App Development
 * Date: February 24th, 2024*/




namespace PaintProgram.Shapes;

public partial class Star4Points : StarShape
{
    protected override int NumSides          => 8;
    protected override double Offset         => 3 * Math.PI / 4f + Math.PI;
    protected override float StartAlpha      => 0.6f;
    protected override float WidthAdjustment => -2.8f;

    public Star4Points() => InitializeComponent();
}