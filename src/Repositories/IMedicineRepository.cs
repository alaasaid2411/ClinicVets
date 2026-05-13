using ClinicVets.Models;

namespace ClinicVets.Repositories;

/// <summary>
/// Defines medicine inventory storage operations used by services.
/// </summary>
public interface IMedicineRepository
{
    IReadOnlyList<Medicine> GetAll();
    IReadOnlyList<Medicine> FindByIds(IEnumerable<int> medicineIds);
    Medicine Add(Medicine medicine);
    bool Remove(int medicineId);
}
