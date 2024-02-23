using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
        {
            ((ShapeButton)control).Form1Instance = (Form1)Owner;
        }
    }

    private void rectangle_Load(object sender, EventArgs e)
    {

    }

    private void shapeButton10_Load(object sender, EventArgs e)
    {

    }

    private void shapeButton11_Load(object sender, EventArgs e)
    {
    }

    private void shapeButton12_Load(object sender, EventArgs e)
    {

    }

    private void shapeButton14_Load(object sender, EventArgs e)
    {
    }

    private void shapeButton13_Load(object sender, EventArgs e)
    {
    }

    private void shapeButton7_Load(object sender, EventArgs e)
    {
    }

    private void shapeButton8_Load(object sender, EventArgs e)
    {
    }

    private void shapeButton6_Load(object sender, EventArgs e)
    {
    }

    private void shapeButton5_Load(object sender, EventArgs e)
    {
    }

    private void shapeButton3_Load(object sender, EventArgs e)
    {
    }

    private void shapeButton4_Load(object sender, EventArgs e)
    {
    }

    private void shapeButton9_Load(object sender, EventArgs e)
    {
    }

    private void ToolBarForm_Load(object sender, EventArgs e)
    {

    }

    private void shapeButton2_Load(object sender, EventArgs e)
    {
    }

    private void shapeButton2_Load_1(object sender, EventArgs e)
    {

    }
}
