﻿
/* Project: Paint
 * Authors: Austin Bryan, Lucius Miller, Noah Curtis
 * Class: Foundations in App Development
 * Date: February 24th, 2024*/





namespace PaintProgram.Shapes;

public partial class RightTriangleShape : Shape
{
    public RightTriangleShape() => InitializeComponent();

    protected override Point[] GetPoints() => new Point[]
    {
        new(Gap, Gap),                   // Top-left corner
        new(Width - Gap, Height - Gap),  // Bottom-right corner
        new(Gap, Height - Gap)           // Bottom-left corner
    };
}
