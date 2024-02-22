namespace PaintProgram.Shapes;

public partial class TrapazoidShape : ParametricShape
{
    public TrapazoidShape()
    {
        InitializeComponent();

        alphaHandles.Add(new AlphaHandle(this, alphaPointIndex: 0, alpha: 0.35f, minAlpha: 0.04f, maxAlpha: 0.4999f,
            getAlpha: (e, @this) => Lerp(@this.MinAlpha, @this.MaxAlpha, e.X / (float)Width * 2)));
    }

    protected override Point[] GetPoints() => new Point[]
    {
        new(ShortLength(Width), Gap),
        new(LongLength(Width), Gap),
        new(Width - Gap, Height - Gap),
        new(Gap, Height - Gap)
    };
}