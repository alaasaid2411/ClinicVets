namespace ClinicVets.Models;

public class Pet
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
