
/* Project: Paint
 * Authors: Noah Curtis, Austin Bryan, Lucius Miller
 * Class: Foundations in App Development
 * Date: February 24th, 2024*/






namespace PaintProgram.Shapes;

public partial class DoubleArrowShape : ParametricShape
{
    public DoubleArrowShape()
    {
        InitializeComponent();
        Height = 200;
        Width = 300;

        alphaHandles.Add(new AlphaHandle(this, alphaPointIndex: 1, alpha: 0.35f, minAlpha: 0.04f, maxAlpha: 0.499f,
            getAlpha: (e, @this) => Lerp(@this.MinAlpha, @this.MaxAlpha, e.X / (float)Width / @this.MaxAlpha)));
        alphaHandles.Add(new AlphaHandle(this, alphaPointIndex: 3, alpha: 0.35f, minAlpha: 0.04f, maxAlpha: 0.499f,
            getAlpha: (e, @this) => Lerp(@this.MinAlpha, @this.MaxAlpha, e.Y / (float)Height / @this.MaxAlpha)));
    }
    protected override Point[] GetPoints() => new Point[]
    {
        new (Gap, Height / 2),
        new (ShortLength(Width, 0), Gap),
        new (ShortLength(Width, 0), ShortLength(Height, 1)),
        new (LongLength(Width, 0), ShortLength(Height, 1)),
        new (LongLength(Width, 0), Gap),

        new (Width - Gap, Height / 2),
        new (LongLength(Width, 0), Height - Gap),
        new (LongLength(Width, 0), LongLength(Height, 1)),
        new (ShortLength(Width, 0), LongLength(Height, 1)),
        new (ShortLength(Width, 0), Height - Gap),
    };
}
