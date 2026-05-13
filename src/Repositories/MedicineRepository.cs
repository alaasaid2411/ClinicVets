using ClinicVets.Data;
using ClinicVets.Models;

namespace ClinicVets.Repositories;

/// <summary>
/// Stores medicine records in the current clinic data store.
/// </summary>
public class MedicineRepository(ClinicDataStore dataStore) : IMedicineRepository
{
    public IReadOnlyList<Medicine> GetAll() => dataStore.Medicines.ToList();

    public IReadOnlyList<Medicine> FindByIds(IEnumerable<int> medicineIds)
    {
        HashSet<int> idSet = medicineIds.ToHashSet();
        return dataStore.Medicines.Where(medicine => idSet.Contains(medicine.Id)).ToList();
    }

    public Medicine Add(Medicine medicine)
    {
        medicine = new Medicine
        {
            Id = dataStore.GetNextMedicineId(),
            Name = medicine.Name,
            Price = medicine.Price,
            QuantityInStock = medicine.QuantityInStock
        };

        dataStore.Medicines.Add(medicine);
        return medicine;
    }

    public bool Remove(int medicineId)
    {
        Medicine? medicine = dataStore.Medicines.FirstOrDefault(item => item.Id == medicineId);

        if (medicine is null)
        {
            return false;
        }

        dataStore.Medicines.Remove(medicine);
        return true;
    }
}
