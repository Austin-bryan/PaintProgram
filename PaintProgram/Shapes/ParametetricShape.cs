﻿namespace PaintProgram.Shapes;

public partial class ParametricShape : Shape
{
    public override bool ShowAlphaBox => true;
    public List<AlphaHandle> AlphaHandles => alphaHandles.ToList(); // Returns a copy of the original to prevent public mutataion of the list

    public float Alpha { get; set; } = 0.25f;
    protected virtual float WidthAdjustment { get; }
    protected readonly List<AlphaHandle> alphaHandles = new();

    public ParametricShape() => InitializeComponent();

    public void SetAlpha(int index, float alpha) => alphaHandles[index].Alpha = alpha;
    protected override void OnPaint(PaintEventArgs e)
    {
        base.OnPaint(e);
        alphaHandles.ToList().ForEach(a => a.Draw(e));
    }
    protected override void UpdateCursor(MouseEventArgs e)
    {
        if (!IsAlphaHandleHover(e, a => Cursor = Cursors.Cross))
            base.UpdateCursor(e);
    }
    protected override void AdjustAlpha(MouseEventArgs e)
    {
        alphaHandles.Where(a => a.IsPressed).ToList().ForEach(a => a.AdjustAlpha(e));
        Refresh();
    }
    protected override void OnMouseDown(MouseEventArgs e)
    {
        if (!IsAlphaHandleHover(e, a =>
        {
            a.IsPressed = true;
            (State, moveStart) = (State.ChangingAlpha, e.Location);

        }))
            base.OnMouseDown(e);
    }
    protected override void OnMouseUp(MouseEventArgs e)
    {
        base.OnMouseUp(e);
        alphaHandles.ForEach(a => a.IsPressed = false);
    }

    protected int ShortLength(int n) => ShortLength(n, alphaHandles[0]);
    protected int LongLength(int n)  => LongLength(n, alphaHandles[0]);

    protected int ShortLength(int n, AlphaHandle alphaHandle) => (int)(n * alphaHandle.Alpha);
    protected int LongLength(int n, AlphaHandle alphaHandle)  => (int)(n * (1 - alphaHandle.Alpha));

    private bool IsAlphaHandleHover(MouseEventArgs e, Action<AlphaHandle> action)
    {
        foreach (var alphaHandle in alphaHandles)
            if (alphaHandle.IsHovered(e))
            {
                action(alphaHandle);
                return true;
            }
        return false;
    }
}//70