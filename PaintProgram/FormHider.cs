/* Project: Paint
 * Authors: Austin Bryan, Lucius Miller, Noah Curtis
 * Class: Foundations in App Development
 * Date: February 24th, 2024*/



namespace PaintProgram;
public static class FormHider
{
    public static void Hide(Form form)
    {
        form.BackColor = Color.LimeGreen;
        form.TransparencyKey = form.BackColor;
        form.ShowInTaskbar = false;
        form.FormBorderStyle = FormBorderStyle.None;
    }
}
