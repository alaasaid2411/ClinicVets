namespace ClinicVets.UI;

/// <summary>
/// Placeholder screen for the next task: employee registration.
/// </summary>
public class RegisterEmployeeForm : Form
{
    public RegisterEmployeeForm()
    {
        InitializeComponent();
    }

    private void InitializeComponent()
    {
        Text = "ClinicVets - Register Employee";
        StartPosition = FormStartPosition.CenterParent;
        ClientSize = new Size(430, 220);
        Font = new Font("Segoe UI", 10F);
        BackColor = Color.FromArgb(245, 247, 251);

        Label titleLabel = new()
        {
            Text = "Register New Employee",
            Font = new Font("Segoe UI", 16F, FontStyle.Bold),
            Location = new Point(35, 35),
            Size = new Size(360, 40),
            TextAlign = ContentAlignment.MiddleCenter
        };

        Label messageLabel = new()
        {
            Text = "Employee registration will be implemented in the next task.",
            Location = new Point(35, 90),
            Size = new Size(360, 45),
            TextAlign = ContentAlignment.MiddleCenter
        };

        Button closeButton = new()
        {
            Text = "Back to login",
            Location = new Point(140, 150),
            Size = new Size(150, 32)
        };
        closeButton.Click += (_, _) => Close();

        Controls.Add(titleLabel);
        Controls.Add(messageLabel);
        Controls.Add(closeButton);
    }
}
