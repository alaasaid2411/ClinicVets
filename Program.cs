using ClinicVets.Data;
using ClinicVets.Models;
using ClinicVets.Services;

ClinicDataStore dataStore = new();
StaffService staffService = new(dataStore);
CustomerService customerService = new(dataStore);
PetService petService = new(dataStore);
MedicineInventoryService medicineService = new(dataStore);
VisitService visitService = new(dataStore);

OperationResult<StaffMember> secretaryResult = staffService.RegisterStaff(
    "Sara12",
    "Pass123!",
    "1001",
    "sara@clinic.com",
    "123456789",
    StaffRole.Secretary);

OperationResult<StaffMember> veterinarianResult = staffService.RegisterStaff(
    "DrAvi1",
    "Vet12345!",
    "2001",
    "avi@clinic.com",
    "987654321",
    StaffRole.Veterinarian);

if (!secretaryResult.IsSuccess || !veterinarianResult.IsSuccess)
{
    Console.WriteLine("Failed to create demo users.");
    return;
}

OperationResult<Customer> customerResult = customerService.RegisterCustomer(
    secretaryResult.Value!,
    "Dana Cohen",
    "111222333",
    "0501234567",
    "dana@example.com");

if (!customerResult.IsSuccess)
{
    Console.WriteLine(customerResult.ErrorMessage);
    return;
}

OperationResult<Pet> petResult = petService.AddPet(
    "Lucky",
    "CHIP001",
    AnimalType.Dog,
    12.5m,
    new DateOnly(2020, 4, 15),
    DateOnly.FromDateTime(DateTime.Today.AddYears(-1).AddDays(-5)),
    customerResult.Value!.Id);

medicineService.AddMedicine("Antibiotic", 45m, 20);

OperationResult<Visit> visitResult = visitService.OpenVisit(
    veterinarianResult.Value!,
    petResult.Value!.Id,
    "Annual checkup",
    "Healthy, vaccination reminder shown.",
    dataStore.Medicines.Select(medicine => medicine.Id));

Console.WriteLine($"ClinicVets started with {dataStore.StaffMembers.Count} staff member(s).");
Console.WriteLine($"Customer: {customerResult.Value.FullName}, Pet: {petResult.Value.Name}");
Console.WriteLine($"Visit total price: {visitResult.Value!.TotalPrice:C}");
Console.WriteLine($"Needs annual vaccination: {petService.NeedsAnnualVaccination(petResult.Value)}");
