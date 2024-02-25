/* Project: Paint
 * Authors: Austin Bryan, Lucius Miller, Noah Curtis
 * Class: Foundations in App Development
 * Date: February 24th, 2024*/

using PaintProgram.Shapes;
using System.Drawing.Drawing2D;
using static System.Windows.Forms.AxHost;
namespace PaintProgram;

/*
 * There was a specific design desicion that was made that will make certain code seem confusing if you don't know what problem they solve. For example,
 * I'm using a custom title bar, instead of the built in title bar. But this all serves a purpose. 
 * 
 * All the shapes their own separate windows forms. While this sounds insane and overly complicated,
 * it was actually neccessary. After a lot of research, everything I pointed to showed that it is impossible to have controls with a transparent
 * background in winforms. This is apparently a fundemantal limitation of the engine. There is a "transparent" color setting in winforms, but if
 * used that does not actually give transparency. What it does is it gives the control a BackColor, but that backcolor is simply the back color of 
 * the parent form. THis will make it *look* transparent, but once the player clicks and drags one shape over another, it will hide what is behind it. 
 * 
 * Ive included a jpg called EXAMPLE OF USING CONTROLS INSTEAD OF FORMS to show what this looks like, but basically if two shapes overlap, there will 
 * be a big square behind the upper image, so if it was a triangle, where ever the gaps are will be a white background, covering the shapes below it. 
 * This was very unappealing visually and made it impossible to make satisifying shapes. I was never going to be able to create a project that I was 
 * proud of had I used controls, as its so visually unsatisfying.
 * The only way to fix this was to make the shapes be a form,
 * because forms support transparency. This design decision required many more changes:
 * 
 * Any UI that needs to appear on top of the shapes needs to also be its own form, that way it can appear above. 
 * These forms need to be constantly readjusted ontop to create the illusion properly. 
 * I have to run this application in maximized mode because if in window mode, it would have been possible to drag the shapes out the window. 
 * I couldn't find a way to remove the windowed button, so I had to make a custom titlebar, that removes that option, so you can only minimize or close.
 * 
 * I made several features to create the illusion that the shapes are actually controls:
 *     I hid the title bar
 *     Forms have boarders and shadows, these have been disabled
 *     The background has been set to transparent
 *     Shapes are removed from the task bar, so they are not visible via alt tab, which happens by default, and is very confusing. 
 *     
 * The result is very seemless and I don't think its noticable, and I got the desired result. This was the solution I was able to find while research this.
 * I recognized the unorthodox nature of this solution, which is why if this was a commerical product, I would have instead used WPF, where
 * Not only transparency for controls exists, but controls can be rotated, which would have been very nice feature to add. 
 */


/*
 * Main form has two primary functions. Obviously this violates the Single Responsibility Principle, but the second responsibilty was 
 * written by a teammate and it would've been too much work to move the code else where. 
 * 
 * Responsibility 1. Creating and managing the other forms. MainForm creates the shapes, which again are other forms themselves, which require
 *      the titlebar, and shape editor and tool bar.
 * Responsibility 2. Handling the painting with brushes, pens, erasers and fountain pens. The painting is done on a specfic paint panel that spans
 *      the entire form. Ideally this would be a separate control, but the code works, and I'm impressed with his work. 
 */
public partial class MainForm : Form
{
    public enum EPaintTool { None, Brush, Spray, Fountain, Eraser } // The different paint tools

    public static Size ScreenSize => Screen.PrimaryScreen.Bounds.Size;
    public int TitleBarHeight => titleBar.BarHeight;

    // The paint tool the user is currently using
    private EPaintTool _activePaintTool = EPaintTool.None;
    public EPaintTool ActivePaintTool   
    {
        get => _activePaintTool;
        set => (_activePaintTool, Cursor) = (value, value == EPaintTool.None ? Cursors.Default : GetCircularCursor(paintSizes[value]));
    }
    
    private Color paintColor = Color.Black; // default painting color
    public Color PaintColor
    {
        get => paintColor;
        set => (paintColor, pen.Color, brush) = (value, value, new SolidBrush(value));
    }

