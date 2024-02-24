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
            PictureBox background1;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ToolBarForm));
            squareBtn = new Button();
            divider1 = new PictureBox();
            divider0 = new PictureBox();
            headerBackground = new PictureBox();
            toolBarLabel = new PictureBox();
            triangleBtn = new Button();
            rightTriangleBtn = new Button();
            ellipseBtn = new Button();
            star6Btn = new Button();
            star5Btn = new Button();
            star4Btn = new Button();
            crossBtn = new Button();
            decagonBtn = new Button();
            septagonBtn = new Button();
            hexagonBtn = new Button();
            pentagonBtn = new Button();
            chevronBtn = new Button();
            doubleArrowBtn = new Button();
            arrowBtn = new Button();
            trapazoidBtn = new Button();
            inkBtn = new Button();
            sprayBtn = new Button();
            eraserBtn = new Button();
            brushBtn = new Button();
            label1 = new Label();
            cursorBtn = new Button();
            sizePixelBox = new PixelTextBox();
            sizePanel = new Panel();
            trackBar1 = new TrackBar();
            divider2 = new PictureBox();
            background2 = new PictureBox();
            flowLayoutPanel1 = new FlowLayoutPanel();
            brushToolPanel = new Panel();
            background1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)background1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)divider1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)divider0).BeginInit();
            ((System.ComponentModel.ISupportInitialize)headerBackground).BeginInit();
            ((System.ComponentModel.ISupportInitialize)toolBarLabel).BeginInit();
            sizePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)trackBar1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)divider2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)background2).BeginInit();
            brushToolPanel.SuspendLayout();
            SuspendLayout();
            // 
            // background1
            // 
            background1.BackColor = Color.FromArgb(80, 80, 80);
            background1.BorderStyle = BorderStyle.FixedSingle;
            background1.Location = new Point(0, 58);
            background1.Margin = new Padding(5, 6, 5, 6);
            background1.Name = "background1";
            background1.Size = new Size(302, 528);
            background1.TabIndex = 32;
            background1.TabStop = false;
            // 
            // squareBtn
            // 
            squareBtn.BackColor = Color.FromArgb(120, 120, 120);
            squareBtn.FlatAppearance.BorderSize = 0;
            squareBtn.FlatStyle = FlatStyle.Flat;
            squareBtn.Image = (Image)resources.GetObject("squareBtn.Image");
            squareBtn.Location = new Point(21, 84);
            squareBtn.Margin = new Padding(5, 6, 5, 6);
            squareBtn.Name = "squareBtn";
            squareBtn.Size = new Size(51, 60);
            squareBtn.TabIndex = 31;
            squareBtn.UseVisualStyleBackColor = false;
            squareBtn.Click += squareBtn_Click;
            // 
            // divider1
            // 
            divider1.BackColor = Color.FromArgb(45, 45, 45);
            divider1.Location = new Point(3, 402);
            divider1.Margin = new Padding(5, 6, 5, 6);
            divider1.Name = "divider1";
            divider1.Size = new Size(300, 2);
            divider1.TabIndex = 36;
            divider1.TabStop = false;
            // 
            // divider0
            // 
            divider0.BackColor = Color.FromArgb(80, 80, 80);
            divider0.Location = new Point(2, 58);
            divider0.Margin = new Padding(5, 6, 5, 6);
            divider0.Name = "divider0";
            divider0.Size = new Size(300, 28);
            divider0.TabIndex = 35;
            divider0.TabStop = false;
            // 
            // headerBackground
            // 
            headerBackground.BackColor = Color.FromArgb(45, 45, 45);
            headerBackground.BorderStyle = BorderStyle.FixedSingle;
            headerBackground.Location = new Point(170, 4);
            headerBackground.Margin = new Padding(5, 6, 5, 6);
            headerBackground.Name = "headerBackground";
            headerBackground.Size = new Size(132, 60);
            headerBackground.TabIndex = 34;
            headerBackground.TabStop = false;
            headerBackground.MouseDown += headerBackground_MouseDown;
            headerBackground.MouseEnter += headerBackground_MouseEnter;
            headerBackground.MouseLeave += headerBackground_MouseLeave;
            headerBackground.MouseMove += headerBackground_MouseMove;
            headerBackground.MouseUp += headerBackground_MouseUp;
            // 
            // toolBarLabel
            // 
            toolBarLabel.BackColor = Color.FromArgb(80, 80, 80);
            toolBarLabel.BorderStyle = BorderStyle.FixedSingle;
            toolBarLabel.Location = new Point(0, 4);
            toolBarLabel.Margin = new Padding(5, 6, 5, 6);
            toolBarLabel.Name = "toolBarLabel";
            toolBarLabel.Size = new Size(170, 60);
            toolBarLabel.TabIndex = 33;
            toolBarLabel.TabStop = false;
            // 
            // triangleBtn
            // 
            triangleBtn.BackColor = Color.FromArgb(120, 120, 120);
            triangleBtn.FlatAppearance.BorderSize = 0;
            triangleBtn.FlatStyle = FlatStyle.Flat;
            triangleBtn.Image = (Image)resources.GetObject("triangleBtn.Image");
            triangleBtn.Location = new Point(89, 84);
            triangleBtn.Margin = new Padding(5, 6, 5, 6);
            triangleBtn.Name = "triangleBtn";
            triangleBtn.Size = new Size(51, 60);
            triangleBtn.TabIndex = 37;
            triangleBtn.UseVisualStyleBackColor = false;
            triangleBtn.Click += triangleBtn_Click;
            // 
            // rightTriangleBtn
            // 
            rightTriangleBtn.BackColor = Color.FromArgb(120, 120, 120);
            rightTriangleBtn.FlatAppearance.BorderSize = 0;
            rightTriangleBtn.FlatStyle = FlatStyle.Flat;
            rightTriangleBtn.Image = (Image)resources.GetObject("rightTriangleBtn.Image");
            rightTriangleBtn.Location = new Point(158, 84);
            rightTriangleBtn.Margin = new Padding(5, 6, 5, 6);
            rightTriangleBtn.Name = "rightTriangleBtn";
            rightTriangleBtn.Size = new Size(51, 60);
            rightTriangleBtn.TabIndex = 38;
            rightTriangleBtn.UseVisualStyleBackColor = false;
            rightTriangleBtn.Click += rightTriangleBtn_Click;
            // 
            // ellipseBtn
            // 
            ellipseBtn.BackColor = Color.FromArgb(120, 120, 120);
            ellipseBtn.FlatAppearance.BorderSize = 0;
            ellipseBtn.FlatStyle = FlatStyle.Flat;
            ellipseBtn.Image = (Image)resources.GetObject("ellipseBtn.Image");
            ellipseBtn.Location = new Point(226, 84);
            ellipseBtn.Margin = new Padding(5, 6, 5, 6);
            ellipseBtn.Name = "ellipseBtn";
            ellipseBtn.Size = new Size(51, 60);
            ellipseBtn.TabIndex = 39;
            ellipseBtn.UseVisualStyleBackColor = false;
            ellipseBtn.Click += ellipseBtn_Click;
            // 
            // star6Btn
            // 
            star6Btn.BackColor = Color.FromArgb(120, 120, 120);
            star6Btn.FlatAppearance.BorderSize = 0;
            star6Btn.FlatStyle = FlatStyle.Flat;
            star6Btn.Image = (Image)resources.GetObject("star6Btn.Image");
            star6Btn.Location = new Point(226, 164);
            star6Btn.Margin = new Padding(5, 6, 5, 6);
            star6Btn.Name = "star6Btn";
            star6Btn.Size = new Size(51, 60);
            star6Btn.TabIndex = 43;
            star6Btn.UseVisualStyleBackColor = false;
            star6Btn.Click += star6Btn_Click;
            // 
            // star5Btn
            // 
            star5Btn.BackColor = Color.FromArgb(120, 120, 120);
            star5Btn.FlatAppearance.BorderSize = 0;
            star5Btn.FlatStyle = FlatStyle.Flat;
            star5Btn.Image = (Image)resources.GetObject("star5Btn.Image");
            star5Btn.Location = new Point(158, 164);
            star5Btn.Margin = new Padding(5, 6, 5, 6);
            star5Btn.Name = "star5Btn";
            star5Btn.Size = new Size(51, 60);
            star5Btn.TabIndex = 42;
            star5Btn.UseVisualStyleBackColor = false;
            star5Btn.Click += star5Btn_Click;
            // 
            // star4Btn
            // 
            star4Btn.BackColor = Color.FromArgb(120, 120, 120);
            star4Btn.FlatAppearance.BorderSize = 0;
            star4Btn.FlatStyle = FlatStyle.Flat;
            star4Btn.Image = (Image)resources.GetObject("star4Btn.Image");
            star4Btn.Location = new Point(89, 164);
            star4Btn.Margin = new Padding(5, 6, 5, 6);
            star4Btn.Name = "star4Btn";
            star4Btn.Size = new Size(51, 60);
            star4Btn.TabIndex = 41;
            star4Btn.UseVisualStyleBackColor = false;
            star4Btn.Click += star4Btn_Click;
            // 
            // crossBtn
            // 
            crossBtn.BackColor = Color.FromArgb(120, 120, 120);
            crossBtn.FlatAppearance.BorderSize = 0;
            crossBtn.FlatStyle = FlatStyle.Flat;
            crossBtn.Image = (Image)resources.GetObject("crossBtn.Image");
            crossBtn.Location = new Point(21, 164);
            crossBtn.Margin = new Padding(5, 6, 5, 6);
            crossBtn.Name = "crossBtn";
            crossBtn.Size = new Size(51, 60);
            crossBtn.TabIndex = 40;
            crossBtn.UseVisualStyleBackColor = false;
            crossBtn.Click += crossBtn_Click;
            // 
            // decagonBtn
            // 
            decagonBtn.BackColor = Color.FromArgb(120, 120, 120);
            decagonBtn.FlatAppearance.BorderSize = 0;
            decagonBtn.FlatStyle = FlatStyle.Flat;
            decagonBtn.Image = (Image)resources.GetObject("decagonBtn.Image");
            decagonBtn.Location = new Point(226, 244);
            decagonBtn.Margin = new Padding(5, 6, 5, 6);
            decagonBtn.Name = "decagonBtn";
            decagonBtn.Size = new Size(51, 60);
            decagonBtn.TabIndex = 47;
            decagonBtn.UseVisualStyleBackColor = false;
            decagonBtn.Click += decagonBtn_Click;
            // 
            // septagonBtn
            // 
            septagonBtn.BackColor = Color.FromArgb(120, 120, 120);
            septagonBtn.FlatAppearance.BorderSize = 0;
            septagonBtn.FlatStyle = FlatStyle.Flat;
            septagonBtn.Image = (Image)resources.GetObject("septagonBtn.Image");
            septagonBtn.Location = new Point(158, 244);
            septagonBtn.Margin = new Padding(5, 6, 5, 6);
            septagonBtn.Name = "septagonBtn";
            septagonBtn.Size = new Size(51, 60);
            septagonBtn.TabIndex = 46;
            septagonBtn.UseVisualStyleBackColor = false;
            septagonBtn.Click += septagonBtn_Click;
            // 
            // hexagonBtn
            // 
            hexagonBtn.BackColor = Color.FromArgb(120, 120, 120);
            hexagonBtn.FlatAppearance.BorderSize = 0;
            hexagonBtn.FlatStyle = FlatStyle.Flat;
            hexagonBtn.Image = (Image)resources.GetObject("hexagonBtn.Image");
            hexagonBtn.Location = new Point(89, 244);
            hexagonBtn.Margin = new Padding(5, 6, 5, 6);
            hexagonBtn.Name = "hexagonBtn";
            hexagonBtn.Size = new Size(51, 60);
            hexagonBtn.TabIndex = 45;
            hexagonBtn.UseVisualStyleBackColor = false;
            hexagonBtn.Click += hexagonBtn_Click;
            // 
            // pentagonBtn
            // 
            pentagonBtn.BackColor = Color.FromArgb(120, 120, 120);
            pentagonBtn.FlatAppearance.BorderSize = 0;
            pentagonBtn.FlatStyle = FlatStyle.Flat;
            pentagonBtn.Image = (Image)resources.GetObject("pentagonBtn.Image");
            pentagonBtn.Location = new Point(21, 244);
            pentagonBtn.Margin = new Padding(5, 6, 5, 6);
            pentagonBtn.Name = "pentagonBtn";
            pentagonBtn.Size = new Size(51, 60);
            pentagonBtn.TabIndex = 44;
            pentagonBtn.UseVisualStyleBackColor = false;
            pentagonBtn.Click += pentagonBtn_Click;
            // 
            // chevronBtn
            // 
            chevronBtn.BackColor = Color.FromArgb(120, 120, 120);
            chevronBtn.FlatAppearance.BorderSize = 0;
            chevronBtn.FlatStyle = FlatStyle.Flat;
            chevronBtn.Image = (Image)resources.GetObject("chevronBtn.Image");
            chevronBtn.Location = new Point(226, 324);
            chevronBtn.Margin = new Padding(5, 6, 5, 6);
            chevronBtn.Name = "chevronBtn";
            chevronBtn.Size = new Size(51, 60);
            chevronBtn.TabIndex = 51;
            chevronBtn.UseVisualStyleBackColor = false;
            chevronBtn.Click += chevronBtn_Click;
            // 
            // doubleArrowBtn
            // 
            doubleArrowBtn.BackColor = Color.FromArgb(120, 120, 120);
            doubleArrowBtn.FlatAppearance.BorderSize = 0;
            doubleArrowBtn.FlatStyle = FlatStyle.Flat;
            doubleArrowBtn.Image = (Image)resources.GetObject("doubleArrowBtn.Image");
            doubleArrowBtn.Location = new Point(158, 324);
            doubleArrowBtn.Margin = new Padding(5, 6, 5, 6);
            doubleArrowBtn.Name = "doubleArrowBtn";
            doubleArrowBtn.Size = new Size(51, 60);
            doubleArrowBtn.TabIndex = 50;
            doubleArrowBtn.UseVisualStyleBackColor = false;
            doubleArrowBtn.Click += doubleArrowBtn_Click;
            // 
            // arrowBtn
            // 
            arrowBtn.BackColor = Color.FromArgb(120, 120, 120);
            arrowBtn.FlatAppearance.BorderSize = 0;
            arrowBtn.FlatStyle = FlatStyle.Flat;
            arrowBtn.Image = (Image)resources.GetObject("arrowBtn.Image");
            arrowBtn.Location = new Point(89, 324);
            arrowBtn.Margin = new Padding(5, 6, 5, 6);
            arrowBtn.Name = "arrowBtn";
            arrowBtn.Size = new Size(51, 60);
            arrowBtn.TabIndex = 49;
            arrowBtn.UseVisualStyleBackColor = false;
            arrowBtn.Click += arrowBtn_Click;
            // 
            // trapazoidBtn
            // 
            trapazoidBtn.BackColor = Color.FromArgb(120, 120, 120);
            trapazoidBtn.FlatAppearance.BorderSize = 0;
            trapazoidBtn.FlatStyle = FlatStyle.Flat;
            trapazoidBtn.Image = (Image)resources.GetObject("trapazoidBtn.Image");
            trapazoidBtn.Location = new Point(21, 324);
            trapazoidBtn.Margin = new Padding(5, 6, 5, 6);
            trapazoidBtn.Name = "trapazoidBtn";
            trapazoidBtn.Size = new Size(51, 60);
            trapazoidBtn.TabIndex = 48;
            trapazoidBtn.UseVisualStyleBackColor = false;
            trapazoidBtn.Click += trapazoidBtn_Click;
            // 
            // inkBtn
            // 
            inkBtn.BackColor = Color.FromArgb(120, 120, 120);
            inkBtn.FlatAppearance.BorderSize = 0;
            inkBtn.FlatStyle = FlatStyle.Flat;
            inkBtn.Image = (Image)resources.GetObject("inkBtn.Image");
            inkBtn.Location = new Point(205, 75);
            inkBtn.Margin = new Padding(5, 6, 5, 6);
            inkBtn.Name = "inkBtn";
            inkBtn.Size = new Size(51, 60);
            inkBtn.TabIndex = 55;
            inkBtn.Text = "/";
            inkBtn.UseVisualStyleBackColor = false;
            inkBtn.Click += inkBtn_Click;
            inkBtn.MouseDown += inkBtn_MouseDown;
            // 
            // sprayBtn
            // 
            sprayBtn.BackColor = Color.FromArgb(120, 120, 120);
            sprayBtn.FlatAppearance.BorderSize = 0;
            sprayBtn.FlatStyle = FlatStyle.Flat;
            sprayBtn.Image = (Image)resources.GetObject("sprayBtn.Image");
            sprayBtn.Location = new Point(137, 75);
            sprayBtn.Margin = new Padding(5, 6, 5, 6);
            sprayBtn.Name = "sprayBtn";
            sprayBtn.Size = new Size(51, 60);
            sprayBtn.TabIndex = 54;
            sprayBtn.Text = "/";
            sprayBtn.UseVisualStyleBackColor = false;
            sprayBtn.Click += sprayBtn_Click;
            sprayBtn.MouseDown += sprayBtn_MouseDown;
            // 
            // eraserBtn
            // 
            eraserBtn.BackColor = Color.FromArgb(120, 120, 120);
            eraserBtn.FlatAppearance.BorderSize = 0;
            eraserBtn.FlatStyle = FlatStyle.Flat;
            eraserBtn.Image = (Image)resources.GetObject("eraserBtn.Image");
            eraserBtn.Location = new Point(68, 75);
            eraserBtn.Margin = new Padding(5, 6, 5, 6);
            eraserBtn.Name = "eraserBtn";
            eraserBtn.Size = new Size(51, 60);
            eraserBtn.TabIndex = 53;
            eraserBtn.Text = "/";
            eraserBtn.UseVisualStyleBackColor = false;
            eraserBtn.Click += eraserBtn_Click;
            eraserBtn.MouseDown += eraserBtn_MouseDown;
            // 
            // brushBtn
            // 
            brushBtn.BackColor = Color.FromArgb(120, 120, 120);
            brushBtn.FlatAppearance.BorderSize = 0;
            brushBtn.FlatStyle = FlatStyle.Flat;
            brushBtn.Image = (Image)resources.GetObject("brushBtn.Image");
            brushBtn.Location = new Point(0, 75);
            brushBtn.Margin = new Padding(5, 6, 5, 6);
            brushBtn.Name = "brushBtn";
            brushBtn.Size = new Size(51, 60);
            brushBtn.TabIndex = 52;
            brushBtn.Text = "/";
            brushBtn.UseVisualStyleBackColor = false;
            brushBtn.Click += brushBtn_Click;
            brushBtn.MouseDown += brushBtn_MouseDown;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.FromArgb(80, 80, 80);
            label1.ForeColor = Color.Snow;
            label1.Location = new Point(21, 22);
            label1.Margin = new Padding(5, 0, 5, 0);
            label1.Name = "label1";
            label1.Size = new Size(81, 30);
            label1.TabIndex = 56;
            label1.Text = "Toolbar";
            // 
            // cursorBtn
            // 
            cursorBtn.BackColor = Color.FromArgb(120, 120, 120);
            cursorBtn.FlatAppearance.BorderSize = 0;
            cursorBtn.FlatStyle = FlatStyle.Flat;
            cursorBtn.Image = (Image)resources.GetObject("cursorBtn.Image");
            cursorBtn.Location = new Point(0, 3);
            cursorBtn.Margin = new Padding(5, 6, 5, 6);
            cursorBtn.Name = "cursorBtn";
            cursorBtn.Size = new Size(257, 60);
            cursorBtn.TabIndex = 58;
            cursorBtn.Text = "/";
            cursorBtn.UseVisualStyleBackColor = false;
            cursorBtn.Click += cursorBtn_Click;
            cursorBtn.MouseDown += cursorBtn_MouseDown;
            // 
            // sizePixelBox
            // 
            sizePixelBox.AllowDecimals = false;
            sizePixelBox.BackColor = Color.FromArgb(80, 80, 80);
            sizePixelBox.LabelText = "Size";
            sizePixelBox.Location = new Point(86, 68);
            sizePixelBox.Margin = new Padding(9, 12, 9, 12);
            sizePixelBox.Name = "sizePixelBox";
            sizePixelBox.Size = new Size(192, 56);
            sizePixelBox.Suffix = "";
            sizePixelBox.TabIndex = 60;
            sizePixelBox.TextBoxText = "0";
            sizePixelBox.InputSubmit += sizePixelBox_InputSubmit;
            // 
            // sizePanel
            // 
            sizePanel.Controls.Add(sizePixelBox);
            sizePanel.Controls.Add(trackBar1);
            sizePanel.Controls.Add(divider2);
            sizePanel.Controls.Add(background2);
            sizePanel.Location = new Point(0, 578);
            sizePanel.Margin = new Padding(5, 6, 5, 6);
            sizePanel.Name = "sizePanel";
            sizePanel.Size = new Size(343, 200);
            sizePanel.TabIndex = 61;
            // 
            // trackBar1
            // 
            trackBar1.BackColor = Color.FromArgb(80, 80, 80);
            trackBar1.Cursor = Cursors.Cross;
            trackBar1.Location = new Point(21, 32);
            trackBar1.Margin = new Padding(5, 6, 5, 6);
            trackBar1.Maximum = 200;
            trackBar1.Name = "trackBar1";
            trackBar1.Size = new Size(257, 80);
            trackBar1.TabIndex = 64;
            trackBar1.TickStyle = TickStyle.None;
            trackBar1.Scroll += trackBar1_Scroll;
            // 
            // divider2
            // 
            divider2.BackColor = Color.FromArgb(45, 45, 45);
            divider2.Location = new Point(2, 10);
            divider2.Margin = new Padding(5, 6, 5, 6);
            divider2.Name = "divider2";
            divider2.Size = new Size(300, 2);
            divider2.TabIndex = 63;
            divider2.TabStop = false;
            // 
            // background2
            // 
            background2.BackColor = Color.FromArgb(80, 80, 80);
            background2.BorderStyle = BorderStyle.FixedSingle;
            background2.Location = new Point(0, -4);
            background2.Margin = new Padding(5, 6, 5, 6);
            background2.Name = "background2";
            background2.Size = new Size(302, 152);
            background2.TabIndex = 62;
            background2.TabStop = false;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Location = new Point(458, 439);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(265, 151);
            flowLayoutPanel1.TabIndex = 0;
            // 
            // brushToolPanel
            // 
            brushToolPanel.BackColor = Color.FromArgb(80, 80, 80);
            brushToolPanel.Controls.Add(cursorBtn);
            brushToolPanel.Controls.Add(brushBtn);
            brushToolPanel.Controls.Add(inkBtn);
            brushToolPanel.Controls.Add(eraserBtn);
            brushToolPanel.Controls.Add(sprayBtn);
            brushToolPanel.Location = new Point(21, 413);
            brushToolPanel.Name = "brushToolPanel";
            brushToolPanel.Size = new Size(268, 146);
            brushToolPanel.TabIndex = 62;
            // 
            // ToolBarForm
            // 
            AutoScaleDimensions = new SizeF(12F, 30F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(960, 984);
            Controls.Add(brushToolPanel);
            Controls.Add(flowLayoutPanel1);
            Controls.Add(label1);
            Controls.Add(chevronBtn);
            Controls.Add(doubleArrowBtn);
            Controls.Add(arrowBtn);
            Controls.Add(trapazoidBtn);
            Controls.Add(decagonBtn);
            Controls.Add(septagonBtn);
            Controls.Add(hexagonBtn);
            Controls.Add(pentagonBtn);
            Controls.Add(star6Btn);
            Controls.Add(star5Btn);
            Controls.Add(star4Btn);
            Controls.Add(crossBtn);
            Controls.Add(ellipseBtn);
            Controls.Add(rightTriangleBtn);
            Controls.Add(triangleBtn);
            Controls.Add(divider1);
            Controls.Add(divider0);
            Controls.Add(headerBackground);
            Controls.Add(toolBarLabel);
            Controls.Add(squareBtn);
            Controls.Add(sizePanel);
            Controls.Add(background1);
            Margin = new Padding(3, 4, 3, 4);
            Name = "ToolBarForm";
            Text = "ToolBarForm";
            ((System.ComponentModel.ISupportInitialize)background1).EndInit();
            ((System.ComponentModel.ISupportInitialize)divider1).EndInit();
            ((System.ComponentModel.ISupportInitialize)divider0).EndInit();
            ((System.ComponentModel.ISupportInitialize)headerBackground).EndInit();
            ((System.ComponentModel.ISupportInitialize)toolBarLabel).EndInit();
            sizePanel.ResumeLayout(false);
            sizePanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)trackBar1).EndInit();
            ((System.ComponentModel.ISupportInitialize)divider2).EndInit();
            ((System.ComponentModel.ISupportInitialize)background2).EndInit();
            brushToolPanel.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button squareBtn;
        private PictureBox divider1;
        private PictureBox divider0;
        private PictureBox headerBackground;
        private PictureBox toolBarLabel;
        private PictureBox background1;
        private Button triangleBtn;
        private Button rightTriangleBtn;
        private Button ellipseBtn;
        private Button star6Btn;
        private Button star5Btn;
        private Button star4Btn;
        private Button crossBtn;
        private Button decagonBtn;
        private Button septagonBtn;
        private Button hexagonBtn;
        private Button pentagonBtn;
        private Button chevronBtn;
        private Button doubleArrowBtn;
        private Button arrowBtn;
        private Button trapazoidBtn;
        private Button inkBtn;
        private Button sprayBtn;
        private Button eraserBtn;
        private Button brushBtn;
        private Label label1;
        private Button cursorBtn;
        private PixelTextBox sizePixelBox;
        private Panel sizePanel;
        private PictureBox divider2;
        private PictureBox background2;
        private TrackBar trackBar1;
        private FlowLayoutPanel flowLayoutPanel1;
        private Panel brushToolPanel;
    }
}