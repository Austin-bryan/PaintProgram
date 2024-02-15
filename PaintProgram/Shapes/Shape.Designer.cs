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
        contextMenuStrip1 = new ContextMenuStrip(components);
        sendToBackToolStripMenuItem = new ToolStripMenuItem();
        sendBackwardsToolStripMenuItem = new ToolStripMenuItem();
        bringForwardsToolStripMenuItem = new ToolStripMenuItem();
        bringToFrontToolStripMenuItem = new ToolStripMenuItem();
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
        sendToBackToolStripMenuItem.Name = "sendToBackToolStripMenuItem";
        sendToBackToolStripMenuItem.Size = new Size(159, 22);
        sendToBackToolStripMenuItem.Text = "Send to Back";
        sendToBackToolStripMenuItem.Click += sendToBackToolStripMenuItem_Click;
        // 
        // sendBackwardsToolStripMenuItem
        // 
        sendBackwardsToolStripMenuItem.BackColor = SystemColors.Control;
        sendBackwardsToolStripMenuItem.ForeColor = SystemColors.ActiveCaptionText;
        sendBackwardsToolStripMenuItem.Name = "sendBackwardsToolStripMenuItem";
        sendBackwardsToolStripMenuItem.Size = new Size(159, 22);
        sendBackwardsToolStripMenuItem.Text = "Send Backwards";
        // 
        // bringForwardsToolStripMenuItem
        // 
        bringForwardsToolStripMenuItem.BackColor = SystemColors.Control;
        bringForwardsToolStripMenuItem.ForeColor = SystemColors.ActiveCaptionText;
        bringForwardsToolStripMenuItem.Name = "bringForwardsToolStripMenuItem";
        bringForwardsToolStripMenuItem.Size = new Size(159, 22);
        bringForwardsToolStripMenuItem.Text = "Bring Forwards";
        // 
        // bringToFrontToolStripMenuItem
        // 
        bringToFrontToolStripMenuItem.BackColor = SystemColors.Control;
        bringToFrontToolStripMenuItem.ForeColor = SystemColors.ActiveCaptionText;
        bringToFrontToolStripMenuItem.Name = "bringToFrontToolStripMenuItem";
        bringToFrontToolStripMenuItem.Size = new Size(159, 22);
        bringToFrontToolStripMenuItem.Text = "Bring to Front";
        bringToFrontToolStripMenuItem.Click += bringToFrontToolStripMenuItem_Click;
        // 
        // Shape
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = Color.Cyan;
        ClientSize = new Size(284, 261);
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
}
