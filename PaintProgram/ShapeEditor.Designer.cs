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
            propertiesTab = new PictureBox();
            bottomBackground = new PictureBox();
            borderHider = new PictureBox();
            propertiesLabel = new Label();
            propertiesTabBackground = new PictureBox();
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
            propertiesPanel = new Panel();
            hideButton = new Button();
            sendBackwardsBtn = new Button();
            ((System.ComponentModel.ISupportInitialize)colorWheelPictureBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)valueSliderPictureBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)colorPreviewPictureBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)colorWheelBackground).BeginInit();
            ((System.ComponentModel.ISupportInitialize)colorWheelTab).BeginInit();
            ((System.ComponentModel.ISupportInitialize)colorWheelTabBackground).BeginInit();
            ((System.ComponentModel.ISupportInitialize)colorWheelBoarderHider).BeginInit();
            ((System.ComponentModel.ISupportInitialize)propertiesTab).BeginInit();
            ((System.ComponentModel.ISupportInitialize)bottomBackground).BeginInit();
            ((System.ComponentModel.ISupportInitialize)borderHider).BeginInit();
            ((System.ComponentModel.ISupportInitialize)propertiesTabBackground).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox6).BeginInit();
            propertiesPanel.SuspendLayout();
            SuspendLayout();
            // 
            // sendBackwardsBtn
            // 
            sendBackwardsBtn.BackColor = Color.FromArgb(120, 120, 120);
            sendBackwardsBtn.FlatAppearance.BorderSize = 0;
            sendBackwardsBtn.FlatStyle = FlatStyle.Flat;
            sendBackwardsBtn.Image = (Image)resources.GetObject("sendBackwardsBtn.Image");
            sendBackwardsBtn.Location = new Point(150, 160);
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
            // propertiesTab
            // 
            propertiesTab.BackColor = Color.FromArgb(80, 80, 80);
            propertiesTab.BorderStyle = BorderStyle.FixedSingle;
            propertiesTab.Location = new Point(1, 0);
            propertiesTab.Name = "propertiesTab";
            propertiesTab.Size = new Size(100, 31);
            propertiesTab.TabIndex = 11;
            propertiesTab.TabStop = false;
            // 
            // bottomBackground
            // 
            bottomBackground.BackColor = Color.FromArgb(80, 80, 80);
            bottomBackground.BorderStyle = BorderStyle.FixedSingle;
            bottomBackground.Location = new Point(1, 27);
            bottomBackground.Name = "bottomBackground";
            bottomBackground.Size = new Size(342, 281);
            bottomBackground.TabIndex = 10;
            bottomBackground.TabStop = false;
            // 
            // borderHider
            // 
            borderHider.BackColor = Color.FromArgb(80, 80, 80);
            borderHider.Location = new Point(2, 27);
            borderHider.Name = "borderHider";
            borderHider.Size = new Size(340, 14);
            borderHider.TabIndex = 14;
            borderHider.TabStop = false;
            // 
            // propertiesLabel
            // 
            propertiesLabel.AutoSize = true;
            propertiesLabel.BackColor = Color.FromArgb(80, 80, 80);
            propertiesLabel.ForeColor = Color.Snow;
            propertiesLabel.Location = new Point(13, 9);
            propertiesLabel.Name = "propertiesLabel";
            propertiesLabel.Size = new Size(60, 15);
            propertiesLabel.TabIndex = 13;
            propertiesLabel.Text = "Properties";
            // 
            // propertiesTabBackground
            // 
            propertiesTabBackground.BackColor = Color.FromArgb(45, 45, 45);
            propertiesTabBackground.BorderStyle = BorderStyle.FixedSingle;
            propertiesTabBackground.Location = new Point(100, 0);
            propertiesTabBackground.Name = "propertiesTabBackground";
            propertiesTabBackground.Size = new Size(243, 31);
            propertiesTabBackground.TabIndex = 12;
            propertiesTabBackground.TabStop = false;
            // 
            // transformLabel
            // 
            transformLabel.AutoSize = true;
            transformLabel.BackColor = Color.FromArgb(80, 80, 80);
            transformLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            transformLabel.ForeColor = Color.White;
            transformLabel.Location = new Point(9, 44);
            transformLabel.Name = "transformLabel";
            transformLabel.Size = new Size(64, 15);
            transformLabel.TabIndex = 15;
            transformLabel.Text = "Transform";
            // 
            // pictureBox5
            // 
            pictureBox5.BackColor = Color.FromArgb(45, 45, 45);
            pictureBox5.Location = new Point(2, 119);
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
            linkButton.Location = new Point(13, 66);
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
            layeringLabel.Location = new Point(9, 134);
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
            bringToFrontBtn.Location = new Point(50, 160);
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
            bringForwardBtn.Location = new Point(100, 160);
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
            sendToBackBtn.Location = new Point(200, 160);
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
            borederLabel.Location = new Point(9, 218);
            borederLabel.Name = "borederLabel";
            borederLabel.Size = new Size(46, 15);
            borederLabel.TabIndex = 32;
            borederLabel.Text = "Border";
            // 
            // pictureBox6
            // 
            pictureBox6.BackColor = Color.FromArgb(45, 45, 45);
            pictureBox6.Location = new Point(2, 203);
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
            colorLabel.Location = new Point(169, 243);
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
            borderColorBtn.Location = new Point(210, 236);
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
            widthPixelBox.Location = new Point(9, 63);
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
            heightPixelBox.Location = new Point(9, 83);
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
            yPixelBox.Location = new Point(76, 83);
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
            xPixelBox.Location = new Point(76, 63);
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
            thicknessPixelBox.Location = new Point(27, 239);
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
            alpha1_PixelBox.Location = new Point(180, 63);
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
            borderCheckBox.Location = new Point(47, 268);
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
            alpha2_PixelBox.Location = new Point(180, 83);
            alpha2_PixelBox.Name = "alpha2_PixelBox";
            alpha2_PixelBox.Size = new Size(120, 23);
            alpha2_PixelBox.Suffix = "";
            alpha2_PixelBox.TabIndex = 42;
            alpha2_PixelBox.TextBoxText = "0 px";
            alpha2_PixelBox.Visible = false;
            alpha2_PixelBox.InputSubmit += alpha2_PixelBox_InputSubmit;
            // 
            // propertiesPanel
            // 
            propertiesPanel.Controls.Add(linkButton);
            propertiesPanel.Controls.Add(heightPixelBox);
            propertiesPanel.Controls.Add(yPixelBox);
            propertiesPanel.Controls.Add(propertiesLabel);
            propertiesPanel.Controls.Add(alpha2_PixelBox);
            propertiesPanel.Controls.Add(borderHider);
            propertiesPanel.Controls.Add(borderCheckBox);
            propertiesPanel.Controls.Add(transformLabel);
            propertiesPanel.Controls.Add(widthPixelBox);
            propertiesPanel.Controls.Add(pictureBox5);
            propertiesPanel.Controls.Add(xPixelBox);
            propertiesPanel.Controls.Add(layeringLabel);
            propertiesPanel.Controls.Add(alpha1_PixelBox);
            propertiesPanel.Controls.Add(bringToFrontBtn);
            propertiesPanel.Controls.Add(thicknessPixelBox);
            propertiesPanel.Controls.Add(bringForwardBtn);
            propertiesPanel.Controls.Add(borderColorBtn);
            propertiesPanel.Controls.Add(sendBackwardsBtn);
            propertiesPanel.Controls.Add(colorLabel);
            propertiesPanel.Controls.Add(sendToBackBtn);
            propertiesPanel.Controls.Add(borederLabel);
            propertiesPanel.Controls.Add(pictureBox6);
            propertiesPanel.Controls.Add(propertiesTabBackground);
            propertiesPanel.Controls.Add(bottomBackground);
            propertiesPanel.Controls.Add(propertiesTab);
            propertiesPanel.Location = new Point(-1, 300);
            propertiesPanel.Name = "propertiesPanel";
            propertiesPanel.Size = new Size(343, 335);
            propertiesPanel.TabIndex = 45;
            // 
            // hideButton
            // 
            hideButton.BackColor = Color.FromArgb(45, 45, 45);
            hideButton.FlatAppearance.BorderSize = 0;
            hideButton.FlatStyle = FlatStyle.Flat;
            hideButton.ForeColor = SystemColors.ButtonHighlight;
            hideButton.Location = new Point(315, 1);
            hideButton.Name = "hideButton";
            hideButton.Size = new Size(25, 25);
            hideButton.TabIndex = 45;
            hideButton.Text = "X";
            hideButton.UseVisualStyleBackColor = false;
            hideButton.Click += hideButton_Click;
            // 
            // ShapeEditor
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(340, 601);
            Controls.Add(hideButton);
            Controls.Add(propertiesPanel);
            Controls.Add(colorWheelBoarderHider);
            Controls.Add(colorPickerLabel);
            Controls.Add(colorWheelTabBackground);
            Controls.Add(colorWheelTab);
            Controls.Add(colorPreviewPictureBox);
            Controls.Add(valueSliderPictureBox);
            Controls.Add(colorWheelPictureBox);
            Controls.Add(colorWheelBackground);
            Name = "ShapeEditor";
            Text = "Stupid";
            ((System.ComponentModel.ISupportInitialize)colorWheelPictureBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)valueSliderPictureBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)colorPreviewPictureBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)colorWheelBackground).EndInit();
            ((System.ComponentModel.ISupportInitialize)colorWheelTab).EndInit();
            ((System.ComponentModel.ISupportInitialize)colorWheelTabBackground).EndInit();
            ((System.ComponentModel.ISupportInitialize)colorWheelBoarderHider).EndInit();
            ((System.ComponentModel.ISupportInitialize)propertiesTab).EndInit();
            ((System.ComponentModel.ISupportInitialize)bottomBackground).EndInit();
            ((System.ComponentModel.ISupportInitialize)borderHider).EndInit();
            ((System.ComponentModel.ISupportInitialize)propertiesTabBackground).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox6).EndInit();
            propertiesPanel.ResumeLayout(false);
            propertiesPanel.PerformLayout();
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
        private PictureBox propertiesTab;
        private PictureBox bottomBackground;
        private PictureBox borderHider;
        private Label propertiesLabel;
        private PictureBox propertiesTabBackground;
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
        private Panel propertiesPanel;
        private Button button1;
        private Button hideButton;
    }
}