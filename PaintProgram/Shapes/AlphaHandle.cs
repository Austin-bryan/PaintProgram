
/* Project: Paint
 * Authors: Austin Bryan, Lucius Miller, Noah Curtis
 * Class: Foundations in App Development
 * Date: February 24th, 2024*/




using static PaintProgram.Shapes.ParametricShape;

namespace PaintProgram.Shapes;

using GetAlphaFunc = Func<MouseEventArgs, AlphaHandle, float>;

public partial class ParametricShape
{
    public class AlphaHandle
    {
        public float Alpha    { get; set; }
        public float MinAlpha { get; private set; }
        public float MaxAlpha { get; set;}
        public bool IsPressed { get; set; }
        private ParametricShape Owner;
        private readonly int pointIndex;
        private Point[] Points => Owner.points;
        private Rectangle rect;
        GetAlphaFunc GetAlpha;

        public AlphaHandle(ParametricShape parameterticShape, int alphaPointIndex, float alpha, float minAlpha, float maxAlpha, GetAlphaFunc getAlpha) => (Owner, pointIndex, Alpha, MinAlpha, MaxAlpha, GetAlpha) = (parameterticShape, alphaPointIndex, alpha, minAlpha, maxAlpha, getAlpha);

        public void Draw(PaintEventArgs e)
        {
            const int diamondRadius = 5;
            Point[] diamondPoints = new Point[]
            {
                Points[pointIndex].Add(new(0, -diamondRadius)),
                Points[pointIndex].Add(new(diamondRadius, 0)),
                Points[pointIndex].Add(new(0, diamondRadius)),
                Points[pointIndex].Add(new(-diamondRadius, 0))
            };
            e.Graphics.DrawPolygon(new Pen(Color.Black, 2), diamondPoints);
            e.Graphics.FillPolygon(Brushes.Orange, diamondPoints);

            rect = new Rectangle(Points[pointIndex].X - diamondRadius, Points[pointIndex].Y - diamondRadius, 10, 10);
        }
        public bool IsHovered(MouseEventArgs e) => rect.Contains(e.Location);
        public void AdjustAlpha(MouseEventArgs e) => Alpha = Math.Clamp(GetAlpha(e, this), MinAlpha, MaxAlpha);
    }
}