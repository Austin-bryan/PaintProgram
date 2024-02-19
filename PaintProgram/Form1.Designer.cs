﻿using PaintProgram.Shapes;
namespace PaintProgram;

partial class Form1
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        paintPanel = new Panel();
        SuspendLayout();
        // 
        // paintPanel
        // 
        paintPanel.BackColor = Color.White;
        paintPanel.Location = new Point(3, 12);
        paintPanel.Name = "paintPanel";
        paintPanel.Size = new Size(1374, 584);
        paintPanel.TabIndex = 0;
        paintPanel.MouseDown += paintPanel_MouseDown;
        paintPanel.MouseEnter += paintPanel_MouseEnter;
        paintPanel.MouseLeave += paintPanel_MouseLeave;
        paintPanel.MouseHover += paintPanel_MouseHover;
        paintPanel.MouseMove += paintPanel_MouseMove;
        paintPanel.MouseUp += paintPanel_MouseUp;
        // 
        // Form1
        // 
        AutoScaleDimensions = new SizeF(12F, 30F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = Color.FromArgb(50, 50, 50);
        ClientSize = new Size(1867, 1132);
        Controls.Add(paintPanel);
        Margin = new Padding(5, 6, 5, 6);
        Name = "Form1";
        Text = "Form1";
        Click += Form1_Click;
        ResumeLayout(false);
    }

    #endregion
    private RectangleShape rectangleShape1;
    private TriangleShape triangleShape1;
    private RightTriangleShape rightTriangleShape1;
    private EllipseShape ellipseShape1;
    private CrossShape crossShape1;
    private Label label1;
    private Panel paintPanel;
}
