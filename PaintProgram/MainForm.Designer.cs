using PaintProgram.Shapes;
namespace PaintProgram;

partial class MainForm
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
        debugLabel = new Label();
        paintPanel = new Panel();
        SuspendLayout();
        // 
        // debugLabel
        // 
        debugLabel.AutoSize = true;
        debugLabel.Font = new Font("Segoe UI", 20F, FontStyle.Regular, GraphicsUnit.Point);
        debugLabel.ForeColor = SystemColors.ButtonFace;
        debugLabel.Location = new Point(29, 498);
        debugLabel.Name = "debugLabel";
        debugLabel.Size = new Size(90, 37);
        debugLabel.TabIndex = 0;
        debugLabel.Text = "label2";
        debugLabel.Visible = false;
        // 
        // paintPanel
        // 
        paintPanel.BackColor = Color.White;
        paintPanel.Location = new Point(11, 11);
        paintPanel.Margin = new Padding(2);
        paintPanel.Name = "paintPanel";
        paintPanel.Size = new Size(802, 292);
        paintPanel.TabIndex = 0;
        paintPanel.MouseDown += paintPanel_MouseDown;
        paintPanel.MouseMove += paintPanel_MouseMove;
        paintPanel.MouseUp += paintPanel_MouseUp;
        // 
        // MainForm
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = Color.FromArgb(50, 50, 50);
        ClientSize = new Size(1867, 1061);
        Controls.Add(debugLabel);
        Controls.Add(paintPanel);
        Margin = new Padding(5, 6, 5, 6);
        Name = "MainForm";
        Text = "Form1";
        Click += Form1_Click;
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion
    private RectangleShape rectangleShape1;
    private TriangleShape triangleShape1;
    private RightTriangleShape rightTriangleShape1;
    private EllipseShape ellipseShape1;
    private CrossShape crossShape1;
    private Label label1;
    private Label debugLabel;
    private Panel paintPanel;
}
