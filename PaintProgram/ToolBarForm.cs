using PaintProgram.Shapes;
using PaintProgram.Shapes.NGons;

namespace PaintProgram;

public partial class ToolBarForm : Form
{
    private Form1 MainForm => (Form1)Owner;
    private bool IsBrushActive { set => sizePanel.Visible = value; }
    private readonly ClickDragMover clickDragMover = new();

    public ToolBarForm()
    {
        InitializeComponent();
        FormHider.Hide(this);
        IsBrushActive = false;

    }

    private void squareBtn_Click(object sender, EventArgs e) => MainForm.CreateShape<RectangleShape>();
    private void triangleBtn_Click(object sender, EventArgs e) => MainForm.CreateShape<TriangleShape>();
    private void rightTriangleBtn_Click(object sender, EventArgs e) => MainForm.CreateShape<RightTriangleShape>();
    private void ellipseBtn_Click(object sender, EventArgs e) => MainForm.CreateShape<EllipseShape>();
    private void crossBtn_Click(object sender, EventArgs e) => MainForm.CreateShape<CrossShape>();
    private void star4Btn_Click(object sender, EventArgs e) => MainForm.CreateShape<Star4Points>();
    private void star5Btn_Click(object sender, EventArgs e) => MainForm.CreateShape<Star5Points>();
    private void star6Btn_Click(object sender, EventArgs e) => MainForm.CreateShape<Star6Points>();
    private void pentagonBtn_Click(object sender, EventArgs e) => MainForm.CreateShape<PentagonShape>();
    private void hexagonBtn_Click(object sender, EventArgs e) => MainForm.CreateShape<HexagonShape>();
    private void septagonBtn_Click(object sender, EventArgs e) => MainForm.CreateShape<SeptagonShape>();
    private void decagonBtn_Click(object sender, EventArgs e) => MainForm.CreateShape<DecagonShape>();
    private void trapazoidBtn_Click(object sender, EventArgs e) => MainForm.CreateShape<TrapazoidShape>();
    private void arrowBtn_Click(object sender, EventArgs e) => MainForm.CreateShape<ArrowShape>();
    private void doubleArrowBtn_Click(object sender, EventArgs e) => MainForm.CreateShape<DoubleArrowShape>();
    private void chevronBtn_Click(object sender, EventArgs e) => MainForm.CreateShape<ChevronShape>();

    private void cursorBtn_Click(object sender, EventArgs e)
    {
        IsBrushActive = false;
        MainForm.ActivePaintTool = Form1.EPaintTool.None;
        MainForm.HideShapeEditor();
    }

    private void brushBtn_Click  (object sender, EventArgs e) => ActivatePaintTool(Form1.EPaintTool.Brush);
    private void eraserBtn_Click (object sender, EventArgs e) => ActivatePaintTool(Form1.EPaintTool.Eraser, false);
    private void sprayBtn_Click  (object sender, EventArgs e) => ActivatePaintTool(Form1.EPaintTool.Spray);
    private void inkBtn_Click    (object sender, EventArgs e) => ActivatePaintTool(Form1.EPaintTool.Fountain);

    private void ActivatePaintTool(Form1.EPaintTool paintTool, bool showEditor = true)
    {
        IsBrushActive            = true;
        MainForm.ActivePaintTool = paintTool;
        trackBar1.Value          = MainForm.PaintSizes[MainForm.ActivePaintTool];
        sizePixelBox.TextBoxText = trackBar1.Value.ToString();

        if (showEditor)
             MainForm.ShowShapeEditor((color) => MainForm.PaintColor = color);
        else MainForm.HideShapeEditor();
    }

    private void trackBar1_Scroll(object sender, EventArgs e)
    {
        MainForm.SetBrushSize(trackBar1.Value);
        sizePixelBox.TextBoxText = trackBar1.Value.ToString();
    }

    private void sizePixelBox_InputSubmit(double parsedText)
    {
        parsedText = Math.Clamp(parsedText, trackBar1.Minimum, trackBar1.Maximum);
        trackBar1.Value = (int)parsedText;
        sizePixelBox.TextBoxText = parsedText.ToString();

        MainForm.SetBrushSize(trackBar1.Value);
    }

    private void headerBackground_MouseDown(object sender, MouseEventArgs e) => clickDragMover.OnMouseDown(e);
    private void headerBackground_MouseEnter(object sender, EventArgs e)     => Cursor = Cursors.SizeAll;
    private void headerBackground_MouseLeave(object sender, EventArgs e)     => Cursor = Cursors.Default;
    private void headerBackground_MouseUp(object sender, MouseEventArgs e)   => clickDragMover.OnMouseUp(e);
    private void headerBackground_MouseMove(object sender, MouseEventArgs e) => Location = clickDragMover.OnMouseMove(Location, e, (Form1)Owner, true) ?? Location;
}//77