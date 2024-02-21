namespace PaintProgram.Shapes;

public partial class TrapazoidShape : ParametetricShape
{
    protected override int AlphaPointIndex => 0;
    protected override float WidthAdjustment => -3f;
    public override float MaxAlpha => 0.4999f;

    public TrapazoidShape() => InitializeComponent();

    protected override Point[] GetPoints() => new Point[]
    {
        new(ShortLength(Width), Gap),
        new(LongLength(Width), Gap),
        new(Width - Gap, Height - Gap),
        new(Gap, Height - Gap)
    };
    protected override float GetAlpha(MouseEventArgs e) => Lerp(0, 0.49f, e.X / (float)Width * 2f);
    //protected override float GetAlpha(MouseEventArgs e) => (float)Math.Max(Math.Min(Lerp(0, 0.49f, e.X / (float)Width * 2f), 0.4999), 0.02f);

}