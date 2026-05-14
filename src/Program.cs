using ClinicVets.Data;
using ClinicVets.Models;
using ClinicVets.Repositories;
using ClinicVets.Services;
using ClinicVets.UI;
using ClinicVets.Validators;

namespace ClinicVets;

internal static class Program
{
    [STAThread]
    private static void Main()
    {
        ApplicationConfiguration.Initialize();

        ClinicDatabaseInitializer databaseInitializer = new(DatabaseSettings.ConnectionString);
        databaseInitializer.Initialize();

        EmployeeValidator employeeValidator = new();
        IEmployeeRepository employeeRepository = new SqliteEmployeeRepository(DatabaseSettings.ConnectionString);
        EmployeeService employeeService = new(employeeRepository, employeeValidator);
        AuthService authService = new(employeeRepository, employeeValidator);

        SeedDemoEmployees(employeeService);

        Application.Run(new LoginForm(authService));
    }

    /// <summary>
    /// Adds demo users so the login screen can be tested before the registration GUI is complete.
    /// </summary>
    private static void SeedDemoEmployees(EmployeeService employeeService)
    {
        employeeService.RegisterEmployee(
            "Sara12",
            "Pass123!",
            "1001",
            "sara@clinic.com",
            "123456789",
            StaffRole.Secretary);

        employeeService.RegisterEmployee(
            "DrAvi1",
            "Vet12345!",
            "2001",
            "avi@clinic.com",
            "987654321",
            StaffRole.Veterinarian);
    }
}
