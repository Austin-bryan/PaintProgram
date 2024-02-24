namespace PaintProgram
{
    partial class TitleBar
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TitleBar));
            pictureBox1 = new PictureBox();
            titleLabel = new Label();
            minimizeButton = new Button();
            exitButton = new Button();
            titleBarImage = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)titleBarImage).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = SystemColors.Control;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.InitialImage = (Image)resources.GetObject("pictureBox1.InitialImage");
            pictureBox1.Location = new Point(5, 5);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(27, 27);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 9;
            pictureBox1.TabStop = false;
            // 
            // titleLabel
            // 
            titleLabel.AutoSize = true;
            titleLabel.BackColor = Color.FromArgb(30, 30, 30);
            titleLabel.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            titleLabel.ForeColor = Color.White;
            titleLabel.Location = new Point(38, 10);
            titleLabel.Name = "titleLabel";
            titleLabel.Size = new Size(83, 15);
            titleLabel.TabIndex = 8;
            titleLabel.Text = "Paint Program";
            // 
            // minimizeButton
            // 
            minimizeButton.BackColor = Color.FromArgb(30, 30, 30);
            minimizeButton.FlatAppearance.BorderSize = 0;
            minimizeButton.FlatStyle = FlatStyle.Flat;
            minimizeButton.Font = new Font("Consolas", 15F, FontStyle.Regular, GraphicsUnit.Point);
            minimizeButton.ForeColor = Color.White;
            minimizeButton.ImageAlign = ContentAlignment.TopCenter;
            minimizeButton.Location = new Point(533, 0);
            minimizeButton.Name = "minimizeButton";
            minimizeButton.Size = new Size(30, 30);
            minimizeButton.TabIndex = 7;
            minimizeButton.Text = "-";
            minimizeButton.UseVisualStyleBackColor = false;
            minimizeButton.Click += minimizeButton_Click;
            // 
            // exitButton
            // 
            exitButton.BackColor = Color.FromArgb(30, 30, 30);
            exitButton.FlatAppearance.BorderSize = 0;
            exitButton.FlatStyle = FlatStyle.Flat;
            exitButton.Font = new Font("Consolas", 15F, FontStyle.Regular, GraphicsUnit.Point);
            exitButton.ForeColor = Color.White;
            exitButton.ImageAlign = ContentAlignment.TopCenter;
            exitButton.Location = new Point(567, 0);
            exitButton.Name = "exitButton";
            exitButton.Size = new Size(30, 30);
            exitButton.TabIndex = 6;
            exitButton.Text = "x";
            exitButton.UseVisualStyleBackColor = false;
            exitButton.Click += exitButton_Click;
            exitButton.MouseLeave += exitButton_MouseLeave;
            exitButton.MouseHover += exitButton_MouseHover;
            // 
            // titleBarImage
            // 
            titleBarImage.BackColor = Color.FromArgb(30, 30, 30);
            titleBarImage.Location = new Point(0, 0);
            titleBarImage.Name = "titleBarImage";
            titleBarImage.Size = new Size(601, 40);
            titleBarImage.TabIndex = 5;
            titleBarImage.TabStop = false;
            // 
            // TitleBar
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(pictureBox1);
            Controls.Add(titleLabel);
            Controls.Add(minimizeButton);
            Controls.Add(exitButton);
            Controls.Add(titleBarImage);
            Name = "TitleBar";
            Text = "TitleBar";
            Load += TitleBar_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)titleBarImage).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private Label titleLabel;
        private Button minimizeButton;
        private Button exitButton;
        private PictureBox titleBarImage;
    }
}