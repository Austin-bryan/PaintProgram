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
