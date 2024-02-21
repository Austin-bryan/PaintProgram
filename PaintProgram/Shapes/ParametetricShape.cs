namespace PaintProgram.Shapes;

public partial class ParametricShape : Shape
{
    public override bool ShowAlphaBox => true;
    public virtual float MinAlpha => 5.0f / Width;
    public virtual float MaxAlpha { get; } = 1f;

    public float Alpha { get; set; } = 0.25f;
    protected virtual float WidthAdjustment { get; }
    protected virtual int AlphaPointIndex { get; } = 0;
    private Rectangle[] alphaHandles;

    public ParametricShape() => InitializeComponent();

    protected void DrawAlphaHandle(PaintEventArgs e, int pointIndex)
    {
        if (!shouldShowHandles)
            return;

        const int diamondRadius = 5;
        Point[] diamondPoints = new Point[]
        {
            points[pointIndex].Add(new(0, -diamondRadius)),
            points[pointIndex].Add(new(diamondRadius, 0)),
            points[pointIndex].Add(new(0, diamondRadius)),
            points[pointIndex].Add(new(-diamondRadius, 0))
        };
        e.Graphics.DrawPolygon(new Pen(Color.Black, 2), diamondPoints);
        e.Graphics.FillPolygon(Brushes.Orange, diamondPoints);

        alphaHandles[0] = new Rectangle(points[pointIndex].X - diamondRadius, points[pointIndex].Y - diamondRadius, 10, 10);
    }
    protected virtual float GetAlpha(MouseEventArgs e) => 1 - (e.X - (Width / 2)) / (float)Width * WidthAdjustment;

    protected override void InitializeHandles()
    {
        base.InitializeHandles();
        alphaHandles = new Rectangle[1];
    }
    protected override void OnPaint(PaintEventArgs e)
    {
        Alpha = Math.Max(Alpha, MinAlpha);
        base.OnPaint(e);
        DrawAlphaHandle(e, AlphaPointIndex);
    }
    protected override void UpdateCursor(MouseEventArgs e)
    {
        if (alphaHandles.Length > 0 && alphaHandles[0].Contains(e.Location))
            Cursor = Cursors.Cross;
        else base.UpdateCursor(e);
    }
    protected override void AdjustAlpha(MouseEventArgs e)
    {
        Alpha = GetAlpha(e);
        Alpha = Math.Min(Alpha, MaxAlpha);
        Alpha = Math.Max(Alpha, MinAlpha);
        Refresh();
    }
    protected override void OnMouseDown(MouseEventArgs e)
    {
        if (alphaHandles.Length > 0 && alphaHandles[0].Contains(e.Location))
        {
            State = State.ChangingAlpha;
            moveStart = e.Location;
        }
        else base.OnMouseDown(e);
    }

    protected int ShortLength(int n) => (int)(n * Alpha);
    protected int LongLength(int n)  => (int)(n * (1 - Alpha));
}