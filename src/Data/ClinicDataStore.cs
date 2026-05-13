using ClinicVets.Models;

namespace ClinicVets.Data;

/// <summary>
/// Temporary in-memory store for modules that have not been moved to SQLite yet.
/// </summary>
public class ClinicDataStore
{
    private int _nextEmployeeId = 1;
    private int _nextCustomerId = 1;
    private int _nextAnimalId = 1;
    private int _nextMedicineId = 1;
    private int _nextVisitId = 1;

    public List<Employee> Employees { get; } = [];
    public List<Customer> Customers { get; } = [];
    public List<Animal> Animals { get; } = [];
    public List<Medicine> Medicines { get; } = [];
    public List<Visit> Visits { get; } = [];

    public int GetNextEmployeeId() => _nextEmployeeId++;
    public int GetNextCustomerId() => _nextCustomerId++;
    public int GetNextAnimalId() => _nextAnimalId++;
    public int GetNextMedicineId() => _nextMedicineId++;
    public int GetNextVisitId() => _nextVisitId++;
}
