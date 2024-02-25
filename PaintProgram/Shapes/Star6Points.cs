
/* Project: Paint
 * Authors: Austin Bryan, Lucius Miller, Noah Curtis
 * Class: Foundations in App Development
 * Date: February 24th, 2024*/




namespace PaintProgram.Shapes;

public partial class Star6Points : StarShape
{
    protected override int NumSides          => 12;
    protected override double Offset         => 0;
    protected override float StartAlpha      => 0.42f;
    protected override float WidthAdjustment => -2.0f;

    public Star6Points() => InitializeComponent();
}