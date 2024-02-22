namespace PaintProgram.Shapes;

public partial class StarShape : ParametricShape
{
    protected virtual int NumSides        { get; } = 8;
    protected virtual double Offset       { get; } = 3 * Math.PI / 4f + Math.PI;
    protected virtual float StartAlpha    { get; } = 0.25f;
    protected override int AlphaPointIndex => 6;
    protected NGonGenerator nGonGenerator;
    
    public StarShape()
    {
        InitializeComponent();
        Alpha = StartAlpha;
        nGonGenerator = new(NumSides, Offset, Gap);
        alphaHandles.Add(new AlphaHandle(this, AlphaPointIndex, Alpha, MinAlpha, MaxAlpha, e => 1 - (e.X - (Width / 2)) / (float)Width * WidthAdjustment));
    }
    protected override Point[] GetPoints() => nGonGenerator.GetPoints(Width, Height, alphaHandles[0].Alpha);
}