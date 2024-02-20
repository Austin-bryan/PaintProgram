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
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)colorWheelPictureBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)valueSliderPictureBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)colorPreviewPictureBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // colorWheelPictureBox
            // 
            colorWheelPictureBox.BackColor = Color.Transparent;
            colorWheelPictureBox.Location = new Point(25, 37);
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
            valueSliderPictureBox.Location = new Point(252, 47);
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
            colorPreviewPictureBox.Location = new Point(273, 47);
            colorPreviewPictureBox.Name = "colorPreviewPictureBox";
            colorPreviewPictureBox.Size = new Size(50, 50);
            colorPreviewPictureBox.TabIndex = 4;
            colorPreviewPictureBox.TabStop = false;
            colorPreviewPictureBox.Paint += colorPreviewPictureBox_Paint;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.FromArgb(40, 40, 40);
            pictureBox1.Location = new Point(0, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(342, 450);
            pictureBox1.TabIndex = 5;
            pictureBox1.TabStop = false;
            // 
            // Stupid
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(343, 450);
            Controls.Add(colorPreviewPictureBox);
            Controls.Add(valueSliderPictureBox);
            Controls.Add(colorWheelPictureBox);
            Controls.Add(pictureBox1);
            Name = "Stupid";
            Text = "Stupid";
            ((System.ComponentModel.ISupportInitialize)colorWheelPictureBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)valueSliderPictureBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)colorPreviewPictureBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private PictureBox colorWheelPictureBox;
        private PictureBox valueSliderPictureBox;
        private PictureBox colorPreviewPictureBox;
        private PictureBox pictureBox1;
    }
}