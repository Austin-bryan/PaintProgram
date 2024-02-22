namespace PaintProgram.Shapes;

public partial class TrapazoidShape : ParametricShape
{
    protected override int AlphaPointIndex => 0;
    protected override float WidthAdjustment => -3f;
    public override float MaxAlpha => 0.4999f;
    public override float MinAlpha => 0.04f;

    public TrapazoidShape()
    {
        InitializeComponent();
        alphaHandles.Add(new AlphaHandle(this, AlphaPointIndex, Alpha, MinAlpha, MaxAlpha, e => Lerp(MinAlpha, MaxAlpha, e.X / (float)Width * 2)));
    }

    protected override Point[] GetPoints() => new Point[]
    {
        new(ShortLength(Width), Gap),
        new(LongLength(Width), Gap),
        new(Width - Gap, Height - Gap),
        new(Gap, Height - Gap)
    };
}