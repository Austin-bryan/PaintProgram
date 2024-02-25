/* Project: Paint
 * Authors: Austin Bryan, Lucius Miller, Noah Curtis
 * Class: Foundations in App Development
 * Date: February 24th, 2024*/

namespace PaintProgram;

// Purpose: Styles a form to look and behave like a control. 
public static class FormAsControlStyler
{
    public static void StyleFormAsControl(Form form)
    {
        // When I show people this code I like to display these 4 lines to break the illusion I've created
        form.BackColor       = Color.LimeGreen;
        form.TransparencyKey = form.BackColor;          // Makes it transparent
        form.ShowInTaskbar   = false;                   // Hides from taskbar and alt tab
        form.FormBorderStyle = FormBorderStyle.None;    // Hides the shadow and border
    }
}