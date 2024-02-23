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
            brushButton1 = new BrushButton();
            brushButton2 = new BrushButton();
            brushButton3 = new BrushButton();
            brushButton4 = new BrushButton();
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
            buttonPanel.Location = new Point(1, 0);
            buttonPanel.Margin = new Padding(2);
            buttonPanel.Name = "buttonPanel";
            buttonPanel.Size = new Size(82, 365);
            buttonPanel.TabIndex = 1;
            // 
            // rectangle
            // 
            rectangle.Form1Instance = null;
            rectangle.Image = (Image)resources.GetObject("rectangle.Image");
            rectangle.Location = new Point(1, 1);
            rectangle.Margin = new Padding(1, 1, 1, 1);
            rectangle.Name = "rectangle";
            rectangle.Shape = EShape.Rectangle;
            rectangle.Size = new Size(30, 30);
            rectangle.TabIndex = 0;
            // 
            // shapeButton2
            // 
            shapeButton2.Form1Instance = null;
            shapeButton2.Image = (Image)resources.GetObject("shapeButton2.Image");
            shapeButton2.Location = new Point(33, 1);
            shapeButton2.Margin = new Padding(1, 1, 1, 1);
            shapeButton2.Name = "shapeButton2";
            shapeButton2.Shape = EShape.Triangle;
            shapeButton2.Size = new Size(30, 30);
            shapeButton2.TabIndex = 1;
            // 
            // shapeButton3
            // 
            shapeButton3.Form1Instance = null;
            shapeButton3.Image = (Image)resources.GetObject("shapeButton3.Image");
            shapeButton3.Location = new Point(1, 33);
            shapeButton3.Margin = new Padding(1, 1, 1, 1);
            shapeButton3.Name = "shapeButton3";
            shapeButton3.Shape = EShape.Ellipse;
            shapeButton3.Size = new Size(30, 30);
            shapeButton3.TabIndex = 2;
            // 
            // shapeButton4
            // 
            shapeButton4.Form1Instance = null;
            shapeButton4.Image = (Image)resources.GetObject("shapeButton4.Image");
            shapeButton4.Location = new Point(33, 33);
            shapeButton4.Margin = new Padding(1, 1, 1, 1);
            shapeButton4.Name = "shapeButton4";
            shapeButton4.Shape = EShape.Cross;
            shapeButton4.Size = new Size(30, 30);
            shapeButton4.TabIndex = 3;
            // 
            // shapeButton5
            // 
            shapeButton5.Form1Instance = null;
            shapeButton5.Image = (Image)resources.GetObject("shapeButton5.Image");
            shapeButton5.Location = new Point(1, 65);
            shapeButton5.Margin = new Padding(1, 1, 1, 1);
            shapeButton5.Name = "shapeButton5";
            shapeButton5.Shape = EShape.RightTriangle;
            shapeButton5.Size = new Size(30, 30);
            shapeButton5.TabIndex = 4;
            // 
            // shapeButton6
            // 
            shapeButton6.Form1Instance = null;
            shapeButton6.Image = (Image)resources.GetObject("shapeButton6.Image");
            shapeButton6.Location = new Point(33, 65);
            shapeButton6.Margin = new Padding(1, 1, 1, 1);
            shapeButton6.Name = "shapeButton6";
            shapeButton6.Shape = EShape.Trapazoid;
            shapeButton6.Size = new Size(30, 30);
            shapeButton6.TabIndex = 5;
            // 
            // shapeButton7
            // 
            shapeButton7.Form1Instance = null;
            shapeButton7.Image = (Image)resources.GetObject("shapeButton7.Image");
            shapeButton7.Location = new Point(1, 97);
            shapeButton7.Margin = new Padding(1, 1, 1, 1);
            shapeButton7.Name = "shapeButton7";
            shapeButton7.Shape = EShape.Star4;
            shapeButton7.Size = new Size(30, 30);
            shapeButton7.TabIndex = 6;
            // 
            // shapeButton8
            // 
            shapeButton8.Form1Instance = null;
            shapeButton8.Image = (Image)resources.GetObject("shapeButton8.Image");
            shapeButton8.Location = new Point(33, 97);
            shapeButton8.Margin = new Padding(1, 1, 1, 1);
            shapeButton8.Name = "shapeButton8";
            shapeButton8.Shape = EShape.Star5;
            shapeButton8.Size = new Size(30, 30);
            shapeButton8.TabIndex = 7;
            // 
            // shapeButton9
            // 
            shapeButton9.Form1Instance = null;
            shapeButton9.Image = (Image)resources.GetObject("shapeButton9.Image");
            shapeButton9.Location = new Point(1, 129);
            shapeButton9.Margin = new Padding(1, 1, 1, 1);
            shapeButton9.Name = "shapeButton9";
            shapeButton9.Shape = EShape.Star6;
            shapeButton9.Size = new Size(30, 30);
            shapeButton9.TabIndex = 8;
            // 
            // shapeButton10
            // 
            shapeButton10.Form1Instance = null;
            shapeButton10.Image = (Image)resources.GetObject("shapeButton10.Image");
            shapeButton10.Location = new Point(33, 129);
            shapeButton10.Margin = new Padding(1, 1, 1, 1);
            shapeButton10.Name = "shapeButton10";
            shapeButton10.Shape = EShape.Arrow;
            shapeButton10.Size = new Size(30, 30);
            shapeButton10.TabIndex = 9;
            // 
            // shapeButton11
            // 
            shapeButton11.Form1Instance = null;
            shapeButton11.Image = (Image)resources.GetObject("shapeButton11.Image");
            shapeButton11.Location = new Point(1, 161);
            shapeButton11.Margin = new Padding(1, 1, 1, 1);
            shapeButton11.Name = "shapeButton11";
            shapeButton11.Shape = EShape.Decagon;
            shapeButton11.Size = new Size(30, 30);
            shapeButton11.TabIndex = 10;
            // 
            // shapeButton12
            // 
            shapeButton12.Form1Instance = null;
            shapeButton12.Image = (Image)resources.GetObject("shapeButton12.Image");
            shapeButton12.Location = new Point(33, 161);
            shapeButton12.Margin = new Padding(1, 1, 1, 1);
            shapeButton12.Name = "shapeButton12";
            shapeButton12.Shape = EShape.Hexagon;
            shapeButton12.Size = new Size(30, 30);
            shapeButton12.TabIndex = 11;
            // 
            // shapeButton13
            // 
            shapeButton13.Form1Instance = null;
            shapeButton13.Image = (Image)resources.GetObject("shapeButton13.Image");
            shapeButton13.Location = new Point(1, 193);
            shapeButton13.Margin = new Padding(1, 1, 1, 1);
            shapeButton13.Name = "shapeButton13";
            shapeButton13.Shape = EShape.Octagon;
            shapeButton13.Size = new Size(30, 30);
            shapeButton13.TabIndex = 12;
            // 
            // shapeButton14
            // 
            shapeButton14.Form1Instance = null;
            shapeButton14.Image = (Image)resources.GetObject("shapeButton14.Image");
            shapeButton14.Location = new Point(33, 193);
            shapeButton14.Margin = new Padding(1, 1, 1, 1);
            shapeButton14.Name = "shapeButton14";
            shapeButton14.Shape = EShape.Pentagon;
            shapeButton14.Size = new Size(30, 30);
            shapeButton14.TabIndex = 13;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.FromArgb(45, 45, 45);
            pictureBox1.Location = new Point(2, 226);
            pictureBox1.Margin = new Padding(2);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(78, 1);
            pictureBox1.TabIndex = 14;
            pictureBox1.TabStop = false;
            // 
            // shapeButton1
            // 
            shapeButton1.Form1Instance = null;
            shapeButton1.Image = (Image)resources.GetObject("shapeButton1.Image");
            shapeButton1.Location = new Point(1, 230);
            shapeButton1.Margin = new Padding(1, 1, 1, 1);
            shapeButton1.Name = "shapeButton1";
            shapeButton1.Shape = EShape.Octagon;
            shapeButton1.Size = new Size(0, 0);
            shapeButton1.TabIndex = 15;
            // 
            // brushButton1
            // 
            brushButton1.Form1Instance = null;
            brushButton1.Image = null;
            brushButton1.Location = new Point(3, 230);
            brushButton1.Margin = new Padding(1, 1, 1, 1);
            brushButton1.Name = "brushButton1";
            brushButton1.Size = new Size(30, 30);
            brushButton1.TabIndex = 2;
            // 
            // brushButton2
            // 
            brushButton2.Form1Instance = null;
            brushButton2.Image = null;
            brushButton2.Location = new Point(35, 230);
            brushButton2.Margin = new Padding(1, 1, 1, 1);
            brushButton2.Name = "brushButton2";
            brushButton2.Size = new Size(30, 30);
            brushButton2.TabIndex = 16;
            // 
            // brushButton3
            // 
            brushButton3.Form1Instance = null;
            brushButton3.Image = null;
            brushButton3.Location = new Point(1, 262);
            brushButton3.Margin = new Padding(1, 1, 1, 1);
            brushButton3.Name = "brushButton3";
            brushButton3.Size = new Size(30, 30);
            brushButton3.TabIndex = 17;
            // 
            // brushButton4
            // 
            brushButton4.Form1Instance = null;
            brushButton4.Image = null;
            brushButton4.Location = new Point(33, 262);
            brushButton4.Margin = new Padding(1, 1, 1, 1);
            brushButton4.Name = "brushButton4";
            brushButton4.Size = new Size(30, 30);
            brushButton4.TabIndex = 18;
            // 
            // ToolBarForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(560, 364);
            Controls.Add(buttonPanel);
            Margin = new Padding(2);
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