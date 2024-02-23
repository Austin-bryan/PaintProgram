using static PaintProgram.Shapes.ParametricShape;

namespace PaintProgram;

public partial class PixelTextBox : UserControl
{
    public string Suffix      { get; set; } = " px";
    public string LabelText   { get => label.Text; set => label.Text = value; }
    public string TextBoxText
    {
        get => entryBox.Text;
        set
        {
            entryBox.Text = value;
            AddSuffix();
        }
    }
    public bool AllowDecimals { get; set; }

    public delegate void InputSubmitHandler(double parsedTexxt);
    public event InputSubmitHandler InputSubmit;

    public PixelTextBox() => InitializeComponent();

    public void UpdateAlphaBounds(AlphaHandle alphaHandle)
    {
    }

    private void entryBox_Leave(object sender, EventArgs e)
    {
        AddSuffix();
    }

    private void AddSuffix()
    {
        if (Suffix.Length > 0 && !TextBoxText.Contains(Suffix))
            TextBoxText += Suffix;
    }

    private void entryBox_Enter(object sender, EventArgs e)
    {
        if (Suffix.Length > 0 && TextBoxText.Contains(Suffix))
            entryBox.Text = TextBoxText.Replace(Suffix, "");
        entryBox.SelectAll();
    }

    private void entryBox_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.KeyCode != Keys.Enter || e.KeyCode != Keys.Return)
            return;

        SendKeys.Send("{TAB}");
        e.SuppressKeyPress = true;
    }
}
