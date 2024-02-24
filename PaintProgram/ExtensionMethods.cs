
/* Project: Paint
 * Authors: Noah Curtis, Austin Bryan, Lucius Miller
 * Class: Foundations in App Development
 * Date: February 24th, 2024*/


namespace PaintProgram;

public static class ExtensionMethods
{
    public static Point Add(this Point point1, Point point2) => new(point1.X + point2.X, point1.Y + point2.Y);
    public static Point Subtract(this Point point1, Point point2) => new(point1.X - point2.X, point1.Y - point2.Y);
    public static int Abs(this int x) => Math.Abs(x);  
}
