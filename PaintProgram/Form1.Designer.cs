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
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
        titleBarImage = new PictureBox();
        exitButton = new Button();
        minimizeButton = new Button();
        titleLabel = new Label();
        pictureBox1 = new PictureBox();
        ((System.ComponentModel.ISupportInitialize)titleBarImage).BeginInit();
        ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
        SuspendLayout();
        // 
        // titleBarImage
        // 
        titleBarImage.BackColor = SystemColors.Control;
        titleBarImage.Location = new Point(0, 0);
        titleBarImage.Name = "titleBarImage";
        titleBarImage.Size = new Size(601, 34);
        titleBarImage.TabIndex = 0;
        titleBarImage.TabStop = false;
        titleBarImage.Visible = false;
        // 
        // exitButton
        // 
        exitButton.BackColor = SystemColors.Control;
        exitButton.FlatAppearance.BorderSize = 0;
        exitButton.FlatStyle = FlatStyle.Flat;
        exitButton.Font = new Font("Consolas", 15F, FontStyle.Regular, GraphicsUnit.Point);
        exitButton.ImageAlign = ContentAlignment.TopCenter;
        exitButton.Location = new Point(567, 0);
        exitButton.Name = "exitButton";
        exitButton.Size = new Size(34, 34);
        exitButton.TabIndex = 1;
        exitButton.Text = "x";
        exitButton.UseVisualStyleBackColor = false;
        exitButton.Visible = false;
        exitButton.Click += exitButton_Click;
        exitButton.MouseLeave += exitButton_MouseLeave;
        exitButton.MouseHover += exitButton_MouseHover;
        // 
        // minimizeButton
        // 
        minimizeButton.BackColor = SystemColors.Control;
        minimizeButton.FlatAppearance.BorderSize = 0;
        minimizeButton.FlatStyle = FlatStyle.Flat;
        minimizeButton.Font = new Font("Consolas", 15F, FontStyle.Regular, GraphicsUnit.Point);
        minimizeButton.ImageAlign = ContentAlignment.TopCenter;
        minimizeButton.Location = new Point(530, 0);
        minimizeButton.Name = "minimizeButton";
        minimizeButton.Size = new Size(34, 34);
        minimizeButton.TabIndex = 2;
        minimizeButton.Text = "-";
        minimizeButton.UseVisualStyleBackColor = false;
        minimizeButton.Visible = false;
        minimizeButton.Click += minimizeButton_Click;
        // 
        // titleLabel
        // 
        titleLabel.AutoSize = true;
        titleLabel.BackColor = SystemColors.Control;
        titleLabel.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
        titleLabel.Location = new Point(35, 9);
        titleLabel.Name = "titleLabel";
        titleLabel.Size = new Size(83, 15);
        titleLabel.TabIndex = 3;
        titleLabel.Text = "Paint Program";
        titleLabel.Visible = false;
        // 
        // pictureBox1
        // 
        pictureBox1.BackColor = SystemColors.Control;
        pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
        pictureBox1.InitialImage = (Image)resources.GetObject("pictureBox1.InitialImage");
        pictureBox1.Location = new Point(5, 5);
        pictureBox1.Name = "pictureBox1";
        pictureBox1.Size = new Size(25, 25);
        pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
        pictureBox1.TabIndex = 4;
        pictureBox1.TabStop = false;
        pictureBox1.Visible = false;
        // 
        // Form1
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = SystemColors.ActiveCaption;
        ClientSize = new Size(1089, 566);
        Controls.Add(pictureBox1);
        Controls.Add(titleLabel);
        Controls.Add(minimizeButton);
        Controls.Add(exitButton);
        Controls.Add(titleBarImage);
        Name = "Form1";
        Text = "Form1";
        Click += Form1_Click;
        ((System.ComponentModel.ISupportInitialize)titleBarImage).EndInit();
        ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion
    private RectangleShape rectangleShape1;
    private TriangleShape triangleShape1;
    private RightTriangleShape rightTriangleShape1;
    private EllipseShape ellipseShape1;
    private CrossShape crossShape1;
    private PictureBox titleBarImage;
    private Button exitButton;
    private Button minimizeButton;
    private Label titleLabel;
    private PictureBox pictureBox1;
}
