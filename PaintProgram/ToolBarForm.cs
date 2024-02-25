/* Project: Paint
 * Authors: Austin Bryan, Lucius Miller, Noah Curtis
 * Class: Foundations in App Development
 * Date: February 24th, 2024*/

using PaintProgram.Shapes;
using PaintProgram.Shapes.NGons;

namespace PaintProgram;

/*
 * In this form, the user can click on 1 out of 16 shapes to create,
 * Choose which paint tool to use { Cursor (none), Brush, Eraser, Spray Paint, and Fountain }
 * This form also uses the ClickDragMover which enables it to be clicked and dragged.
 */
public partial class ToolBarForm : Form
{
    private MainForm MainForm => (MainForm)Owner;                     // This is used frequently so making it a readonly-property makes typing easier
    private bool IsBrushActive { set => sizePanel.Visible = value; }  // The settings for brush size are hidden if the cursor is selected

    private readonly Color defaultPaintToolColor;
    private readonly ClickDragMover clickDragMover = new();

    public ToolBarForm()
    {
        InitializeComponent();
        FormAsControlStyler.StyleFormAsControl(this);
        defaultPaintToolColor = Color.FromArgb(255, 120, 120, 120);

        ShowButtonSelection(cursorBtn);
        IsBrushActive = false;
    }

    // These methods are used to create shapes depending on which button was pressed
    private void squareBtn_Click        (object sender, EventArgs e) => MainForm.CreateShape<RectangleShape>();
    private void triangleBtn_Click      (object sender, EventArgs e) => MainForm.CreateShape<TriangleShape>();
    private void rightTriangleBtn_Click (object sender, EventArgs e) => MainForm.CreateShape<RightTriangleShape>();
    private void ellipseBtn_Click       (object sender, EventArgs e) => MainForm.CreateShape<EllipseShape>();
    private void crossBtn_Click         (object sender, EventArgs e) => MainForm.CreateShape<CrossShape>();
    private void star4Btn_Click         (object sender, EventArgs e) => MainForm.CreateShape<Star4Points>();
    private void star5Btn_Click         (object sender, EventArgs e) => MainForm.CreateShape<Star5Points>();
    private void star6Btn_Click         (object sender, EventArgs e) => MainForm.CreateShape<Star6Points>();
    private void pentagonBtn_Click      (object sender, EventArgs e) => MainForm.CreateShape<PentagonShape>();
    private void hexagonBtn_Click       (object sender, EventArgs e) => MainForm.CreateShape<HexagonShape>();
    private void septagonBtn_Click      (object sender, EventArgs e) => MainForm.CreateShape<SeptagonShape>();
    private void decagonBtn_Click       (object sender, EventArgs e) => MainForm.CreateShape<DecagonShape>();
    private void trapazoidBtn_Click     (object sender, EventArgs e) => MainForm.CreateShape<TrapazoidShape>();
    private void arrowBtn_Click         (object sender, EventArgs e) => MainForm.CreateShape<ArrowShape>();
    private void doubleArrowBtn_Click   (object sender, EventArgs e) => MainForm.CreateShape<DoubleArrowShape>();
    private void chevronBtn_Click       (object sender, EventArgs e) => MainForm.CreateShape<ChevronShape>();

    // Deactivates the brush tool, hides the color wheel
    private void cursorBtn_Click(object sender, EventArgs e)
    {
        ShowButtonSelection(cursorBtn);
        IsBrushActive = false;
        MainForm.ActivePaintTool = MainForm.EPaintTool.None;
        MainForm.HideShapeEditor();

    }

    // Each of the paint tool buttons changes the active tool
    private void brushBtn_Click (object sender, EventArgs e) => ActivatePaintTool(brushBtn,  MainForm.EPaintTool.Brush);
    private void eraserBtn_Click(object sender, EventArgs e) => ActivatePaintTool(eraserBtn, MainForm.EPaintTool.Eraser, false);
    private void sprayBtn_Click (object sender, EventArgs e) => ActivatePaintTool(sprayBtn,  MainForm.EPaintTool.Spray);
    private void inkBtn_Click   (object sender, EventArgs e) => ActivatePaintTool(inkBtn,    MainForm.EPaintTool.Fountain);

    private void ActivatePaintTool(Button button, MainForm.EPaintTool paintTool, bool showEditor = true)
    {
        ShowButtonSelection(button);

        IsBrushActive            = true;
        MainForm.ActivePaintTool = paintTool;
        trackBar1.Value          = MainForm.PaintSizes[MainForm.ActivePaintTool];
        sizePixelBox.TextBoxText = trackBar1.Value.ToString();

        // This allows the paint tools to show the color wheel, but have eraser hide it
        if (showEditor)
             MainForm.ShowShapeEditor((color) => MainForm.PaintColor = color);
        else MainForm.HideShapeEditor();
    }
    // Darkens the button to show which tool is selected
    private void ShowButtonSelection(Button button)
    {
        foreach (var control in brushToolPanel.Controls)
            if (control is Button otherButton)
                otherButton.BackColor = defaultPaintToolColor;
        button.BackColor = Color.FromArgb(255, 45, 45, 45);
    }

    // Sets the size of the brush tool
    private void trackBar1_Scroll(object sender, EventArgs e)
    {
        MainForm.SetBrushSize(trackBar1.Value);
        sizePixelBox.TextBoxText = trackBar1.Value.ToString();
    }

    // Allows the user to manually set the brush size via text
    private void sizePixelBox_InputSubmit(double parsedText)
    {
        parsedText               = Math.Clamp(parsedText, trackBar1.Minimum, trackBar1.Maximum);    // Clamps to correct value
        trackBar1.Value          = (int)parsedText;
        sizePixelBox.TextBoxText = parsedText.ToString();                                           // Updates the text box in the event it was clamped

        MainForm.SetBrushSize(trackBar1.Value);
    }

    // These methods allow the movement of the toolbar, when the dark pane is hovered
    private void headerBackground_MouseDown  (object sender, MouseEventArgs e) => clickDragMover.OnMouseDown(e);
    private void headerBackground_MouseEnter (object sender, EventArgs e)      => Cursor = Cursors.SizeAll;
    private void headerBackground_MouseLeave (object sender, EventArgs e)      => Cursor = Cursors.Default;
    private void headerBackground_MouseUp    (object sender, MouseEventArgs e) => clickDragMover.OnMouseUp(e);
    private void headerBackground_MouseMove  (object sender, MouseEventArgs e) => Location = clickDragMover.OnMouseMove(Location, e, (MainForm)Owner, true) ?? Location;

}//77