namespace PaintProgram
{
    partial class PixelTextBox
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label = new Label();
            entryBox = new TextBox();
            SuspendLayout();
            // 
            // label
            // 
            label.ForeColor = SystemColors.ButtonHighlight;
            label.Location = new Point(0, 6);
            label.Name = "label";
            label.Size = new Size(63, 15);
            label.TabIndex = 0;
            label.Text = "Label Name";
            label.TextAlign = ContentAlignment.TopRight;
            // 
            // entryBox
            // 
            entryBox.BackColor = Color.FromArgb(45, 45, 45);
            entryBox.BorderStyle = BorderStyle.FixedSingle;
            entryBox.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            entryBox.ForeColor = SystemColors.Menu;
            entryBox.Location = new Point(65, 3);
            entryBox.Name = "entryBox";
            entryBox.Size = new Size(44, 23);
            entryBox.TabIndex = 1;
            entryBox.Text = "Swag";
            entryBox.TextAlign = HorizontalAlignment.Center;
            entryBox.Enter += entryBox_Enter;
            entryBox.KeyDown += entryBox_KeyDown;
            entryBox.KeyPress += entryBox_KeyPress;
            entryBox.Leave += entryBox_Leave;
            // 
            // PixelTextBox
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(80, 80, 80);
            Controls.Add(entryBox);
            Controls.Add(label);
            Name = "PixelTextBox";
            Size = new Size(112, 28);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label;
        private TextBox entryBox;
    }
}
