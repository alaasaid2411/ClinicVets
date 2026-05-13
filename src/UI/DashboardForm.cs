using ClinicVets.Services;

namespace ClinicVets.UI;

/// <summary>
/// Simple home screen shown after a successful login.
/// </summary>
public class DashboardForm : Form
{
    private readonly AuthService _authService;

    public DashboardForm(AuthService authService)
    {
        _authService = authService;
        InitializeComponent();
    }

    private void InitializeComponent()
    {
        Text = "ClinicVets - Dashboard";
        StartPosition = FormStartPosition.CenterParent;
        ClientSize = new Size(460, 260);
        Font = new Font("Segoe UI", 10F);
        BackColor = Color.FromArgb(245, 247, 251);

        string fullName = _authService.CurrentUser?.Username ?? "Unknown user";
        string role = _authService.CurrentUser?.Role.ToString() ?? "Unknown role";

        Label titleLabel = new()
        {
            Text = "ClinicVets Dashboard",
            Font = new Font("Segoe UI", 16F, FontStyle.Bold),
            Location = new Point(40, 35),
            Size = new Size(380, 40),
            TextAlign = ContentAlignment.MiddleCenter
        };

        Label userLabel = new()
        {
            Text = $"Welcome, {fullName}",
            Location = new Point(40, 95),
            Size = new Size(380, 28),
            TextAlign = ContentAlignment.MiddleCenter
        };

        Label roleLabel = new()
        {
            Text = $"Role: {role}",
            Location = new Point(40, 130),
            Size = new Size(380, 28),
            TextAlign = ContentAlignment.MiddleCenter
        };

        Button logoutButton = new()
        {
            Name = "logoutButton",
            Text = "Logout",
            Location = new Point(140, 180),
            Size = new Size(180, 34)
        };
        logoutButton.Click += (_, _) =>
        {
            _authService.Logout();
            Close();
        };

        Controls.Add(titleLabel);
        Controls.Add(userLabel);
        Controls.Add(roleLabel);
        Controls.Add(logoutButton);
    }
}
