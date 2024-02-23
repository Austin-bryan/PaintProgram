using PaintProgram.Shapes;
using System.ComponentModel;

namespace PaintProgram;

public partial class BrushButton : ToolBarButton
{
    public enum Brush { Brush, Eraser, Ink, Spray}


    [Browsable(true)]
    [Category("Shapes")]
    [EditorBrowsable(EditorBrowsableState.Always)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    public Form1 Form1Instance { get; set; }

    public BrushButton()
    {
        int @char = 3;
        InitializeComponent();
        button1.Text = String.Empty;
    }
}
