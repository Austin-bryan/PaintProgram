using PaintProgram.Shapes;
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
        toolBar1 = new ToolBar();
        SuspendLayout();
        // 
        // toolBar1
        // 
        toolBar1.BackColor = Color.FromArgb(64, 64, 64);
        toolBar1.Location = new Point(0, 50);
        toolBar1.Name = "toolBar1";
        toolBar1.Size = new Size(129, 897);
        toolBar1.TabIndex = 0;
        // 
        // Form1
        // 
        AutoScaleDimensions = new SizeF(10F, 25F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = Color.FromArgb(50, 50, 50);
        ClientSize = new Size(1556, 943);
        Controls.Add(toolBar1);
        Margin = new Padding(4, 5, 4, 5);
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
    private ToolBar toolBar1;
}
