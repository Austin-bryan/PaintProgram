﻿/* Project: Paint
 * Authors: Austin Bryan, Lucius Miller, Noah Curtis
 * Class: Foundations in App Development
 * Date: February 24th, 2024
 */

namespace PaintProgram.Shapes.NGons;

public partial class NGonShape : Shape
{
    protected virtual int NumSides => 10;
    protected virtual double Offset => 0.62; 

    protected NGonGenerator nGonGenerator;

    public NGonShape() : base()
    {
        InitializeComponent();
        Width = Height = 300;

        nGonGenerator = new(NumSides, Offset, Gap);
    }
    protected override Point[] GetPoints() => nGonGenerator.GetPoints(Width, Height);
}
