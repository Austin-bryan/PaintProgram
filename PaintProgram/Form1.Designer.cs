namespace PaintProgram
{
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
            components = new System.ComponentModel.Container();
            contextMenuStrip1 = new ContextMenuStrip(components);
            rectangleShape1 = new RectangleShape();
            triangleShape1 = new TriangleShape();
            rightTriangleShape1 = new RightTriangleShape();
            ellipseShape1 = new EllipseShape();
            crossShape1 = new CrossShape();
            SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(61, 4);
            // 
            // rectangleShape1
            // 
            rectangleShape1.BackColor = Color.Transparent;
            rectangleShape1.Location = new Point(369, 50);
            rectangleShape1.Name = "rectangleShape1";
            rectangleShape1.Size = new Size(150, 150);
            rectangleShape1.TabIndex = 1;
            // 
            // triangleShape1
            // 
            triangleShape1.BackColor = Color.Transparent;
            triangleShape1.Location = new Point(645, 270);
            triangleShape1.Name = "triangleShape1";
            triangleShape1.Size = new Size(150, 150);
            triangleShape1.TabIndex = 2;
            // 
            // rightTriangleShape1
            // 
            rightTriangleShape1.BackColor = Color.Transparent;
            rightTriangleShape1.Location = new Point(57, 65);
            rightTriangleShape1.Name = "rightTriangleShape1";
            rightTriangleShape1.Size = new Size(150, 150);
            rightTriangleShape1.TabIndex = 3;
            // 
            // ellipseShape1
            // 
            ellipseShape1.BackColor = Color.Transparent;
            ellipseShape1.Location = new Point(449, 220);
            ellipseShape1.Name = "ellipseShape1";
            ellipseShape1.Size = new Size(153, 150);
            ellipseShape1.TabIndex = 4;
            // 
            // crossShape1
            // 
            crossShape1.BackColor = Color.Transparent;
            crossShape1.Location = new Point(242, 233);
            crossShape1.Name = "crossShape1";
            crossShape1.Size = new Size(150, 150);
            crossShape1.TabIndex = 5;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(1085, 566);
            Controls.Add(crossShape1);
            Controls.Add(ellipseShape1);
            Controls.Add(rightTriangleShape1);
            Controls.Add(triangleShape1);
            Controls.Add(rectangleShape1);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
        }

        #endregion
        private ContextMenuStrip contextMenuStrip1;
        private RectangleShape rectangleShape1;
        private TriangleShape triangleShape1;
        private RightTriangleShape rightTriangleShape1;
        private EllipseShape ellipseShape1;
        private CrossShape crossShape1;
    }
}
