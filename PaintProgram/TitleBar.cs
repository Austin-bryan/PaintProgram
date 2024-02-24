using System.Runtime.InteropServices;

namespace PaintProgram;

public partial class TitleBar : Form
{
    public Point ExitButtonLocation => exitButton.Location;
    public int BarHeight => titleBarImage.Height;

    public TitleBar()
    {
        InitializeComponent();
        FormHider.Hide(this);

        int screenWidth = Screen.PrimaryScreen.Bounds.Width;
        int screenHeight = Screen.PrimaryScreen.Bounds.Height;

       // int formWidth = 2000;
       int buttonOffset = 15;
        int buttonWidth = exitButton.Width;

        Width = screenWidth;



        titleBarImage.Width = ClientSize.Width;
       // titleBarImage.Location = new Point(buttonOffset, buttonWidth);

        titleBarImage.Dock = DockStyle.Top;
        titleBarImage.Size = new Size(buttonWidth, buttonWidth);
        titleBarImage.Height = screenHeight / 25;

        exitButton.Location = new Point(screenWidth - buttonWidth - buttonOffset, 0);
        minimizeButton.Location = new Point(exitButton.Location.X - buttonWidth - buttonOffset, exitButton.Location.Y);
        FormBorderStyle = FormBorderStyle.None;

        /*titleBarImage.Width     = ClientSize.Width;
        titleBarImage.Location  = new Point(0, 0);
        titleBarImage.Dock      = DockStyle.Top;
        exitButton.Location     = new Point(1885, 0);
        minimizeButton.Location = new Point(exitButton.Location.X - exitButton.Width, exitButton.Location.Y);
        FormBorderStyle         = FormBorderStyle.None;  */
    }

    private void TitleBar_Load        (object sender, EventArgs e) => (Location, ControlBox, ShowInTaskbar) = (new Point(0, 0), false, false);
    private void exitButton_Click     (object sender, EventArgs e) => Owner.Close();
    private void minimizeButton_Click (object sender, EventArgs e) => Owner.WindowState    = FormWindowState.Minimized;
    private void exitButton_MouseHover(object sender, EventArgs e) => exitButton.BackColor = Color.DarkRed;
    private void exitButton_MouseLeave(object sender, EventArgs e) => exitButton.BackColor = Color.FromArgb(255, 30, 30, 30);

}
