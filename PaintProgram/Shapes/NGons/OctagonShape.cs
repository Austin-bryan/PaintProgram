﻿/* Project: Paint
 * Authors: Noah Curtis, Austin Bryan, Lucius Miller
 * Class: Foundations in App Development
 * Date: February 24th, 2024*/



namespace PaintProgram.Shapes.NGons;

public partial class OctagonShape : NGonShape
{
    protected override int NumSides => 8;
    protected override double Offset => 0.38;
}
