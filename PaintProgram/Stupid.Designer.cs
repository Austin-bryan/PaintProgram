namespace PaintProgram
{
    partial class Stupid
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
            colorWheelPictureBox = new PictureBox();
            valueSliderPictureBox = new PictureBox();
            colorPreviewPictureBox = new PictureBox();
            colorWheelBackground = new PictureBox();
            colorWheelTab = new PictureBox();
            colorWheelTabBackground = new PictureBox();
            colorPickerLabel = new Label();
            colorWheelBoarderHider = new PictureBox();
            pictureBox1 = new PictureBox();
            label1 = new Label();
            pictureBox2 = new PictureBox();
            pictureBox3 = new PictureBox();
            pictureBox4 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)colorWheelPictureBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)valueSliderPictureBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)colorPreviewPictureBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)colorWheelBackground).BeginInit();
            ((System.ComponentModel.ISupportInitialize)colorWheelTab).BeginInit();
            ((System.ComponentModel.ISupportInitialize)colorWheelTabBackground).BeginInit();
            ((System.ComponentModel.ISupportInitialize)colorWheelBoarderHider).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).BeginInit();
            SuspendLayout();
            // 
            // colorWheelPictureBox
            // 
            colorWheelPictureBox.BackColor = Color.Transparent;
            colorWheelPictureBox.Location = new Point(25, 53);
            colorWheelPictureBox.Name = "colorWheelPictureBox";
            colorWheelPictureBox.Size = new Size(220, 220);
            colorWheelPictureBox.TabIndex = 2;
            colorWheelPictureBox.TabStop = false;
            colorWheelPictureBox.Paint += colorWheelPictureBox_Paint;
            colorWheelPictureBox.MouseDown += colorWheelPictureBox_MouseDown;
            colorWheelPictureBox.MouseEnter += colorWheelPictureBox_MouseEnter;
            colorWheelPictureBox.MouseLeave += colorWheelPictureBox_MouseLeave;
            colorWheelPictureBox.MouseMove += colorWheelPictureBox_MouseMove;
            colorWheelPictureBox.MouseUp += colorWheelPictureBox_MouseUp;
            // 
            // valueSliderPictureBox
            // 
            valueSliderPictureBox.BackColor = Color.Transparent;
            valueSliderPictureBox.Location = new Point(256, 63);
            valueSliderPictureBox.Name = "valueSliderPictureBox";
            valueSliderPictureBox.Size = new Size(15, 200);
            valueSliderPictureBox.TabIndex = 3;
            valueSliderPictureBox.TabStop = false;
            valueSliderPictureBox.Paint += valueSliderPictureBox_Paint;
            valueSliderPictureBox.MouseDown += valueSliderPictureBox_MouseDown;
            valueSliderPictureBox.MouseEnter += valueSliderPictureBox_MouseEnter;
            valueSliderPictureBox.MouseLeave += valueSliderPictureBox_MouseLeave;
            valueSliderPictureBox.MouseMove += valueSliderPictureBox_MouseMove;
            valueSliderPictureBox.MouseUp += valueSliderPictureBox_MouseUp;
            // 
            // colorPreviewPictureBox
            // 
            colorPreviewPictureBox.BackColor = Color.Red;
            colorPreviewPictureBox.Location = new Point(277, 63);
            colorPreviewPictureBox.Name = "colorPreviewPictureBox";
            colorPreviewPictureBox.Size = new Size(50, 50);
            colorPreviewPictureBox.TabIndex = 4;
            colorPreviewPictureBox.TabStop = false;
            colorPreviewPictureBox.Paint += colorPreviewPictureBox_Paint;
            // 
            // colorWheelBackground
            // 
            colorWheelBackground.BackColor = Color.FromArgb(80, 80, 80);
            colorWheelBackground.BorderStyle = BorderStyle.FixedSingle;
            colorWheelBackground.Location = new Point(0, 27);
            colorWheelBackground.Name = "colorWheelBackground";
            colorWheelBackground.Size = new Size(342, 273);
            colorWheelBackground.TabIndex = 5;
            colorWheelBackground.TabStop = false;
            // 
            // colorWheelTab
            // 
            colorWheelTab.BackColor = Color.FromArgb(80, 80, 80);
            colorWheelTab.BorderStyle = BorderStyle.FixedSingle;
            colorWheelTab.Location = new Point(0, 0);
            colorWheelTab.Name = "colorWheelTab";
            colorWheelTab.Size = new Size(100, 31);
            colorWheelTab.TabIndex = 6;
            colorWheelTab.TabStop = false;
            // 
            // colorWheelTabBackground
            // 
            colorWheelTabBackground.BackColor = Color.FromArgb(40, 40, 40);
            colorWheelTabBackground.BorderStyle = BorderStyle.FixedSingle;
            colorWheelTabBackground.Location = new Point(99, 0);
            colorWheelTabBackground.Name = "colorWheelTabBackground";
            colorWheelTabBackground.Size = new Size(243, 31);
            colorWheelTabBackground.TabIndex = 7;
            colorWheelTabBackground.TabStop = false;
            // 
            // colorPickerLabel
            // 
            colorPickerLabel.AutoSize = true;
            colorPickerLabel.BackColor = Color.FromArgb(80, 80, 80);
            colorPickerLabel.ForeColor = Color.Snow;
            colorPickerLabel.Location = new Point(12, 9);
            colorPickerLabel.Name = "colorPickerLabel";
            colorPickerLabel.Size = new Size(71, 15);
            colorPickerLabel.TabIndex = 8;
            colorPickerLabel.Text = "Color Picker";
            // 
            // colorWheelBoarderHider
            // 
            colorWheelBoarderHider.BackColor = Color.FromArgb(80, 80, 80);
            colorWheelBoarderHider.Location = new Point(1, 27);
            colorWheelBoarderHider.Name = "colorWheelBoarderHider";
            colorWheelBoarderHider.Size = new Size(340, 14);
            colorWheelBoarderHider.TabIndex = 9;
            colorWheelBoarderHider.TabStop = false;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.FromArgb(80, 80, 80);
            pictureBox1.Location = new Point(1, 327);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(340, 14);
            pictureBox1.TabIndex = 14;
            pictureBox1.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.FromArgb(80, 80, 80);
            label1.ForeColor = Color.Snow;
            label1.Location = new Point(12, 309);
            label1.Name = "label1";
            label1.Size = new Size(60, 15);
            label1.TabIndex = 13;
            label1.Text = "Properties";
            // 
            // pictureBox2
            // 
            pictureBox2.BackColor = Color.FromArgb(40, 40, 40);
            pictureBox2.BorderStyle = BorderStyle.FixedSingle;
            pictureBox2.Location = new Point(99, 300);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(243, 31);
            pictureBox2.TabIndex = 12;
            pictureBox2.TabStop = false;
            // 
            // pictureBox3
            // 
            pictureBox3.BackColor = Color.FromArgb(80, 80, 80);
            pictureBox3.BorderStyle = BorderStyle.FixedSingle;
            pictureBox3.Location = new Point(0, 300);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(100, 31);
            pictureBox3.TabIndex = 11;
            pictureBox3.TabStop = false;
            // 
            // pictureBox4
            // 
            pictureBox4.BackColor = Color.FromArgb(80, 80, 80);
            pictureBox4.BorderStyle = BorderStyle.FixedSingle;
            pictureBox4.Location = new Point(0, 327);
            pictureBox4.Name = "pictureBox4";
            pictureBox4.Size = new Size(342, 273);
            pictureBox4.TabIndex = 10;
            pictureBox4.TabStop = false;
            // 
            // Stupid
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(343, 620);
            Controls.Add(pictureBox1);
            Controls.Add(label1);
            Controls.Add(pictureBox2);
            Controls.Add(pictureBox3);
            Controls.Add(pictureBox4);
            Controls.Add(colorWheelBoarderHider);
            Controls.Add(colorPickerLabel);
            Controls.Add(colorWheelTabBackground);
            Controls.Add(colorWheelTab);
            Controls.Add(colorPreviewPictureBox);
            Controls.Add(valueSliderPictureBox);
            Controls.Add(colorWheelPictureBox);
            Controls.Add(colorWheelBackground);
            Name = "Stupid";
            Text = "Stupid";
            ((System.ComponentModel.ISupportInitialize)colorWheelPictureBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)valueSliderPictureBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)colorPreviewPictureBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)colorWheelBackground).EndInit();
            ((System.ComponentModel.ISupportInitialize)colorWheelTab).EndInit();
            ((System.ComponentModel.ISupportInitialize)colorWheelTabBackground).EndInit();
            ((System.ComponentModel.ISupportInitialize)colorWheelBoarderHider).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private PictureBox colorWheelPictureBox;
        private PictureBox valueSliderPictureBox;
        private PictureBox colorPreviewPictureBox;
        private PictureBox colorWheelBackground;
        private PictureBox colorWheelTab;
        private PictureBox colorWheelTabBackground;
        private Label colorPickerLabel;
        private PictureBox colorWheelBoarderHider;
        private PictureBox pictureBox1;
        private Label label1;
        private PictureBox pictureBox2;
        private PictureBox pictureBox3;
        private PictureBox pictureBox4;
    }
}