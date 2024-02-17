namespace PaintProgram.Shapes;

public partial class Star6Points : StarShape
{
    protected override int NumSides          => 12;
    protected override double Offset         => 0;
    protected override float StartAlpha      => 0.42f;
    protected override float WidthAdjustment => -2.0f;

    public Star6Points() => InitializeComponent();
}