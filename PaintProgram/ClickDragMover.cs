/* Project: Paint
 * Authors: Noah Curtis, Austin Bryan, Lucius Miller
 * Class: Foundations in App Development
 * Date: February 24th, 2024*/



namespace PaintProgram;

public class ClickDragMover
{
    private bool isMoving;
    private Point moveStart;

    public void OnMouseDown(MouseEventArgs e) => (isMoving, moveStart) = (true, e.Location);
    public Point? OnMouseMove(Point Location, MouseEventArgs e, Form1 mainform, bool shouldClamp = false)
    {
        if (!isMoving)
            return null;

        var (deltaX, deltaY) = GetDelta(moveStart);

        int newX = Location.X + deltaX;
        int newY = Location.Y + deltaY;

        if (shouldClamp)
            newY = Math.Max(newY, mainform.TitleBarHeight);
        
        return new Point(newX, newY);

        (int, int) GetDelta(Point point) => (e.X - point.X, e.Y - point.Y);
    }
    public void OnMouseUp(MouseEventArgs e) => isMoving = false;
}
