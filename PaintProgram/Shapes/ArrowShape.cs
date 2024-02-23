
namespace PaintProgram.Shapes;

public partial class ArrowShape : ParametricShape
{
    public ArrowShape()
    {
        InitializeComponent();
        Height = Width = 300;

        alphaHandles.Add(new AlphaHandle(this, alphaPointIndex: 0, alpha: 0.35f, minAlpha: 0.04f, maxAlpha: 0.965f,
            getAlpha: (e, @this) => Lerp(@this.MinAlpha, @this.MaxAlpha, e.Y / (float)Height / @this.MaxAlpha)));
        alphaHandles.Add(new AlphaHandle(this, alphaPointIndex: 3, alpha: 0.35f, minAlpha: 0.04f, maxAlpha: 0.499f,
            getAlpha: (e, @this) => Lerp(@this.MinAlpha, @this.MaxAlpha, 1.0f - (e.X - Width / 2) / (float)Width / @this.MaxAlpha)));
    }
    protected override Point[] GetPoints() => new Point[]
    {
        new (Gap, ShortLength(Height)),
        new (Width / 2, Gap),
        new (Width - Gap, ShortLength(Height)),
        new (LongLength(Width, 1), ShortLength(Height)),
        new (LongLength(Width, 1), Height - Gap),
        new (ShortLength(Width, 1), Height - Gap),
        new (ShortLength(Width, 1), ShortLength(Height)),
    };
}
