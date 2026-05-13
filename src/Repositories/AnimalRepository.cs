using ClinicVets.Data;
using ClinicVets.Models;

namespace ClinicVets.Repositories;

/// <summary>
/// Stores animal patient records in the current clinic data store.
/// </summary>
public class AnimalRepository(ClinicDataStore dataStore) : IAnimalRepository
{
    public bool ExistsById(int animalId) => dataStore.Animals.Any(animal => animal.Id == animalId);

    public bool ExistsByChipNumber(string chipNumber)
    {
        return dataStore.Animals.Any(animal => animal.ChipNumber == chipNumber);
    }

    public Animal Add(Animal animal)
    {
        animal = new Animal
        {
            Id = dataStore.GetNextAnimalId(),
            Name = animal.Name,
            ChipNumber = animal.ChipNumber,
            Type = animal.Type,
            WeightKg = animal.WeightKg,
            BirthDate = animal.BirthDate,
            LastVaccinationDate = animal.LastVaccinationDate,
            OwnerCustomerId = animal.OwnerCustomerId
        };

        dataStore.Animals.Add(animal);
        return animal;
    }

    public IReadOnlyList<Animal> FindByOwnerCustomerId(int customerId)
    {
        return dataStore.Animals.Where(animal => animal.OwnerCustomerId == customerId).ToList();
    }

    public IReadOnlyList<Animal> SearchByNameOrChip(string searchText)
    {
        return dataStore.Animals
            .Where(animal => animal.Name.Contains(searchText, StringComparison.OrdinalIgnoreCase) ||
                             animal.ChipNumber == searchText)
            .ToList();
    }
}
