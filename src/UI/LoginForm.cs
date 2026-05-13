using ClinicVets.Services;

namespace ClinicVets.UI;

/// <summary>
/// GUI login screen for clinic staff members.
/// </summary>
public class LoginForm : Form
{
    private readonly AuthService _authService;
    private readonly TextBox _usernameTextBox = new();
    private readonly TextBox _passwordTextBox = new();
    private readonly Label _errorLabel = new();
    private readonly Panel _loginCard = new();

    public LoginForm(AuthService authService)
    {
        _authService = authService;
        InitializeComponent();
    }

    private void InitializeComponent()
    {
        Text = "ClinicVets - Staff Login";
        StartPosition = FormStartPosition.CenterScreen;
        ClientSize = new Size(900, 600);
        MinimumSize = new Size(760, 520);
        Font = new Font("Segoe UI", 11F);
        BackColor = Color.FromArgb(236, 246, 244);

        Label appTitleLabel = new()
        {
            Text = "ClinicVets",
            AutoSize = false,
            TextAlign = ContentAlignment.MiddleCenter,
            Font = new Font("Segoe UI", 28F, FontStyle.Bold),
            ForeColor = Color.FromArgb(21, 95, 91),
            Location = new Point(0, 36),
            Size = new Size(ClientSize.Width, 58),
            Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right
        };

        Label appSubtitleLabel = new()
        {
            Text = "Veterinary clinic staff portal",
            AutoSize = false,
            TextAlign = ContentAlignment.MiddleCenter,
            Font = new Font("Segoe UI", 12F),
            ForeColor = Color.FromArgb(88, 110, 117),
            Location = new Point(0, 96),
            Size = new Size(ClientSize.Width, 30),
            Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right
        };

        _loginCard.Size = new Size(430, 360);
        _loginCard.BackColor = Color.White;
        _loginCard.BorderStyle = BorderStyle.FixedSingle;
        _loginCard.Anchor = AnchorStyles.None;
        CenterLoginCard();

        Label titleLabel = new()
        {
            Text = "ClinicVets Staff Login",
            AutoSize = false,
            TextAlign = ContentAlignment.MiddleCenter,
            Font = new Font("Segoe UI", 18F, FontStyle.Bold),
            ForeColor = Color.FromArgb(35, 45, 50),
            Location = new Point(36, 28),
            Size = new Size(358, 38)
        };

        Label subtitleLabel = new()
        {
            Text = "Sign in to manage clinic daily work",
            AutoSize = false,
            TextAlign = ContentAlignment.MiddleCenter,
            Font = new Font("Segoe UI", 10.5F),
            ForeColor = Color.FromArgb(91, 105, 112),
            Location = new Point(36, 68),
            Size = new Size(358, 28)
        };

        Label usernameLabel = CreateFieldLabel("Username", new Point(50, 118));

        _usernameTextBox.Name = "usernameTextBox";
        _usernameTextBox.Location = new Point(50, 145);
        _usernameTextBox.Size = new Size(330, 32);
        _usernameTextBox.Font = new Font("Segoe UI", 12F);
        _usernameTextBox.AccessibleName = "Username";

        Label passwordLabel = CreateFieldLabel("Password", new Point(50, 190));

        _passwordTextBox.Name = "passwordTextBox";
        _passwordTextBox.Location = new Point(50, 217);
        _passwordTextBox.Size = new Size(330, 32);
        _passwordTextBox.Font = new Font("Segoe UI", 12F);
        _passwordTextBox.UseSystemPasswordChar = true;
        _passwordTextBox.AccessibleName = "Password";

        Button loginButton = new()
        {
            Name = "loginButton",
            Text = "Login",
            Location = new Point(50, 270),
            Size = new Size(330, 42),
            BackColor = Color.FromArgb(21, 126, 119),
            ForeColor = Color.White,
            FlatStyle = FlatStyle.Flat,
            Font = new Font("Segoe UI", 12F, FontStyle.Bold),
            Cursor = Cursors.Hand
        };
        loginButton.FlatAppearance.BorderSize = 0;
        loginButton.Click += LoginButton_Click;

        LinkLabel registerLink = new()
        {
            Name = "registerEmployeeLink",
            Text = "Register a new employee",
            LinkColor = Color.FromArgb(21, 126, 119),
            ActiveLinkColor = Color.FromArgb(14, 95, 90),
            VisitedLinkColor = Color.FromArgb(21, 126, 119),
            Location = new Point(50, 323),
            Size = new Size(330, 26),
            TextAlign = ContentAlignment.MiddleCenter,
            Font = new Font("Segoe UI", 10.5F),
            Cursor = Cursors.Hand
        };
        registerLink.LinkClicked += RegisterLink_LinkClicked;

        _errorLabel.Name = "errorLabel";
        _errorLabel.ForeColor = Color.FromArgb(176, 42, 42);
        _errorLabel.Location = new Point(50, 96);
        _errorLabel.Size = new Size(330, 22);
        _errorLabel.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
        _errorLabel.TextAlign = ContentAlignment.MiddleCenter;

        _loginCard.Controls.Add(titleLabel);
        _loginCard.Controls.Add(subtitleLabel);
        _loginCard.Controls.Add(_errorLabel);
        _loginCard.Controls.Add(usernameLabel);
        _loginCard.Controls.Add(_usernameTextBox);
        _loginCard.Controls.Add(passwordLabel);
        _loginCard.Controls.Add(_passwordTextBox);
        _loginCard.Controls.Add(loginButton);
        _loginCard.Controls.Add(registerLink);

        Controls.Add(appTitleLabel);
        Controls.Add(appSubtitleLabel);
        Controls.Add(_loginCard);

        Resize += (_, _) => CenterLoginCard();
        AcceptButton = loginButton;
    }

    private static Label CreateFieldLabel(string text, Point location)
    {
        return new Label
        {
            Text = text,
            Location = location,
            Size = new Size(330, 24),
            Font = new Font("Segoe UI", 10.5F, FontStyle.Bold),
            ForeColor = Color.FromArgb(55, 67, 72)
        };
    }

    private void CenterLoginCard()
    {
        int x = (ClientSize.Width - _loginCard.Width) / 2;
        int y = Math.Max(145, (ClientSize.Height - _loginCard.Height) / 2 + 35);
        _loginCard.Location = new Point(x, y);
    }

    private void LoginButton_Click(object? sender, EventArgs e)
    {
        AuthenticationResult result = _authService.Login(
            _usernameTextBox.Text.Trim(),
            _passwordTextBox.Text);

        if (!result.IsSuccess)
        {
            _errorLabel.Text = result.ErrorMessage;
            return;
        }

        _errorLabel.Text = string.Empty;
        Hide();

        using DashboardForm dashboardForm = new(_authService);
        dashboardForm.ShowDialog(this);

        _passwordTextBox.Clear();
        Show();
    }

    private void RegisterLink_LinkClicked(object? sender, LinkLabelLinkClickedEventArgs e)
    {
        using RegisterEmployeeForm registerEmployeeForm = new();
        registerEmployeeForm.ShowDialog(this);
    }
}
