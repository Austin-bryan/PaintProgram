﻿/* Project: Paint
 * Authors: Austin Bryan, Lucius Miller, Noah Curtis
 * Class: Foundations in App Development
 * Date: February 24th, 2024*/





namespace PaintProgram.Shapes;

public partial class Star5Points : StarShape
{
    protected override int NumSides          => 10;
    protected override int AlphaPointIndex   => 6;
    protected override double Offset         => 0.32;
    protected override float StartAlpha      => 0.61f;
    protected override float WidthAdjustment => -3.5f;

    public Star5Points() : base() => InitializeComponent();
}