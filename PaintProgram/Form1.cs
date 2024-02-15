using PaintProgram.Shapes;
using System.ComponentModel;

namespace PaintProgram;

public partial class Form1 : Form
{
    private readonly List<Shape> shapes = new();
    private readonly TitleBar titleBar = new();
    public Form1()
    {
        InitializeComponent();
        WindowState = FormWindowState.Maximized;

        //titleBar.TopMost = true;
        titleBar.Show();
        titleBar.Owner = this;

        CreateShape<TriangleShape>();
        CreateShape<RightTriangleShape>();
        CreateShape<CrossShape>();
        CreateShape<Star4Points>();
        CreateShape<Star5Points>();
        CreateShape<Star6Points>();
        CreateShape<TrapazoidShape>();

        InitializeCustomTitleBar();
    }
    
    private void CreateShape<T>() where T : Shape, new()
    {
        var shape = new T { Owner = this };
        shape.Show();
        shapes.Add(shape);
        foobar();
    }

    public void foobar()
    {
        titleBar.BringToFront();
    }

    private void InitializeCustomTitleBar()
    {
        FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
        ControlBox = false;
    }
    private void Form1_Click(object sender, EventArgs e) => shapes.ForEach(s => s.HideHandles());

    private void Form1_Leave(object sender, EventArgs e)
    {
        //titleBar.Visible = false;
        //MessageBox.Show("Test");
    }
    private bool wasActivated = false;

    private void Form1_Deactivate(object sender, EventArgs e)
    {
        //titleBar.Visible = false;
        //wasActivated = false;
    }

    private void Form1_Activated(object sender, EventArgs e)
    {
        //try
        //{
        //if (titleBar != null)
        ShowTitleBar();

        //}
        //catch (Win32Exception winE)
        //{

        //}
        wasActivated = true;
    }

    private void Form1_Enter(object sender, EventArgs e)
    {
        if (wasActivated)
            ShowTitleBar();
    }

    public void ShowTitleBar(bool value = true)
    {
        //label1.Text = "";
        //shapes.ForEach(s => label1.Text = label1.Text + "\n" + s.GetType().Name + s.hasFocus);
        //titleBar.Visible = value;
    }
    public void Foo(Form form) => label1.Text = form.GetType().Name;
    public void Foo(string str) => label1.Text = str;

    private void Form1_VisibleChanged(object sender, EventArgs e)
    {
        //ShowTitleBar(Visible);
    }

    private void Form1_ClientSizeChanged(object sender, EventArgs e)
    {
    }
}
