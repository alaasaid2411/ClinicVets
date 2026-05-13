namespace ClinicVets.Models;

/// <summary>
/// Represents a medicine item in the clinic inventory.
/// </summary>
public class Medicine
{
    public int Id { get; init; }
    public string Name { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public int QuantityInStock { get; set; }
}
