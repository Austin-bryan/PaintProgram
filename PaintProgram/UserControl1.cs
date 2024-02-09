using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PaintProgram;

public partial class UserControl1 : UserControl
{
    public UserControl1() => InitializeComponent();

    private const int WM_GETMINMAXINFO = 0x0024;

    protected override CreateParams CreateParams
    {
        get
        {
            var cp = base.CreateParams;
            cp.Style |= 0x840000;  // Turn on WS_BORDER + WS_THICKFRAME
            return cp;
        }
    }

    protected override void WndProc(ref Message m)
    {
        base.WndProc(ref m);

        if (m.Msg == WM_GETMINMAXINFO)
        {
            MINMAXINFO minMaxInfo = (MINMAXINFO)Marshal.PtrToStructure(m.LParam, typeof(MINMAXINFO));
            minMaxInfo.ptMinTrackSize.X = 0;
            minMaxInfo.ptMinTrackSize.Y = 0;
            Marshal.StructureToPtr(minMaxInfo, m.LParam, false);
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    private struct POINT
    {
        public int X;
        public int Y;
    }

    [StructLayout(LayoutKind.Sequential)]
    private struct MINMAXINFO
    {
        public POINT ptReserved;
        public POINT ptMaxSize;
        public POINT ptMaxPosition;
        public POINT ptMinTrackSize;
        public POINT ptMaxTrackSize;
    }

private void UserControl1_Load(object sender, EventArgs e)
    {

    }
}
