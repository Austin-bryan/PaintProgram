using static PaintProgram.Shapes.ParametricShape;

namespace PaintProgram;

public partial class PixelTextBox : UserControl
{
    public string TextBoxText { get; set; }
    public string LabelText { get; set; }
    public bool AllowDecimals { get; set; }

    public delegate void InputSubmitHandler(double parsedTexxt);
    public event InputSubmitHandler InputSubmit;

    public PixelTextBox() => InitializeComponent();

    public void UpdateAlphaBounds(AlphaHandle alphaHandle) 
    {
    }
}
