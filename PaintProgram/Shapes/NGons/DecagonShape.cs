/* Project: Paint
 * Authors: Austin Bryan, Lucius Miller, Noah Curtis
 * Class: Foundations in App Development
 * Date: February 24th, 2024*/



namespace PaintProgram.Shapes.NGons;

public partial class DecagonShape : NGonShape
{
    protected override int NumSides => 10;
    protected override double Offset => 0.62;
}
