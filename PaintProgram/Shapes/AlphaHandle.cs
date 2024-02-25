/* Project: Paint
 * Authors: Austin Bryan, Lucius Miller, Noah Curtis
 * Class: Foundations in App Development
 * Date: February 24th, 2024
 */

using static PaintProgram.Shapes.ParametricShape;

namespace PaintProgram.Shapes;

using GetAlphaFunc = Func<MouseEventArgs, AlphaHandle, float>;

// Purpose: Draws the alpha handle and handles the click event for when it is pressed
// The public properties are very important, used to prevent dragging too far from messing the shape, and to prevent the 
// The user from entering user from entering invalid alpha values in text boxes
public partial class ParametricShape
{
    public class AlphaHandle
    {
        public float Alpha    { get; set; }     // Used later by the shape in the GetPoint functions
        public float MinAlpha { get; private set; }
        public float MaxAlpha { get; set;}
        public bool IsPressed { get; set; }
        
        private readonly ParametricShape Owner;
        private readonly int pointIndex;
        private readonly GetAlphaFunc GetAlpha;
        private Point[] Points => Owner.points;
        private Rectangle rect;

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