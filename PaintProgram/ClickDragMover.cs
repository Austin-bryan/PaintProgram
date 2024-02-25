/* Project: Paint
 * Authors: Austin Bryan, Lucius Miller, Noah Curtis
 * Class: Foundations in App Development
 * Date: February 24th, 2024
 */

namespace PaintProgram;

// Purpose: A form with this object can forward its mouse events to automatically be able to be dragged and moved
// This is used 3x. 
public class ClickDragMover
{
    private bool isMoving;
    private Point moveStart;

    public void OnMouseDown(MouseEventArgs e) => (isMoving, moveStart) = (true, e.Location);
    public Point? OnMouseMove(Point Location, MouseEventArgs e, MainForm mainform, bool shouldClamp = false)
    {
        if (!isMoving)
            return null;

        var (deltaX, deltaY) = GetDelta(moveStart);

        int newX = Location.X + deltaX;
        int newY = Location.Y + deltaY;

        if (shouldClamp)
            newY = Math.Max(newY, mainform.TitleBarHeight);
        
        return new Point(newX, newY);

        // Local Functions //
        (int, int) GetDelta(Point point) => (e.X - point.X, e.Y - point.Y);
    }
    public void OnMouseUp(MouseEventArgs e) => isMoving = false;
}