    public Dictionary<EPaintTool, int> PaintSizes => paintSizes;

    private readonly Brush eraserBrush;
    private readonly List<Shape> shapes      = new();
    private readonly TitleBar    titleBar    = new();
    private readonly ToolBarForm toolBarForm = new();
    private readonly ShapeEditor shapeEditor = new();

    // Each paint tool as their own independent size that is maintained during brush changes
    private readonly Dictionary<EPaintTool, int> paintSizes = new()
    {
        { EPaintTool.None, 0 },
        { EPaintTool.Brush, 10 },
        { EPaintTool.Spray, 32 },
        { EPaintTool.Eraser, 20 },
        { EPaintTool.Fountain, 3 }
    };

    private readonly Graphics g;
    private readonly Pen pen;
    private Brush brush;
    private int brushStartX = -1, brushStartY = -1; 
    private bool mouseIsDown = false; 

    public MainForm()
    {
        InitializeComponent();
        WindowState = FormWindowState.Maximized;

        // Paint panel is used for painting and needs to be as big as the screen
        paintPanel.Size = ScreenSize;
        paintPanel.Size += new Size(200, 200);
        paintPanel.BackColor = BackColor;

        // Hides the real title bar and makes way for the new one. 
        // The custom title bar is needed so that shapes won't be drawn on top of the titlebar
        FormBorderStyle = FormBorderStyle.None;
        ControlBox = false;

        // Toolbar is used to create shapes, chose painting tool and adjust brush size
        toolBarForm.Show();
        toolBarForm.Owner    = this;
        toolBarForm.Location = new Point(20, 60);

        // Setting up custom title bar
        titleBar.Show();
        titleBar.Owner    = this;

        // Shape editor is using for selecting colors and setting parameters for the shapes
        shapeEditor.Owner = this;

        // These are needed for the painting process
        g               = paintPanel.CreateGraphics();
        g.SmoothingMode = SmoothingMode.AntiAlias;
        brush           = new SolidBrush(PaintColor);
        pen             = new Pen(PaintColor, paintSizes[EPaintTool.Brush]);
        eraserBrush     = new SolidBrush(BackColor);
        pen.StartCap    = pen.EndCap = LineCap.Round;
    }

    public void HideShapeEditor()
    {
        // Shape Editor is being reset before hidden, because if it is reset after showing a visual glitch occurs
        // If it is reset while it is hidden (before .Show() is called) the new location is not applied
        ResetShapeEditorLocation();
        shapeEditor.Hide();
    }

    // The brush menu and shapes both open Shape editor, so they both need to know what color is picked
    // Hence I pass a lambda that accepts color as an argument, that is later called in this function
    // I could have probably used events here, but that would require unsubscribing from the event, so this felt simpler.
    public void ShowShapeEditor(Action<Color> onSelectColor, Shape shape = null)
    {
        bool oldVisibility = shapeEditor.Visible;
        
        shapeEditor.Show();
        shapeEditor.OnSelectColor = onSelectColor;
        shapeEditor.ActiveShape   = shape;  // Shape is only null if ShapeEditor is opened by BrushTool

        if (!oldVisibility)
            ResetShapeEditorLocation();
    }
    public void RefreshShapeEditor() => shapeEditor?.RefreshShapeEditor();
    public void CreateShape<T>() where T : Shape, new()
    {
        var shape = new T { Owner = this };
        shape.Show();
        shapes.Add(shape);
        BringTopUIToFront();
    }
    // Gets a new cursor of the right size, and caches the new size for the tool being used
    public void SetBrushSize(int newSize) => (paintSizes[ActivePaintTool], Cursor) = (newSize, GetCircularCursor(newSize));

    // Whenever a shape is brought to the front, it will naturally overlap these three forms, so these are brought to be in front of that
    public void BringTopUIToFront()
    {
        titleBar.BringToFront();
        toolBarForm.BringToFront();
        shapeEditor.BringToFront();
    }

