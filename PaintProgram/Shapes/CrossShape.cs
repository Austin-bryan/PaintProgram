namespace PaintProgram.Shapes;

public partial class CrossShape : ParametetricShape
{
    protected override int AlphaPointIndex => 0;
    public override float MaxAlpha => 0.4999f;

    public CrossShape()
    {
        InitializeComponent();
        Alpha = 0.35f;
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
    protected override float GetAlpha(MouseEventArgs e) => Lerp(0, 0.49f, e.X / (float)Width * 2f);
}