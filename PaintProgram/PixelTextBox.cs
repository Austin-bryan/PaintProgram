using static PaintProgram.Shapes.ParametricShape;

namespace PaintProgram;

public partial class PixelTextBox : UserControl
{
    public string LabelText
    {
        get => label.Text; set => label.Text = value;
    }
    public string TextBoxText
    {
        get => entryBox.Text; set => entryBox.Text = value;
    }
    public bool AllowDecimals { get; set; }

    public delegate void InputSubmitHandler(double parsedTexxt);
    public event InputSubmitHandler InputSubmit;

    public PixelTextBox() => InitializeComponent();

    public void UpdateAlphaBounds(AlphaHandle alphaHandle) 
    {
    }
}
