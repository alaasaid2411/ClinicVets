using ClinicVets.Data;
using ClinicVets.Models;

namespace ClinicVets.Services;

public class PetService(ClinicDataStore dataStore)
{
    public OperationResult<Pet> AddPet(
        string name,
        string chipNumber,
        AnimalType type,
        decimal weightKg,
        DateOnly birthDate,
        DateOnly lastVaccinationDate,
        int ownerCustomerId)
    {
        if (!InputValidator.IsEnglishOrHebrewName(name))
        {
            return OperationResult<Pet>.Failure("Pet name must contain letters only.");
        }

        if (!InputValidator.IsPetWeightValid(weightKg))
        {
            return OperationResult<Pet>.Failure("Pet weight must be between 0.1 and 100 kg.");
        }

        if (!InputValidator.IsPetBirthDateValid(birthDate))
        {
            return OperationResult<Pet>.Failure("Birth date cannot be future date or earlier than year 2000.");
        }

        if (!dataStore.Customers.Any(customer => customer.Id == ownerCustomerId))
        {
            return OperationResult<Pet>.Failure("Pet must be linked to an existing customer.");
        }

        if (dataStore.Pets.Any(pet => pet.ChipNumber == chipNumber))
        {
            return OperationResult<Pet>.Failure("Chip number already exists.");
        }

        Pet pet = new()
        {
            Id = dataStore.GetNextPetId(),
            Name = name,
            ChipNumber = chipNumber,
            Type = type,
            WeightKg = weightKg,
            BirthDate = birthDate,
            LastVaccinationDate = lastVaccinationDate,
            OwnerCustomerId = ownerCustomerId
        };

        dataStore.Pets.Add(pet);
        return OperationResult<Pet>.Success(pet);
    }

    public IReadOnlyList<Pet> SearchByNameOrChip(string searchText)
    {
        return dataStore.Pets
            .Where(pet => pet.Name.Contains(searchText, StringComparison.OrdinalIgnoreCase) || pet.ChipNumber == searchText)
            .ToList();
    }

    public bool NeedsAnnualVaccination(Pet pet)
    {
        return pet.LastVaccinationDate.AddYears(1) <= DateOnly.FromDateTime(DateTime.Today);
    }
}