    public static Cursor GetCircularCursor(int diameter)
    {
        // Creates a circular bitmap image to use as the cursor when using a paint tool
        Bitmap cursorImage = new (diameter + 10, diameter + 10);

        using (Graphics g = Graphics.FromImage(cursorImage))
        {
            g.Clear(Color.Transparent);
            g.DrawEllipse(new Pen(Brushes.Black, 2), 5, 5, diameter, diameter); // Draw a black circle
        }
        return new Cursor(cursorImage.GetHicon());
    }

    //gets a random point around a circle
    private static Point GetRandomPoint(int x, int y, int radius)
    {
        Random random       = new();
        double angle        = random.NextDouble() * 2 * Math.PI;                    // Random angle between 0 and 2*pi
        double randomRadius = Math.Sqrt(random.NextDouble()) * (radius / 2); // Random radius between 0 and maxRadius

        // Calculate the x and y coordinates using polar to Cartesian conversion
        int randomX = x + (int)(randomRadius * Math.Cos(angle));
        int randomY = y + (int)(randomRadius * Math.Sin(angle));

        return new Point(randomX, randomY);
    }
    
    // Brings the ShapeEditor back to a default location
    private void ResetShapeEditorLocation() => shapeEditor.Location = titleBar.ExitButtonLocation.Subtract(new Point(shapeEditor.Width - 20, -60));
    private void Form1_Click(object sender, EventArgs e)
    {
        // Hides the UI for resizes shapes and the panel on the right side of the editor
        shapes.ForEach(s => s.HideHandles());
        shapeEditor.Hide();
    }

    // Returns a different thickness based on whether the user move mostly horiziontally or mostly vertically
    private int DetermineFountainThickness(int x, int y, int fountain)
    {
        double x2 = brushStartX - x; 
        double y2 = brushStartY - y;
        return x2 < y2 * 500 ? fountain * 4 : fountain;
    }

    // The function which draws onto the panel
    private void PaintScreen(int x, int y)
    {
        switch (ActivePaintTool)
        {
            // Basic paint
            case EPaintTool.Brush: 
                pen.Width = paintSizes[EPaintTool.Brush];
                g.DrawLine(pen, new Point(brushStartX, brushStartY), new Point(x, y));
                break;
                
            // Randomly sprays dots in a circular radius
            case EPaintTool.Spray: 
                for (int i = 0; i < 100; i++)
                {
                    Point randomPoint = GetRandomPoint(x, y, paintSizes[EPaintTool.Spray]);
                    g.FillEllipse(brush, randomPoint.X, randomPoint.Y, 2, 2);
                }
                break;
            // Draws like a fountain pen, where its thinner or thicker depending on direction
            case EPaintTool.Fountain:
                int fountainRadius = paintSizes[EPaintTool.Fountain];
                int width = DetermineFountainThickness(x, y, fountainRadius);
                g.FillRectangle(brush, x, y,  width, fountainRadius);
                break;
            // Erases anything thats drawn
            case EPaintTool.Eraser: 

                int eraserRadius = paintSizes[EPaintTool.Eraser];
                g.FillEllipse(eraserBrush, x - eraserRadius / 2, y - eraserRadius / 2, eraserRadius, eraserRadius);
                break;
        }
    }

    // Activates painting mode
    private void paintPanel_MouseDown(object sender, MouseEventArgs e)
    {
        shapes.ForEach(s => s.HideHandles());
        
        // Only paint if a tool is selected
        if (ActivePaintTool == EPaintTool.None)
             HideShapeEditor();
        else brush = new SolidBrush(paintColor);

        // Allows brushing by simply clicking the screen, without dragging
        (brushStartX, brushStartY) = (e.X, e.Y);
        PaintScreen(e.X, e.Y);
        mouseIsDown = true;
    }

    // Recalculates the brushStart every function call to determine how to paint
    private void paintPanel_MouseMove(object sender, MouseEventArgs e)
    {
        if (mouseIsDown && brushStartX != -1 && brushStartY != -1)
        {
            PaintScreen(e.X, e.Y);
            (brushStartX, brushStartY) = (e.X, e.Y);
        }
    }
    private void paintPanel_MouseUp(object sender, MouseEventArgs e) => mouseIsDown = false;
}