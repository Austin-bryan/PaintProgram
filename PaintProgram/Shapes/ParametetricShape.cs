namespace PaintProgram.Shapes;

public partial class ParametricShape : Shape
{
    public override bool ShowAlphaBox => true;
    public virtual float MinAlpha => 5.0f / Width;
    public virtual float MaxAlpha { get; } = 1f;

    public float Alpha { get; set; } = 0.25f;
    protected virtual float WidthAdjustment { get; }
    protected virtual int AlphaPointIndex { get; } = 0;
    private Rectangle[] alphaRects;
    private readonly AlphaHandle[] alphaHandles;

    public ParametricShape()
    {
        InitializeComponent();
        alphaHandles = new AlphaHandle[1];
        alphaHandles[0] = new AlphaHandle(this);
    }

    protected virtual float GetAlpha(MouseEventArgs e) => 1 - (e.X - (Width / 2)) / (float)Width * WidthAdjustment;
    
    protected override void InitializeHandles()
    {
        base.InitializeHandles();
        alphaRects = new Rectangle[1];
    }
    protected override void OnPaint(PaintEventArgs e)
    {
        Alpha = Math.Max(Alpha, MinAlpha);
        base.OnPaint(e);
        alphaHandles.ToList().ForEach(a => a.Draw(e));
    }
    protected override void UpdateCursor(MouseEventArgs e)
    {
        if (alphaRects.Length > 0 && alphaRects[0].Contains(e.Location))
            Cursor = Cursors.Cross;
        else base.UpdateCursor(e);
    }
    protected override void AdjustAlpha(MouseEventArgs e)
    {
        Alpha = Math.Clamp(GetAlpha(e), MinAlpha, MaxAlpha);
        Refresh();
    }
    protected override void OnMouseDown(MouseEventArgs e)
    {
        foreach (var alphaHandle in alphaHandles)
            if (alphaHandle.IsPressed(e))
            {
                (State, moveStart) = (State.ChangingAlpha, e.Location);
                return;
            }
        base.OnMouseDown(e);
    }

    protected int ShortLength(int n) => (int)(n * Alpha);
    protected int LongLength(int n)  => (int)(n * (1 - Alpha));
}//70