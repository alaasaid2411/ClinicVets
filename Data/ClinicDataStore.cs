using ClinicVets.Models;

namespace ClinicVets.Data;

public class ClinicDataStore
{
    private int _nextStaffId = 1;
    private int _nextCustomerId = 1;
    private int _nextPetId = 1;
    private int _nextMedicineId = 1;
    private int _nextVisitId = 1;

    public List<StaffMember> StaffMembers { get; } = [];
    public List<Customer> Customers { get; } = [];
    public List<Pet> Pets { get; } = [];
    public List<Medicine> Medicines { get; } = [];
    public List<Visit> Visits { get; } = [];

    public int GetNextStaffId() => _nextStaffId++;
    public int GetNextCustomerId() => _nextCustomerId++;
    public int GetNextPetId() => _nextPetId++;
    public int GetNextMedicineId() => _nextMedicineId++;
    public int GetNextVisitId() => _nextVisitId++;
}
