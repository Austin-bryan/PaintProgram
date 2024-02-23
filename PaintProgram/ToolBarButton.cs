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

            const int size = 40;
            Bitmap bitmap = new Bitmap(button1.Image, size, size);
            button1.Image = bitmap;
        }
    }

    public ToolBarButton() => InitializeComponent();
}