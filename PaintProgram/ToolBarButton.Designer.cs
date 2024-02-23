namespace PaintProgram;

partial class ToolBarButton
{
    /// <summary> 
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary> 
    /// Clean up any resources being used.
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

    #region Component Designer generated code

    /// <summary> 
    /// Required method for Designer support - do not modify 
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        button1 = new Button();
        SuspendLayout();
        // 
        // button1
        // 
        button1.BackColor = Color.FromArgb(110, 110, 110);
        button1.FlatStyle = FlatStyle.Flat;
        button1.Location = new Point(0, 0);
        button1.Name = "button1";
        button1.Size = new Size(50, 50);
        button1.TabIndex = 0;
        button1.UseVisualStyleBackColor = false;
        // 
        // ShapeButton
        // 
        AutoScaleDimensions = new SizeF(10F, 25F);
        AutoScaleMode = AutoScaleMode.Font;
        Controls.Add(button1);
        Name = "ShapeButton";
        Size = new Size(50, 50);
        ResumeLayout(false);
    }

    #endregion

    private Button button1;
}
