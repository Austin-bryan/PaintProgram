
namespace PaintProgram;

public class ClickDragMover
{
    private bool isMoving;
    private Point moveStart;

    //public void ShowCursorDefault() => Cursor = Cursors.Default;
    //public void ShowCursorDrag() => Cursor = Cursors.SizeAll;

    public void OnMouseDown(MouseEventArgs e)
    {
        isMoving = true;
        moveStart = e.Location;
    }
    public Point? OnMouseMove(Point Location, MouseEventArgs e, bool shouldClamp = false)
    {
        if (!isMoving)
            return null;

        var (deltaX, deltaY) = GetDelta(moveStart);

        int newX = Location.X + deltaX;
        int newY = Location.Y + deltaY;

        if (shouldClamp)
            newY = Math.Max(newY, 40);
        
        return new Point(newX, newY);

        (int, int) GetDelta(Point point) => (e.X - point.X, e.Y - point.Y);
    }
    public void OnMouseUp(MouseEventArgs e)
    {
        isMoving = false;
    }
}
