using static PaintProgram.Shapes.ParametricShape;
using static System.Net.Mime.MediaTypeNames;

namespace PaintProgram;

public partial class PixelTextBox : UserControl
{
    public string Suffix { get; set; } = " px";
    public string LabelText { get => label.Text; set => label.Text = value; }
    public string TextBoxText
    {
        get => entryBox.Text;
        set
        {
            entryBox.Text = value;
            AddSuffix();
            lastValidString = entryBox.Text;
        }
    }
    public bool AllowDecimals { get; set; }

    public delegate void InputSubmitHandler(double parsedTexxt);
    public event InputSubmitHandler InputSubmit;

    private string lastValidString;

    public PixelTextBox()
    {
        DoubleBuffered = true;
        InitializeComponent();
    }

    public void UpdateAlphaBounds(AlphaHandle alphaHandle)
    {
        double parsedValue = double.Parse(TextBoxText);
    }

    private void entryBox_Leave(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(entryBox.Text) && !double.TryParse(entryBox.Text, out _))
        {
            MessageBox.Show("Invalid numeric entry. A valid entry must be entirely numeric. Restoring last valid entry.", "Paint Program", MessageBoxButtons.OK, MessageBoxIcon.Error);
            entryBox.Text = lastValidString;
        }
        AddSuffix();

        string text = TextBoxText;

        if (Suffix.Length > 0)
            text = text.Replace(Suffix, "");
        double parsedValue = double.Parse(text);
        
        lastValidString = text;

        InputSubmit(parsedValue);
    }

    private void AddSuffix()
    {
        if (Suffix.Length > 0 && !TextBoxText.Contains(Suffix))
            TextBoxText += Suffix;
        if (TextBoxText.Contains('.') && !TextBoxText.Contains("0."))
            TextBoxText = TextBoxText.Replace(".", "0.");
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

    private void entryBox_KeyPress(object sender, KeyPressEventArgs e)
    {
        if (AllowDecimals && e.KeyChar == '.')
            return;
        if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            e.Handled = true;
    }

    private bool isHandlingTextChanged = false;

    private void entryBox_TextChanged(object sender, EventArgs e)
    {
        if (isHandlingTextChanged)
            return;
        
        isHandlingTextChanged = true;

        //if (!string.IsNullOrEmpty(entryBox.Text) && !IsNumeric(entryBox.Text))
        //{
        //    MessageBox.Show("Test");
        //    entryBox.Text = lastValidString;
        //}

        lastValidString = TextBoxText;

        //isHandlingTextChanged = false;

        return;

        bool IsNumeric(string text)
        {
            return double.TryParse(text, out _);
        }
    }
}
