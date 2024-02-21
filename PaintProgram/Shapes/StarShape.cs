namespace PaintProgram.Shapes;

public partial class StarShape : ParametricShape
{
    protected virtual int NumSides        { get; } = 8;
    protected virtual double Offset       { get; } = 3 * Math.PI / 4f + Math.PI;
    protected virtual float StartAlpha    { get; } = 0.25f;
    protected override int AlphaPointIndex => 6;
    
    public StarShape()
    {
        InitializeComponent();
        Alpha = StartAlpha;
    }

    protected override Point[] GetPoints()
    {
        Point[] points = new Point[NumSides];

        // Calculate the coordinates of each vertex
        for (int i = 0; i < NumSides; i++)
        {
            // Calculate the angle for each vertex
            double angle = 2 * Math.PI * i / NumSides;

            // Calculate the coordinates of the vertex
            int x = (int)(Width  / 2 + ((Width  / 2 - Gap + 5) * Math.Cos(angle + Offset))); 
            int y = (int)(Height / 2 + ((Height / 2 - Gap + 5) * Math.Sin(angle + Offset)));

            if (i % 2 == 0)
            {
                x = (int)Lerp(x, Width  / 2, Alpha);
                y = (int)Lerp(y, Height / 2, Alpha);
            }

            // Store the vertex coordinates in the points array
            points[i] = new Point(x, y);
        }

        return points;
    }
}
