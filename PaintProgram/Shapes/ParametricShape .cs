/* Project: Paint
 * Authors: Austin Bryan, Lucius Miller, Noah Curtis
 * Class: Foundations in App Development
 * Date: February 24th, 2024
 */

namespace PaintProgram.Shapes;

/* Purpose: Gives a yellow diamond I call alpha handle that the user can click and drag to change a single parameter of the shape. 
 * The max number of alpha handles is 2, but thats mainly because I don't want to have too many text boxes for alphas,
 * And there aren't many shapes that use 3 or more alpha handles. 
 * 
 * This class mostly forwards the functions to the alpha handle class which does most the heavy lifting
 */
public partial class ParametricShape : Shape
{
    public override bool ShowAlphaBox => true;
    public List<AlphaHandle> AlphaHandles => alphaHandles.ToList(); // Returns a copy of the original to prevent public mutataion of the list

    protected readonly List<AlphaHandle> alphaHandles = new();

    public ParametricShape() => InitializeComponent();

    public void SetAlpha(int index, float alpha) => alphaHandles[index].Alpha = alpha;
    protected override void OnPaint(PaintEventArgs e)
    {
        base.OnPaint(e);
        if (ShouldShowHandles) 
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
        if (!IsAlphaHandleHover(e, alphaHandler =>
        {
            alphaHandler.IsPressed = true;
            Refresh();
            (State, moveStart) = (State.ChangingAlpha, e.Location);

        }))
            base.OnMouseDown(e);
    }
    protected override void OnMouseUp(MouseEventArgs e)
    {
        base.OnMouseUp(e);
        alphaHandles.ForEach(a => a.IsPressed = false);
    }

    protected int ShortLength(int n) => ShortLength(n, 0);
    protected int LongLength(int n)  => LongLength(n, 0);

    // Short length uses the alpha to get a distance from the left (if using width) or top (if using height)
    protected int ShortLength(int n, int alphaIndex) => (int)(n * alphaHandles[alphaIndex].Alpha);

    // Long length does something similar, but gets a point from the right (with width) or bottom (if height) that is based on the alpha
    protected int LongLength(int n, int alphaIndex)  => (int)(n * (1 - alphaHandles[alphaIndex].Alpha));

    // Returns true if one of the alpha handles is being hovered
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