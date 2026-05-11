using ClinicVets.Data;
using ClinicVets.Models;

namespace ClinicVets.Services;

public class MedicineInventoryService(ClinicDataStore dataStore)
{
    public OperationResult<Medicine> AddMedicine(string name, decimal price, int quantityInStock)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            return OperationResult<Medicine>.Failure("Medicine name is required.");
        }

        if (price < 0 || quantityInStock < 0)
        {
            return OperationResult<Medicine>.Failure("Medicine price and quantity cannot be negative.");
        }

        Medicine medicine = new()
        {
            Id = dataStore.GetNextMedicineId(),
            Name = name.Trim(),
            Price = price,
            QuantityInStock = quantityInStock
        };

        dataStore.Medicines.Add(medicine);
        return OperationResult<Medicine>.Success(medicine);
    }

    public bool RemoveMedicine(int medicineId)
    {
        Medicine? medicine = dataStore.Medicines.FirstOrDefault(item => item.Id == medicineId);

        if (medicine is null)
        {
            return false;
        }

        dataStore.Medicines.Remove(medicine);
        return true;
    }

    public IReadOnlyList<Medicine> GetAllMedicines() => dataStore.Medicines.ToList();
}
