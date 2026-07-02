
using System.Drawing;
using System.Windows.Forms;

public static class FormHelpers
{
    public static void ApplyModernStyle(Form form)
    {
        form.BackColor = Color.White;
        form.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
        form.FormBorderStyle = FormBorderStyle.None;
        form.Dock = DockStyle.Fill;
    }

    public static void ShowFormInPanel(Form form, Panel container)
    {
        form.TopLevel = false;
        form.FormBorderStyle = FormBorderStyle.None;
        form.Dock = DockStyle.Fill;
        container.Controls.Add(form);
        container.Tag = form;
        form.BringToFront();
        form.Show();
    }
}