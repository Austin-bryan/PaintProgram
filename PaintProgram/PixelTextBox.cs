/* Project: Paint
 * Authors: Austin Bryan, Lucius Miller, Noah Curtis
 * Class: Foundations in App Development
 * Date: February 24th, 2024
 */

using static PaintProgram.Shapes.ParametricShape;
namespace PaintProgram;

/* Purpose: Accepts a numeric value and can display "px" at the end for clearity, and has a customizable label */
public partial class PixelTextBox : UserControl
{
    public string Suffix { get; set; } = " px";     // Some pixelTextboxes will end in " px"
    public string LabelText { get => label.Text; set => label.Text = value; }
    public string TextBoxText
    {
        get => entryBox.Text;
        set
        {
            entryBox.Text = value;
            AddSuffix();
            lastValidString = entryBox.Text;        // Used to revert in case of a bad error input
        }
    }
    public bool AllowDecimals { get; set; }

    public delegate void InputSubmitHandler(double parsedTexxt);
    public event InputSubmitHandler InputSubmit;
    private AlphaHandle alphaHandle;

    private string lastValidString;

    public PixelTextBox()
    {
        DoubleBuffered = true;
        InitializeComponent();
    }

    public void UpdateAlphaBounds(AlphaHandle alphaHandle) => this.alphaHandle = alphaHandle;


    private void AddSuffix()
    {
        // Adds " px" if its supposed to have it
        if (Suffix.Length > 0 && !TextBoxText.Contains(Suffix))
            TextBoxText += Suffix;
        // If the user enters ".23" this adds a leading zero => "0.23"
        if (TextBoxText.Contains('.') && !TextBoxText.Contains("0."))
            TextBoxText = TextBoxText.Replace(".", "0.");
    }

    private void entryBox_Enter(object sender, EventArgs e)
    {
        if (Suffix.Length > 0 && TextBoxText.Contains(Suffix))  // Remove the px if the user is editing the box
            entryBox.Text = TextBoxText.Replace(Suffix, "");
        entryBox.SelectAll();
    }

    private void entryBox_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.KeyCode != Keys.Enter || e.KeyCode != Keys.Return)
            return;

        // Selects the next text box in line so the user can easily edit all parameters in a row
        SendKeys.Send("{TAB}");
        e.SuppressKeyPress = true;
    }

    private void entryBox_KeyPress(object sender, KeyPressEventArgs e)
    {
        if (!AllowDecimals && e.KeyChar == '.' 
            || !char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            e.Handled = true;   // Ignores any inputs that arent numbers, or if they are entering a decimal in a non decimal field
                                // This also prevents negative numbers for free
    }
    private void entryBox_Leave(object sender, EventArgs e)
    {
        // While I'm preventing the user from manually typing invalid characters, they are still able to paste invalid text with
        // invalid characters into the textbox. This solution was modeling after how photoshop does it, when the focus leaves
        // the textbox, it is checked for invalid characters, and I'm unable to parse a double, display an error message
        if (!string.IsNullOrEmpty(entryBox.Text) && !double.TryParse(entryBox.Text, out _))
        {
            MessageBox.Show("Invalid numeric entry. A valid entry must be entirely numeric. Restoring last valid entry.", "Paint Program", MessageBoxButtons.OK, MessageBoxIcon.Error);
            entryBox.Text = lastValidString;
            return;
        }

        double parsedValue = double.Parse(TextBoxText);

        if (alphaHandle != null)
        {
            parsedValue = Math.Clamp(parsedValue, alphaHandle.MinAlpha, alphaHandle.MaxAlpha);
            TextBoxText = parsedValue.ToString();
        }
        
        AddSuffix();
        lastValidString = TextBoxText;

        InputSubmit(parsedValue);
    }
}