﻿namespace PaintProgram.Shapes.NGons;

public partial class NGonShape : Shape
{
    protected virtual int NumSides { get; } = 10;
    protected double Offset = 0.62;    // 10
    //protected double Offset = 0.38;    // 8
    //protected double Offset = 0.22;    // 7
    //protected double Offset = 0.0;    // 6
    //protected double Offset = 0.940;    // 5

    protected NGonGenerator nGonGenerator;

    public NGonShape() : base()
    {
        InitializeComponent();
        Width = Height = 300;

        nGonGenerator = new(NumSides, Offset, Gap);
    }
    protected override Point[] GetPoints() => nGonGenerator.GetPoints(Width, Height);
}
