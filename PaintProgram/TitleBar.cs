/* Project: Paint
 * Authors: Austin Bryan, Lucius Miller, Noah Curtis
 * Class: Foundations in App Development
 * Date: February 24th, 2024*/

namespace PaintProgram;

/*
 * Purpose of this class is to replace the default title bar, so that shapes won't be drawn over the title bar. 
 * I could have clamped the shapes position to not go above the title bar, but I decided it would be better for the user experience to let them
 * push the shape out of bounds. I also use this to remove the window button which forces the app in full screen, so that the shapes can't dragged outside
 * the form. Again, I could have manually clamped the values to the position and width of the form, but this wouldn't allow the user to drag shapes
 * partially out of bounds.
 */
public partial class TitleBar : Form
{
    public Point ExitButtonLocation => exitButton.Location; // The Shape Editor's position is dependent on the exit button
    public int BarHeight => titleBarImage.Height;   // This is used to clamp the tool bar and shape editor so they can't moved below the title bar

    public TitleBar()
    {
        InitializeComponent();
        FormAsControlStyler.StyleFormAsControl(this);

        var (screenWidth, screenHeight) = (MainForm.ScreenSize.Width, MainForm.ScreenSize.Height);
        var (buttonOffset, buttonWidth) = (15, exitButton.Width);
        Width = screenWidth;

        // Styles the title bar background. Its designed soft coded, and was tested on both a 1080p and 4k monitor, and should work for a 720p monitor as well
        titleBarImage.Width  = ClientSize.Width;
        titleBarImage.Dock   = DockStyle.Top;
        titleBarImage.Size   = new Size(buttonWidth, buttonWidth);
        titleBarImage.Height = screenHeight / 25;

        exitButton.Location     = new Point(screenWidth - buttonWidth - buttonOffset, 0);
        minimizeButton.Location = new Point(exitButton.Location.X - buttonWidth - buttonOffset, exitButton.Location.Y);
    }

    private void TitleBar_Load        (object sender, EventArgs e) => Location = Point.Empty;
    private void exitButton_Click     (object sender, EventArgs e) => Owner.Close();
    private void minimizeButton_Click (object sender, EventArgs e) => Owner.WindowState    = FormWindowState.Minimized;
    private void exitButton_MouseHover(object sender, EventArgs e) => exitButton.BackColor = Color.DarkRed;
    private void exitButton_MouseLeave(object sender, EventArgs e) => exitButton.BackColor = Color.FromArgb(255, 30, 30, 30);

}