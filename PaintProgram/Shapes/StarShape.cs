/* Project: Paint
 * Authors: Austin Bryan, Lucius Miller, Noah Curtis
 * Class: Foundations in App Development
 * Date: February 24th, 2024
 */

using PaintProgram.Shapes.NGons;
namespace PaintProgram.Shapes;

public partial class StarShape : ParametricShape
{
    // By declaring these values as virtual get only properties, I'm able to override a variable (even though it is a function under the hood)
    // This allows child classes to simply override these values, and the parent class will use them to create the shape
    protected virtual float MinAlpha => 5.0f / Width;
    protected virtual float MaxAlpha   { get; } = 1f;
    protected virtual float StartAlpha { get; } = 0.25f;
    protected virtual double Offset    { get; } = 3 * Math.PI / 4f + Math.PI;
    protected virtual int NumSides     { get; } = 8;

    protected virtual float WidthAdjustment { get; }
    protected virtual int AlphaPointIndex { get; } = 6;

    protected NGonGenerator nGonGenerator;
    
    public StarShape()
    {
        // Stars have been programmed as an nGon, where every other point is indented by the alpha amount to create the star effect
        // Since I also have NGons, an NGon object is used by both shapes
        InitializeComponent();
        nGonGenerator = new(NumSides, Offset, Gap);

        alphaHandles.Add(new AlphaHandle(this, AlphaPointIndex, StartAlpha, MinAlpha, MaxAlpha, (e, @this) => 1 - (e.X - (Width / 2)) / (float)Width * WidthAdjustment));
    }
    protected override Point[] GetPoints() => nGonGenerator.GetPoints(Width, Height, alphaHandles[0].Alpha);
}