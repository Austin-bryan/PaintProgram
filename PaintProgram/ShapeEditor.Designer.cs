namespace PaintProgram
{
    partial class ShapeEditor
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
            Button sendBackwardsBtn;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ShapeEditor));
            colorWheelPictureBox = new PictureBox();
            valueSliderPictureBox = new PictureBox();
            colorPreviewPictureBox = new PictureBox();
            colorWheelBackground = new PictureBox();
            colorWheelTab = new PictureBox();
            colorWheelTabBackground = new PictureBox();
            colorPickerLabel = new Label();
            colorWheelBoarderHider = new PictureBox();
            propertiesLabel = new PictureBox();
            pictureBox4 = new PictureBox();
            pictureBox1 = new PictureBox();
            label1 = new Label();
            pictureBox2 = new PictureBox();
            transformLabel = new Label();
            pictureBox5 = new PictureBox();
            linkButton = new Button();
            layeringLabel = new Label();
            bringToFrontBtn = new Button();
            bringForwardBtn = new Button();
            sendToBackBtn = new Button();
            borederLabel = new Label();
            pictureBox6 = new PictureBox();
            colorLabel = new Label();
            borderColorBtn = new Button();
            widthPixelBox = new PixelTextBox();
            heightPixelBox = new PixelTextBox();
            yPixelBox = new PixelTextBox();
            xPixelBox = new PixelTextBox();
            thicknessPixelBox = new PixelTextBox();
            alpha1_PixelBox = new PixelTextBox();
            borderCheckBox = new CheckBox();
            alpha2_PixelBox = new PixelTextBox();
            sendBackwardsBtn = new Button();
            ((System.ComponentModel.ISupportInitialize)colorWheelPictureBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)valueSliderPictureBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)colorPreviewPictureBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)colorWheelBackground).BeginInit();
            ((System.ComponentModel.ISupportInitialize)colorWheelTab).BeginInit();
            ((System.ComponentModel.ISupportInitialize)colorWheelTabBackground).BeginInit();
            ((System.ComponentModel.ISupportInitialize)colorWheelBoarderHider).BeginInit();
            ((System.ComponentModel.ISupportInitialize)propertiesLabel).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox6).BeginInit();
            SuspendLayout();
            // 
            // sendBackwardsBtn
            // 
            sendBackwardsBtn.BackColor = Color.FromArgb(120, 120, 120);
            sendBackwardsBtn.FlatAppearance.BorderSize = 0;
            sendBackwardsBtn.FlatStyle = FlatStyle.Flat;
            sendBackwardsBtn.Image = (Image)resources.GetObject("sendBackwardsBtn.Image");
            sendBackwardsBtn.Location = new Point(149, 460);
            sendBackwardsBtn.Name = "sendBackwardsBtn";
            sendBackwardsBtn.Size = new Size(30, 30);
            sendBackwardsBtn.TabIndex = 29;
            sendBackwardsBtn.UseVisualStyleBackColor = false;
            sendBackwardsBtn.Click += sendBackwardsBtn_Click;
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
            colorWheelTabBackground.BackColor = Color.FromArgb(45, 45, 45);
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
            // propertiesLabel
            // 
            propertiesLabel.BackColor = Color.FromArgb(80, 80, 80);
            propertiesLabel.BorderStyle = BorderStyle.FixedSingle;
            propertiesLabel.Location = new Point(0, 300);
            propertiesLabel.Name = "propertiesLabel";
            propertiesLabel.Size = new Size(100, 31);
            propertiesLabel.TabIndex = 11;
            propertiesLabel.TabStop = false;
            // 
            // pictureBox4
            // 
            pictureBox4.BackColor = Color.FromArgb(80, 80, 80);
            pictureBox4.BorderStyle = BorderStyle.FixedSingle;
            pictureBox4.Location = new Point(0, 327);
            pictureBox4.Name = "pictureBox4";
            pictureBox4.Size = new Size(342, 281);
            pictureBox4.TabIndex = 10;
            pictureBox4.TabStop = false;
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
            pictureBox2.BackColor = Color.FromArgb(45, 45, 45);
            pictureBox2.BorderStyle = BorderStyle.FixedSingle;
            pictureBox2.Location = new Point(99, 300);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(243, 31);
            pictureBox2.TabIndex = 12;
            pictureBox2.TabStop = false;
            // 
            // transformLabel
            // 
            transformLabel.AutoSize = true;
            transformLabel.BackColor = Color.FromArgb(80, 80, 80);
            transformLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            transformLabel.ForeColor = Color.White;
            transformLabel.Location = new Point(8, 344);
            transformLabel.Name = "transformLabel";
            transformLabel.Size = new Size(64, 15);
            transformLabel.TabIndex = 15;
            transformLabel.Text = "Transform";
            // 
            // pictureBox5
            // 
            pictureBox5.BackColor = Color.FromArgb(45, 45, 45);
            pictureBox5.Location = new Point(1, 419);
            pictureBox5.Name = "pictureBox5";
            pictureBox5.Size = new Size(340, 1);
            pictureBox5.TabIndex = 16;
            pictureBox5.TabStop = false;
            // 
            // linkButton
            // 
            linkButton.BackColor = Color.FromArgb(130, 130, 130);
            linkButton.FlatAppearance.BorderSize = 0;
            linkButton.FlatStyle = FlatStyle.Flat;
            linkButton.Image = (Image)resources.GetObject("linkButton.Image");
            linkButton.Location = new Point(12, 366);
            linkButton.Name = "linkButton";
            linkButton.Size = new Size(27, 37);
            linkButton.TabIndex = 18;
            linkButton.UseVisualStyleBackColor = false;
            linkButton.MouseClick += linkButton_MouseClick;
            // 
            // layeringLabel
            // 
            layeringLabel.AutoSize = true;
            layeringLabel.BackColor = Color.FromArgb(80, 80, 80);
            layeringLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            layeringLabel.ForeColor = Color.White;
            layeringLabel.Location = new Point(8, 434);
            layeringLabel.Name = "layeringLabel";
            layeringLabel.Size = new Size(103, 15);
            layeringLabel.TabIndex = 26;
            layeringLabel.Text = "Layering Controls";
            // 
            // bringToFrontBtn
            // 
            bringToFrontBtn.BackColor = Color.FromArgb(120, 120, 120);
            bringToFrontBtn.FlatAppearance.BorderSize = 0;
            bringToFrontBtn.FlatStyle = FlatStyle.Flat;
            bringToFrontBtn.Image = (Image)resources.GetObject("bringToFrontBtn.Image");
            bringToFrontBtn.Location = new Point(49, 460);
            bringToFrontBtn.Name = "bringToFrontBtn";
            bringToFrontBtn.Size = new Size(30, 30);
            bringToFrontBtn.TabIndex = 27;
            bringToFrontBtn.UseVisualStyleBackColor = false;
            bringToFrontBtn.Click += bringToFrontBtn_Click;
            // 
            // bringForwardBtn
            // 
            bringForwardBtn.BackColor = Color.FromArgb(120, 120, 120);
            bringForwardBtn.FlatAppearance.BorderSize = 0;
            bringForwardBtn.FlatStyle = FlatStyle.Flat;
            bringForwardBtn.Image = (Image)resources.GetObject("bringForwardBtn.Image");
            bringForwardBtn.Location = new Point(99, 460);
            bringForwardBtn.Name = "bringForwardBtn";
            bringForwardBtn.Size = new Size(30, 30);
            bringForwardBtn.TabIndex = 28;
            bringForwardBtn.UseVisualStyleBackColor = false;
            bringForwardBtn.Click += bringForwardBtn_Click;
            // 
            // sendToBackBtn
            // 
            sendToBackBtn.BackColor = Color.FromArgb(120, 120, 120);
            sendToBackBtn.FlatAppearance.BorderSize = 0;
            sendToBackBtn.FlatStyle = FlatStyle.Flat;
            sendToBackBtn.Image = (Image)resources.GetObject("sendToBackBtn.Image");
            sendToBackBtn.Location = new Point(199, 460);
            sendToBackBtn.Name = "sendToBackBtn";
            sendToBackBtn.Size = new Size(30, 30);
            sendToBackBtn.TabIndex = 30;
            sendToBackBtn.UseVisualStyleBackColor = false;
            sendToBackBtn.Click += sendToBackBtn_Click;
            // 
            // borederLabel
            // 
            borederLabel.AutoSize = true;
            borederLabel.BackColor = Color.FromArgb(80, 80, 80);
            borederLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            borederLabel.ForeColor = Color.White;
            borederLabel.Location = new Point(8, 518);
            borederLabel.Name = "borederLabel";
            borederLabel.Size = new Size(46, 15);
            borederLabel.TabIndex = 32;
            borederLabel.Text = "Border";
            // 
            // pictureBox6
            // 
            pictureBox6.BackColor = Color.FromArgb(45, 45, 45);
            pictureBox6.Location = new Point(1, 503);
            pictureBox6.Name = "pictureBox6";
            pictureBox6.Size = new Size(340, 1);
            pictureBox6.TabIndex = 31;
            pictureBox6.TabStop = false;
            // 
            // colorLabel
            // 
            colorLabel.AutoSize = true;
            colorLabel.BackColor = Color.FromArgb(80, 80, 80);
            colorLabel.ForeColor = Color.Snow;
            colorLabel.Location = new Point(168, 543);
            colorLabel.Name = "colorLabel";
            colorLabel.Size = new Size(36, 15);
            colorLabel.TabIndex = 35;
            colorLabel.Text = "Color";
            colorLabel.TextAlign = ContentAlignment.TopRight;
            // 
            // borderColorBtn
            // 
            borderColorBtn.BackColor = Color.DarkViolet;
            borderColorBtn.FlatAppearance.BorderSize = 0;
            borderColorBtn.FlatStyle = FlatStyle.Flat;
            borderColorBtn.Location = new Point(209, 536);
            borderColorBtn.Name = "borderColorBtn";
            borderColorBtn.Size = new Size(30, 30);
            borderColorBtn.TabIndex = 36;
            borderColorBtn.UseVisualStyleBackColor = false;
            borderColorBtn.Click += borderColorBtn_Click;
            // 
            // widthPixelBox
            // 
            widthPixelBox.AllowDecimals = false;
            widthPixelBox.BackColor = Color.FromArgb(80, 80, 80);
            widthPixelBox.LabelText = "W";
            widthPixelBox.Location = new Point(8, 363);
            widthPixelBox.Name = "widthPixelBox";
            widthPixelBox.Size = new Size(107, 23);
            widthPixelBox.Suffix = " px";
            widthPixelBox.TabIndex = 37;
            widthPixelBox.TextBoxText = "0 px";
            widthPixelBox.InputSubmit += widthPixelBox_InputSubmit;
            // 
            // heightPixelBox
            // 
            heightPixelBox.AllowDecimals = false;
            heightPixelBox.BackColor = Color.FromArgb(80, 80, 80);
            heightPixelBox.LabelText = "H";
            heightPixelBox.Location = new Point(8, 383);
            heightPixelBox.Name = "heightPixelBox";
            heightPixelBox.Size = new Size(107, 23);
            heightPixelBox.Suffix = " px";
            heightPixelBox.TabIndex = 38;
            heightPixelBox.TextBoxText = "0 px";
            heightPixelBox.InputSubmit += heightPixelBox_InputSubmit;
            // 
            // yPixelBox
            // 
            yPixelBox.AllowDecimals = false;
            yPixelBox.BackColor = Color.FromArgb(80, 80, 80);
            yPixelBox.LabelText = "Y";
            yPixelBox.Location = new Point(75, 383);
            yPixelBox.Name = "yPixelBox";
            yPixelBox.Size = new Size(120, 23);
            yPixelBox.Suffix = " px";
            yPixelBox.TabIndex = 40;
            yPixelBox.TextBoxText = "0 px";
            yPixelBox.InputSubmit += yPixelBox_InputSubmit;
            // 
            // xPixelBox
            // 
            xPixelBox.AllowDecimals = false;
            xPixelBox.BackColor = Color.FromArgb(80, 80, 80);
            xPixelBox.LabelText = "X";
            xPixelBox.Location = new Point(75, 363);
            xPixelBox.Name = "xPixelBox";
            xPixelBox.Size = new Size(120, 23);
            xPixelBox.Suffix = " px";
            xPixelBox.TabIndex = 39;
            xPixelBox.TextBoxText = "0 px";
            xPixelBox.InputSubmit += xPixelBox_InputSubmit;
            // 
            // thicknessPixelBox
            // 
            thicknessPixelBox.AllowDecimals = false;
            thicknessPixelBox.BackColor = Color.FromArgb(80, 80, 80);
            thicknessPixelBox.LabelText = "Thickness";
            thicknessPixelBox.Location = new Point(26, 539);
            thicknessPixelBox.Name = "thicknessPixelBox";
            thicknessPixelBox.Size = new Size(119, 23);
            thicknessPixelBox.Suffix = " px";
            thicknessPixelBox.TabIndex = 43;
            thicknessPixelBox.TextBoxText = "0 px";
            thicknessPixelBox.InputSubmit += thicknessPixelBox_InputSubmit;
            // 
            // alpha1_PixelBox
            // 
            alpha1_PixelBox.AllowDecimals = true;
            alpha1_PixelBox.BackColor = Color.FromArgb(80, 80, 80);
            alpha1_PixelBox.LabelText = "Alpha 1";
            alpha1_PixelBox.Location = new Point(179, 363);
            alpha1_PixelBox.Name = "alpha1_PixelBox";
            alpha1_PixelBox.Size = new Size(120, 23);
            alpha1_PixelBox.Suffix = "";
            alpha1_PixelBox.TabIndex = 41;
            alpha1_PixelBox.TextBoxText = "0 px";
            alpha1_PixelBox.Visible = false;
            alpha1_PixelBox.InputSubmit += alpha1_PixelBox_InputSubmit;
            // 
            // borderCheckBox
            // 
            borderCheckBox.AutoSize = true;
            borderCheckBox.BackColor = Color.FromArgb(80, 80, 80);
            borderCheckBox.ForeColor = SystemColors.ButtonHighlight;
            borderCheckBox.Location = new Point(46, 568);
            borderCheckBox.Name = "borderCheckBox";
            borderCheckBox.Size = new Size(83, 19);
            borderCheckBox.TabIndex = 44;
            borderCheckBox.Text = "Use Border";
            borderCheckBox.UseVisualStyleBackColor = false;
            borderCheckBox.CheckedChanged += borderCheckBox_CheckedChanged;
            // 
            // alpha2_PixelBox
            // 
            alpha2_PixelBox.AllowDecimals = true;
            alpha2_PixelBox.BackColor = Color.FromArgb(80, 80, 80);
            alpha2_PixelBox.LabelText = "Alpha 2";
            alpha2_PixelBox.Location = new Point(179, 383);
            alpha2_PixelBox.Name = "alpha2_PixelBox";
            alpha2_PixelBox.Size = new Size(120, 23);
            alpha2_PixelBox.Suffix = "";
            alpha2_PixelBox.TabIndex = 42;
            alpha2_PixelBox.TextBoxText = "0 px";
            alpha2_PixelBox.Visible = false;
            alpha2_PixelBox.InputSubmit += alpha2_PixelBox_InputSubmit;
            // 
            // Stupid
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(343, 633);
            Controls.Add(linkButton);
            Controls.Add(heightPixelBox);
            Controls.Add(yPixelBox);
            Controls.Add(alpha2_PixelBox);
            Controls.Add(borderCheckBox);
            Controls.Add(widthPixelBox);
            Controls.Add(xPixelBox);
            Controls.Add(alpha1_PixelBox);
            Controls.Add(thicknessPixelBox);
            Controls.Add(borderColorBtn);
            Controls.Add(colorLabel);
            Controls.Add(borederLabel);
            Controls.Add(pictureBox6);
            Controls.Add(sendToBackBtn);
            Controls.Add(sendBackwardsBtn);
            Controls.Add(bringForwardBtn);
            Controls.Add(bringToFrontBtn);
            Controls.Add(layeringLabel);
            Controls.Add(pictureBox5);
            Controls.Add(transformLabel);
            Controls.Add(pictureBox1);
            Controls.Add(label1);
            Controls.Add(pictureBox2);
            Controls.Add(propertiesLabel);
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
            ((System.ComponentModel.ISupportInitialize)propertiesLabel).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox6).EndInit();
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
        private PictureBox propertiesLabel;
        private PictureBox pictureBox4;
        private PictureBox pictureBox1;
        private Label label1;
        private PictureBox pictureBox2;
        private Label transformLabel;
        private PictureBox pictureBox5;
        private Button linkButton;
        private Label layeringLabel;
        private Button bringToFrontBtn;
        private Button bringForwardBtn;
        private Button sendBackwardsBtn;
        private Button sendToBackBtn;
        private Label borederLabel;
        private PictureBox pictureBox6;
        private Label colorLabel;
        private Button borderColorBtn;
        private PixelTextBox widthPixelBox;
        private PixelTextBox heightPixelBox;
        private PixelTextBox yPixelBox;
        private PixelTextBox xPixelBox;
        private PixelTextBox thicknessPixelBox;
        private PixelTextBox alpha1_PixelBox;
        private CheckBox borderCheckBox;
        private PixelTextBox alpha2_PixelBox;
    }
}