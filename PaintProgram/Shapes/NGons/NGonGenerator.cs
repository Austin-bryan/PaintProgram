namespace PaintProgram.Shapes.NGons;

public class NGonGenerator
{
    private int numSides, gap; 
    private double offset;

    public NGonGenerator(int numSides, double offset, int gap) => (this.numSides, this.offset, this.gap) = (numSides, offset, gap);

    public Point[] GetPoints(int width, int height, float? nullableAlpha = null)
    {
        Point[] points = new Point[numSides];

        for (int i = 0; i < numSides; i++)
        {
            double angle = 2 * Math.PI * i / numSides;

            int x = (int)(width / 2 + ((width / 2 - gap + 5) * Math.Cos(angle + offset)));
            int y = (int)(height / 2 + ((height / 2 - gap + 5) * Math.Sin(angle + offset)));

            if (nullableAlpha is float alpha && i % 2 == 0)
            {
                x = (int)Lerp(x, width / 2, alpha);
                y = (int)Lerp(y, height / 2, alpha);
            }

            points[i] = new Point(x, y);
        }

        return points;
    }

    private static float Lerp(float start, float end, float t) => start + t * (end - start);
}