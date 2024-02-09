namespace PaintProgram;

public partial class CrossShape : Shape
{
    public CrossShape()
    {
        InitializeComponent();
        Alpha = 0.25f;
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

    protected override void DrawShape(PaintEventArgs e, ref Point[] points)
    {
        e.Graphics.FillPolygon(Brushes.MediumBlue, points);

        DrawAlphaHandle(e, ref points, 0);
    }

    private int ShortLength(int n) => (int)(n * Alpha);
    private int LongLength(int n) => (int)(n * (1 - Alpha));

    protected override int GetAlphaHandleX(MouseEventArgs e) => e.X;

}
