namespace PaintProgram.Shapes;

public partial class CrossShape : ParametricShape
{
    protected override int AlphaPointIndex => 0;
    public override float MaxAlpha => 0.4999f;
    public override float MinAlpha => 0.04f;

    public CrossShape()
    {
        InitializeComponent();
        Alpha = 0.35f;

        alphaHandles.Add(new AlphaHandle(this, alphaPointIndex: 0, alpha: 0.35f, minAlpha: 0.04f, maxAlpha: 0.4999f,
            getAlpha: (e, @this) => Lerp(@this.MinAlpha, @this.MaxAlpha, e.X / (float)Width * 2)));
        //alphaHandles.Add(new AlphaHandle(this, AlphaPointIndex, Alpha, MinAlpha, MaxAlpha, e => Lerp(MinAlpha, MaxAlpha, e.X / (float)Width * 2)));
    }

    protected override Point[] GetPoints() => new Point[]
    {
        new(ShortLength(Width), Gap),
        new(LongLength(Width),  Gap),
        new(LongLength(Width),  ShortLength(Height)),
        new(Width - Gap,        ShortLength(Height)),
        new(Width - Gap,        LongLength(Height)),
        new(LongLength(Width),  LongLength(Height)),
        new(LongLength(Width),  Height - Gap),
        new(ShortLength(Width), Height - Gap),
        new(ShortLength(Width), LongLength(Height)),
        new(Gap,                LongLength(Height)),
        new(Gap,                ShortLength(Height)),
        new(ShortLength(Width), ShortLength(Height))
    };
}