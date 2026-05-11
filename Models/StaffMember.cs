namespace ClinicVets.Models;

public class StaffMember
{
    public int Id { get; init; }
    public string Username { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public string EmployeeNumber { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string IdentityNumber { get; set; } = string.Empty;
    public StaffRole Role { get; set; }
}
