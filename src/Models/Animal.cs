namespace ClinicVets.Models;

/// <summary>
/// Represents an animal patient card in the clinic.
/// </summary>
public class Animal
{
    public int Id { get; init; }
    public string Name { get; set; } = string.Empty;
    public string ChipNumber { get; set; } = string.Empty;
    public AnimalType Type { get; set; }
    public decimal WeightKg { get; set; }
    public DateOnly BirthDate { get; set; }
    public DateOnly LastVaccinationDate { get; set; }
    public int OwnerCustomerId { get; set; }
}
