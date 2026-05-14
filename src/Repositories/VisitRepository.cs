using ClinicVets.Data;
using ClinicVets.Models;

namespace ClinicVets.Repositories;

/// <summary>
/// Stores visit records in the current clinic data store.
/// </summary>
public class VisitRepository(ClinicDataStore dataStore) : IVisitRepository
{
    public Visit Add(Visit visit)
    {
        List<Medicine> medicinesGiven = visit.MedicinesGiven.ToList();

        visit = new Visit
        {
            Id = dataStore.GetNextVisitId(),
            AnimalId = visit.AnimalId,
            VeterinarianId = visit.VeterinarianId,
            Reason = visit.Reason,
            Diagnosis = visit.Diagnosis,
            VisitDateTime = visit.VisitDateTime,
            BaseVisitPrice = visit.BaseVisitPrice
        };

        visit.MedicinesGiven.AddRange(medicinesGiven);
        dataStore.Visits.Add(visit);
        return visit;
    }
}
