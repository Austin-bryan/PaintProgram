

namespace PaintProgram.Shapes;

public partial class ChevronShape : ParametricShape
{
    public ChevronShape()
    {
        InitializeComponent();
        Height = Width = 300;

        alphaHandles.Add(new AlphaHandle(this, alphaPointIndex: 1, alpha: 0.35f, minAlpha: 0.04f, maxAlpha: 0.499f,
            getAlpha: (e, @this) => Lerp(@this.MinAlpha, @this.MaxAlpha, e.X / (float)Width / @this.MaxAlpha)));
        alphaHandles.Add(new AlphaHandle(this, alphaPointIndex: 3, alpha: 0.35f, minAlpha: 0.04f, maxAlpha: 0.499f,
            getAlpha: (e, @this) => Lerp(@this.MinAlpha, @this.MaxAlpha, @this.MaxAlpha - (e.X - Width / 2) / (float)Width / @this.MaxAlpha)));
    }

    protected override void OnAlphaChange()
    {
        alphaHandles[0].MaxAlpha = 1.0f - alphaHandles[1].Alpha;
        alphaHandles[1].MaxAlpha = 1.0f - alphaHandles[0].Alpha;
    }
    protected override Point[] GetPoints()
    {
        var tempPoints = new Point[]
        {
            new (Gap, Gap),
            new (ShortLength(Width, 0), Gap),
            new (Width / 2, Height / 2),
            new (LongLength(Width, 1), Gap),
            new (Width - Gap, Gap),
            new (Width / 2, Height - Gap)
        };

        Point p1 = new(Width / 2 + ShortLength(Width, 0) / 2 - 5, LongLength(Height, 0));
        Point p2 = new(Width / 2 - ShortLength(Width, 1) / 2 + 5, LongLength(Height, 1));
        Point p0 = GetIntersection(tempPoints[1], p1, tempPoints[3], p2) ?? Point.Empty;

        tempPoints[2] = p0;
        return tempPoints;
    }

    private static Point? GetIntersection(Point p1, Point p2, Point p3, Point p4)
    {
        int dx1 = p2.X - p1.X;
        int dy1 = p2.Y - p1.Y;
        int dx2 = p4.X - p3.X;
        int dy2 = p4.Y - p3.Y;

        double m1 = dy1 != 0 ? (double)dy1 / dx1 : double.PositiveInfinity;
        double m2 = dy2 != 0 ? (double)dy2 / dx2 : double.PositiveInfinity;

        if (m1 == m2)
            return null;

        double xInt = ((m1 * p1.X - m2 * p3.X) - (p1.Y - p3.Y)) / (m1 - m2);
        double yInt = m1 != double.PositiveInfinity ? m1 * (xInt - p1.X) + p1.Y : m2 * (xInt - p3.X) + p3.Y;

        if (xInt >= Math.Min(p1.X, p2.X) && xInt <= Math.Max(p1.X, p2.X) &&
            yInt >= Math.Min(p1.Y, p2.Y) && yInt <= Math.Max(p1.Y, p2.Y) &&
            xInt >= Math.Min(p3.X, p4.X) && xInt <= Math.Max(p3.X, p4.X) &&
            yInt >= Math.Min(p3.Y, p4.Y) && yInt <= Math.Max(p3.Y, p4.Y))
        {
            return new Point((int)Math.Round(xInt), (int)Math.Round(yInt));
        }

        return null;
    }
}
