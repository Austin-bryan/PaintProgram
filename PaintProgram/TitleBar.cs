using System.Runtime.InteropServices;

namespace PaintProgram;

public partial class TitleBar : Form
{
    public Point ExitButtonLocation => exitButton.Location;

    public TitleBar()
    {
        InitializeComponent();

        BackColor       = Color.LimeGreen;
        TransparencyKey = BackColor;
        ControlBox      = false;
        ShowInTaskbar   = false;
        Width           = 2000;

        titleBarImage.Width     = ClientSize.Width;
        titleBarImage.Location  = new Point(0, 0);
        titleBarImage.Dock      = DockStyle.Top;
        exitButton.Location     = new Point(1885, 0);
        minimizeButton.Location = new Point(exitButton.Location.X - exitButton.Width, exitButton.Location.Y);
        FormBorderStyle         = FormBorderStyle.None;
    }

    private void TitleBar_Load        (object sender, EventArgs e) => (Location, ControlBox, ShowInTaskbar) = (new Point(0, 0), false, false);
    private void exitButton_Click     (object sender, EventArgs e) => Owner.Close();
    private void minimizeButton_Click (object sender, EventArgs e) => Owner.WindowState    = FormWindowState.Minimized;
    private void exitButton_MouseHover(object sender, EventArgs e) => exitButton.BackColor = Color.DarkRed;
    private void exitButton_MouseLeave(object sender, EventArgs e) => exitButton.BackColor = Color.FromArgb(255, 30, 30, 30);

}
