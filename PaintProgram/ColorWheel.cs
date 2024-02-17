
using System.Drawing;
using System.Runtime.InteropServices;

namespace PaintProgram;

public partial class ColorWheel : UserControl
{

    public ColorWheel()
    {
        InitializeComponent();
    }

    private void pictureBox3_MouseMove(object sender, MouseEventArgs e)
    {

        Point cursor = Cursor.Position;

        // Create a bitmap of the screen
        Bitmap screen = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);

        // Create a graphics object from the bitmap
        using (Graphics g = Graphics.FromImage(screen))
        {
            // Copy the screen to the bitmap
            g.CopyFromScreen(0, 0, 0, 0, screen.Size);
        }

        // Get the color of the pixel at the cursor location
        Color pixelColor = screen.GetPixel(cursor.X, cursor.Y);

        pictureBox1.BackColor = pixelColor;
    }
}

