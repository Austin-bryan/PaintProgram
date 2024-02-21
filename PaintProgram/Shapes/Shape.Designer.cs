namespace PaintProgram.Shapes;

partial class Shape
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
        components = new System.ComponentModel.Container();
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Shape));
        contextMenuStrip1 = new ContextMenuStrip(components);
        sendToBackToolStripMenuItem = new ToolStripMenuItem();
        sendBackwardsToolStripMenuItem = new ToolStripMenuItem();
        bringForwardsToolStripMenuItem = new ToolStripMenuItem();
        bringToFrontToolStripMenuItem = new ToolStripMenuItem();
        zOrderLabel = new Label();
        contextMenuStrip1.SuspendLayout();
        SuspendLayout();
        // 
        // contextMenuStrip1
        // 
        contextMenuStrip1.Items.AddRange(new ToolStripItem[] { sendToBackToolStripMenuItem, sendBackwardsToolStripMenuItem, bringForwardsToolStripMenuItem, bringToFrontToolStripMenuItem });
        contextMenuStrip1.Name = "contextMenuStrip1";
        contextMenuStrip1.Size = new Size(160, 92);
        // 
        // sendToBackToolStripMenuItem
        // 
        sendToBackToolStripMenuItem.BackColor = SystemColors.Control;
        sendToBackToolStripMenuItem.ForeColor = SystemColors.ActiveCaptionText;
        sendToBackToolStripMenuItem.Image = (Image)resources.GetObject("sendToBackToolStripMenuItem.Image");
        sendToBackToolStripMenuItem.Name = "sendToBackToolStripMenuItem";
        sendToBackToolStripMenuItem.Size = new Size(159, 22);
        sendToBackToolStripMenuItem.Text = "Send to Back";
        sendToBackToolStripMenuItem.Click += sendToBackToolStripMenuItem_Click;
        // 
        // sendBackwardsToolStripMenuItem
        // 
        sendBackwardsToolStripMenuItem.BackColor = SystemColors.Control;
        sendBackwardsToolStripMenuItem.ForeColor = SystemColors.ActiveCaptionText;
        sendBackwardsToolStripMenuItem.Image = (Image)resources.GetObject("sendBackwardsToolStripMenuItem.Image");
        sendBackwardsToolStripMenuItem.Name = "sendBackwardsToolStripMenuItem";
        sendBackwardsToolStripMenuItem.Size = new Size(159, 22);
        sendBackwardsToolStripMenuItem.Text = "Send Backwards";
        sendBackwardsToolStripMenuItem.Click += sendBackwardsToolStripMenuItem_Click;
        // 
        // bringForwardsToolStripMenuItem
        // 
        bringForwardsToolStripMenuItem.BackColor = SystemColors.Control;
        bringForwardsToolStripMenuItem.ForeColor = SystemColors.ActiveCaptionText;
        bringForwardsToolStripMenuItem.Image = (Image)resources.GetObject("bringForwardsToolStripMenuItem.Image");
        bringForwardsToolStripMenuItem.Name = "bringForwardsToolStripMenuItem";
        bringForwardsToolStripMenuItem.Size = new Size(159, 22);
        bringForwardsToolStripMenuItem.Text = "Bring Forwards";
        bringForwardsToolStripMenuItem.Click += bringForwardsToolStripMenuItem_Click;
        // 
        // bringToFrontToolStripMenuItem
        // 
        bringToFrontToolStripMenuItem.BackColor = SystemColors.Control;
        bringToFrontToolStripMenuItem.ForeColor = SystemColors.ActiveCaptionText;
        bringToFrontToolStripMenuItem.Image = (Image)resources.GetObject("bringToFrontToolStripMenuItem.Image");
        bringToFrontToolStripMenuItem.Name = "bringToFrontToolStripMenuItem";
        bringToFrontToolStripMenuItem.Size = new Size(159, 22);
        bringToFrontToolStripMenuItem.Text = "Bring to Front";
        bringToFrontToolStripMenuItem.Click += bringToFrontToolStripMenuItem_Click;
        // 
        // zOrderLabel
        // 
        zOrderLabel.BackColor = Color.Transparent;
        zOrderLabel.Font = new Font("Segoe UI", 30F, FontStyle.Regular, GraphicsUnit.Point);
        zOrderLabel.Location = new Point(142, 147);
        zOrderLabel.Name = "zOrderLabel";
        zOrderLabel.Size = new Size(130, 54);
        zOrderLabel.TabIndex = 1;
        zOrderLabel.Text = "zOrder";
        // 
        // Shape
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = Color.Cyan;
        ClientSize = new Size(284, 261);
        Controls.Add(zOrderLabel);
        Name = "Shape";
        MouseClick += Shape_MouseClick;
        contextMenuStrip1.ResumeLayout(false);
        ResumeLayout(false);
    }

    #endregion

    private ContextMenuStrip contextMenuStrip1;
    private ToolStripMenuItem sendToBackToolStripMenuItem;
    private ToolStripMenuItem sendBackwardsToolStripMenuItem;
    private ToolStripMenuItem bringForwardsToolStripMenuItem;
    private ToolStripMenuItem bringToFrontToolStripMenuItem;
    private Label zOrderLabel;
}
