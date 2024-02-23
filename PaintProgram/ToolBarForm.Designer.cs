using static PaintProgram.ShapeButton;

namespace PaintProgram
{
    partial class ToolBarForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ToolBarForm));
            buttonPanel = new FlowLayoutPanel();
            rectangle = new ShapeButton();
            shapeButton2 = new ShapeButton();
            shapeButton3 = new ShapeButton();
            shapeButton4 = new ShapeButton();
            shapeButton5 = new ShapeButton();
            shapeButton6 = new ShapeButton();
            shapeButton7 = new ShapeButton();
            shapeButton8 = new ShapeButton();
            shapeButton9 = new ShapeButton();
            shapeButton10 = new ShapeButton();
            shapeButton11 = new ShapeButton();
            shapeButton12 = new ShapeButton();
            shapeButton13 = new ShapeButton();
            shapeButton14 = new ShapeButton();
            pictureBox1 = new PictureBox();
            shapeButton1 = new ShapeButton();
            brushButton2 = new BrushButton();
            brushButton3 = new BrushButton();
            brushButton4 = new BrushButton();
            brushButton1 = new BrushButton();
            buttonPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // buttonPanel
            // 
            buttonPanel.BackColor = Color.FromArgb(80, 80, 80);
            buttonPanel.BorderStyle = BorderStyle.Fixed3D;
            buttonPanel.Controls.Add(rectangle);
            buttonPanel.Controls.Add(shapeButton2);
            buttonPanel.Controls.Add(shapeButton3);
            buttonPanel.Controls.Add(shapeButton4);
            buttonPanel.Controls.Add(shapeButton5);
            buttonPanel.Controls.Add(shapeButton6);
            buttonPanel.Controls.Add(shapeButton7);
            buttonPanel.Controls.Add(shapeButton8);
            buttonPanel.Controls.Add(shapeButton9);
            buttonPanel.Controls.Add(shapeButton10);
            buttonPanel.Controls.Add(shapeButton11);
            buttonPanel.Controls.Add(shapeButton12);
            buttonPanel.Controls.Add(shapeButton13);
            buttonPanel.Controls.Add(shapeButton14);
            buttonPanel.Controls.Add(pictureBox1);
            buttonPanel.Controls.Add(shapeButton1);
            buttonPanel.Controls.Add(brushButton1);
            buttonPanel.Controls.Add(brushButton2);
            buttonPanel.Controls.Add(brushButton3);
            buttonPanel.Controls.Add(brushButton4);
            buttonPanel.Location = new Point(2, 0);
            buttonPanel.Name = "buttonPanel";
            buttonPanel.Size = new Size(115, 606);
            buttonPanel.TabIndex = 1;
            // 
            // rectangle
            // 
            rectangle.Form1Instance = null;
            rectangle.Image = (Image)resources.GetObject("rectangle.Image");
            rectangle.Location = new Point(3, 3);
            rectangle.Name = "rectangle";
            rectangle.Shape = EShape.Rectangle;
            rectangle.Size = new Size(48, 49);
            rectangle.TabIndex = 0;
            rectangle.Load += rectangle_Load;
            // 
            // shapeButton2
            // 
            shapeButton2.Form1Instance = null;
            shapeButton2.Image = (Image)resources.GetObject("shapeButton2.Image");
            shapeButton2.Location = new Point(57, 3);
            shapeButton2.Name = "shapeButton2";
            shapeButton2.Shape = EShape.Triangle;
            shapeButton2.Size = new Size(48, 49);
            shapeButton2.TabIndex = 1;
            // 
            // shapeButton3
            // 
            shapeButton3.Form1Instance = null;
            shapeButton3.Image = (Image)resources.GetObject("shapeButton3.Image");
            shapeButton3.Location = new Point(3, 58);
            shapeButton3.Name = "shapeButton3";
            shapeButton3.Shape = EShape.Ellipse;
            shapeButton3.Size = new Size(48, 49);
            shapeButton3.TabIndex = 2;
            shapeButton3.Load += shapeButton3_Load;
            // 
            // shapeButton4
            // 
            shapeButton4.Form1Instance = null;
            shapeButton4.Image = (Image)resources.GetObject("shapeButton4.Image");
            shapeButton4.Location = new Point(57, 58);
            shapeButton4.Name = "shapeButton4";
            shapeButton4.Shape = EShape.Cross;
            shapeButton4.Size = new Size(48, 49);
            shapeButton4.TabIndex = 3;
            shapeButton4.Load += shapeButton4_Load;
            // 
            // shapeButton5
            // 
            shapeButton5.Form1Instance = null;
            shapeButton5.Image = (Image)resources.GetObject("shapeButton5.Image");
            shapeButton5.Location = new Point(3, 113);
            shapeButton5.Name = "shapeButton5";
            shapeButton5.Shape = EShape.RightTriangle;
            shapeButton5.Size = new Size(48, 49);
            shapeButton5.TabIndex = 4;
            shapeButton5.Load += shapeButton5_Load;
            // 
            // shapeButton6
            // 
            shapeButton6.Form1Instance = null;
            shapeButton6.Image = (Image)resources.GetObject("shapeButton6.Image");
            shapeButton6.Location = new Point(57, 113);
            shapeButton6.Name = "shapeButton6";
            shapeButton6.Shape = EShape.Trapazoid;
            shapeButton6.Size = new Size(48, 49);
            shapeButton6.TabIndex = 5;
            shapeButton6.Load += shapeButton6_Load;
            // 
            // shapeButton7
            // 
            shapeButton7.Form1Instance = null;
            shapeButton7.Image = (Image)resources.GetObject("shapeButton7.Image");
            shapeButton7.Location = new Point(3, 168);
            shapeButton7.Name = "shapeButton7";
            shapeButton7.Shape = EShape.Star4;
            shapeButton7.Size = new Size(48, 49);
            shapeButton7.TabIndex = 6;
            shapeButton7.Load += shapeButton7_Load;
            // 
            // shapeButton8
            // 
            shapeButton8.Form1Instance = null;
            shapeButton8.Image = (Image)resources.GetObject("shapeButton8.Image");
            shapeButton8.Location = new Point(57, 168);
            shapeButton8.Name = "shapeButton8";
            shapeButton8.Shape = EShape.Star5;
            shapeButton8.Size = new Size(48, 49);
            shapeButton8.TabIndex = 7;
            shapeButton8.Load += shapeButton8_Load;
            // 
            // shapeButton9
            // 
            shapeButton9.Form1Instance = null;
            shapeButton9.Image = (Image)resources.GetObject("shapeButton9.Image");
            shapeButton9.Location = new Point(3, 223);
            shapeButton9.Name = "shapeButton9";
            shapeButton9.Shape = EShape.Star6;
            shapeButton9.Size = new Size(48, 49);
            shapeButton9.TabIndex = 8;
            shapeButton9.Load += shapeButton9_Load;
            // 
            // shapeButton10
            // 
            shapeButton10.Form1Instance = null;
            shapeButton10.Image = (Image)resources.GetObject("shapeButton10.Image");
            shapeButton10.Location = new Point(57, 223);
            shapeButton10.Name = "shapeButton10";
            shapeButton10.Shape = EShape.Arrow;
            shapeButton10.Size = new Size(48, 49);
            shapeButton10.TabIndex = 9;
            shapeButton10.Load += shapeButton10_Load;
            // 
            // shapeButton11
            // 
            shapeButton11.Form1Instance = null;
            shapeButton11.Image = (Image)resources.GetObject("shapeButton11.Image");
            shapeButton11.Location = new Point(3, 278);
            shapeButton11.Name = "shapeButton11";
            shapeButton11.Shape = EShape.Decagon;
            shapeButton11.Size = new Size(48, 49);
            shapeButton11.TabIndex = 10;
            shapeButton11.Load += shapeButton11_Load;
            // 
            // shapeButton12
            // 
            shapeButton12.Form1Instance = null;
            shapeButton12.Image = (Image)resources.GetObject("shapeButton12.Image");
            shapeButton12.Location = new Point(57, 278);
            shapeButton12.Name = "shapeButton12";
            shapeButton12.Shape = EShape.Hexagon;
            shapeButton12.Size = new Size(48, 49);
            shapeButton12.TabIndex = 11;
            shapeButton12.Load += shapeButton12_Load;
            // 
            // shapeButton13
            // 
            shapeButton13.Form1Instance = null;
            shapeButton13.Image = (Image)resources.GetObject("shapeButton13.Image");
            shapeButton13.Location = new Point(3, 333);
            shapeButton13.Name = "shapeButton13";
            shapeButton13.Shape = EShape.Octagon;
            shapeButton13.Size = new Size(48, 49);
            shapeButton13.TabIndex = 12;
            shapeButton13.Load += shapeButton13_Load;
            // 
            // shapeButton14
            // 
            shapeButton14.Form1Instance = null;
            shapeButton14.Image = (Image)resources.GetObject("shapeButton14.Image");
            shapeButton14.Location = new Point(57, 333);
            shapeButton14.Name = "shapeButton14";
            shapeButton14.Shape = EShape.Pentagon;
            shapeButton14.Size = new Size(48, 49);
            shapeButton14.TabIndex = 13;
            shapeButton14.Load += shapeButton14_Load;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.FromArgb(45, 45, 45);
            pictureBox1.Location = new Point(3, 388);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(112, 1);
            pictureBox1.TabIndex = 14;
            pictureBox1.TabStop = false;
            // 
            // shapeButton1
            // 
            shapeButton1.Form1Instance = null;
            shapeButton1.Image = (Image)resources.GetObject("shapeButton1.Image");
            shapeButton1.Location = new Point(3, 395);
            shapeButton1.Name = "shapeButton1";
            shapeButton1.Shape = EShape.Octagon;
            shapeButton1.Size = new Size(0, 0);
            shapeButton1.TabIndex = 15;
            // 
            // brushButton2
            // 
            brushButton2.Form1Instance = null;
            brushButton2.Image = null;
            brushButton2.Location = new Point(3, 449);
            brushButton2.Name = "brushButton2";
            brushButton2.Size = new Size(48, 48);
            brushButton2.TabIndex = 16;
            // 
            // brushButton3
            // 
            brushButton3.Form1Instance = null;
            brushButton3.Image = null;
            brushButton3.Location = new Point(57, 449);
            brushButton3.Name = "brushButton3";
            brushButton3.Size = new Size(48, 48);
            brushButton3.TabIndex = 17;
            // 
            // brushButton4
            // 
            brushButton4.Form1Instance = null;
            brushButton4.Image = null;
            brushButton4.Location = new Point(3, 503);
            brushButton4.Name = "brushButton4";
            brushButton4.Size = new Size(48, 48);
            brushButton4.TabIndex = 18;
            // 
            // brushButton1
            // 
            brushButton1.Form1Instance = null;
            brushButton1.Image = null;
            brushButton1.Location = new Point(9, 395);
            brushButton1.Name = "brushButton1";
            brushButton1.Size = new Size(48, 48);
            brushButton1.TabIndex = 2;
            // 
            // ToolBarForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 607);
            Controls.Add(buttonPanel);
            Name = "ToolBarForm";
            Text = "ToolBarForm";
            buttonPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private FlowLayoutPanel buttonPanel;
        private ShapeButton rectangle;
        private ShapeButton shapeButton2;
        private ShapeButton shapeButton3;
        private ShapeButton shapeButton4;
        private ShapeButton shapeButton5;
        private ShapeButton shapeButton6;
        private ShapeButton shapeButton7;
        private ShapeButton shapeButton8;
        private ShapeButton shapeButton9;
        private ShapeButton shapeButton10;
        private ShapeButton shapeButton11;
        private ShapeButton shapeButton12;
        private ShapeButton shapeButton13;
        private ShapeButton shapeButton14;
        private PictureBox pictureBox1;
        private ShapeButton shapeButton1;
        private BrushButton brushButton1;
        private BrushButton brushButton2;
        private BrushButton brushButton3;
        private BrushButton brushButton4;
    }
}