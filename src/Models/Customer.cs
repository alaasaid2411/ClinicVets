namespace ClinicVets.Models;

/// <summary>
/// Represents a customer who owns one or more animals.
/// </summary>
public class Customer
{
    public int Id { get; init; }
    public string FullName { get; set; } = string.Empty;
    public string IdentityNumber { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
}
