using ClinicVets.Data;
using ClinicVets.Models;

namespace ClinicVets.Services;

public class VisitService(ClinicDataStore dataStore)
{
    public OperationResult<Visit> OpenVisit(
        StaffMember currentUser,
        int petId,
        string reason,
        string diagnosis,
        IEnumerable<int> medicineIds)
    {
        if (currentUser.Role != StaffRole.Veterinarian)
        {
            return OperationResult<Visit>.Failure("Only a veterinarian can open visits.");
        }

        if (!dataStore.Pets.Any(pet => pet.Id == petId))
        {
            return OperationResult<Visit>.Failure("Pet was not found.");
        }

        if (string.IsNullOrWhiteSpace(reason))
        {
            return OperationResult<Visit>.Failure("Visit reason is required.");
        }

        List<Medicine> medicines = dataStore.Medicines
            .Where(medicine => medicineIds.Contains(medicine.Id))
            .ToList();

        Visit visit = new()
        {
            Id = dataStore.GetNextVisitId(),
            PetId = petId,
            VeterinarianId = currentUser.Id,
            Reason = reason.Trim(),
            Diagnosis = diagnosis.Trim(),
            VisitDateTime = DateTime.Now
        };

        visit.MedicinesGiven.AddRange(medicines);
        dataStore.Visits.Add(visit);
        return OperationResult<Visit>.Success(visit);
    }
}
