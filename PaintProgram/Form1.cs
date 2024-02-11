using PaintProgram.Shapes;

namespace PaintProgram;

public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();

        WindowState             = FormWindowState.Maximized;
        titleBarImage.Width     = ClientSize.Width;
        titleBarImage.Location  = new Point(0, 0);
        titleBarImage.Dock      = DockStyle.Top;
        exitButton.Location     = new Point(1885, 0);
        minimizeButton.Location = new(exitButton.Location.X - exitButton.Width, minimizeButton.Location.Y);

        //CreateShape<triangleShape>();
        CreateShape<CrossShape>();
        CreateShape<Star4Points>();
        CreateShape<Star5Points>();
        CreateShape<Star6Points>();
        CreateShape<TrapazoidShape>();

        InitializeCustomTitleBar();
    }

    private void CreateShape<T>() where T : Shape, new()
    {
        var shape = new T();
        shape.Owner = this;
        shape.Show();
    }
    private void InitializeCustomTitleBar()
    {
        // Hide the default title bar
        ControlBox = false;
        Text = ""; // Optionally hide the form title text
    }

    // Handle the FormClosing event
    private void Form1_FormClosing(object sender, FormClosingEventArgs e)
    {
        // Check if the form is in full-screen mode
        if (true)
        {
            // Cancel the closing event
            e.Cancel = true;
            MessageBox.Show("Exiting full-screen mode is not allowed.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }

    private void exitButton_Click(object sender, EventArgs e) => Application.Exit();
    private void minimizeButton_Click(object sender, EventArgs e) => WindowState = FormWindowState.Minimized;

    private void exitButton_MouseHover(object sender, EventArgs e) => (exitButton.BackColor, exitButton.ForeColor) = (Color.FromArgb(255, 200, 50, 50), Color.White);

    private void exitButton_MouseLeave(object sender, EventArgs e) => (exitButton.BackColor, exitButton.ForeColor) = (SystemColors.Control, Color.Black);
}