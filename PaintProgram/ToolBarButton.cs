/* Project: Paint
 * Authors: Noah Curtis, Austin Bryan, Lucius Miller
 * Class: Foundations in App Development
 * Date: February 24th, 2024*/





namespace PaintProgram;

public partial class ToolBarButton : UserControl
{
    public Image Image
    {
        get => button1.Image;
        set
        {
            if (value == null)
                return;

            button1.Image = value;
        }
    }

    public ToolBarButton() => InitializeComponent();
}