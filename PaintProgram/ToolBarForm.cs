namespace PaintProgram;

public partial class ToolBarForm : Form
{
    public ToolBarForm()
    {
        InitializeComponent();
        FormHider.Hide(this);
    }
    public void InitOwner()
    {
        foreach (var control in buttonPanel.Controls)
            if (control is ShapeButton shapeButton)
                shapeButton.Form1Instance = (Form1)Owner;
    }
}