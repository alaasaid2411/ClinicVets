# ClinicVets

GUI-based veterinary clinic management system developed in C# WinForms for the Software Testing course project.

## Project Structure

```text
src/
  Data/          SQLite setup and temporary in-memory store for modules not moved to SQLite yet.
  Models/        Domain models: Employee, Customer, Animal, Visit, Medicine.
  Repositories/  Repository interfaces and implementations.
  Services/      Business logic, permissions, authentication, and workflows.
  Validators/    Testable validation classes split by module.
  UI/            WinForms GUI screens.
  Program.cs     Application startup and dependency wiring.
tests/           Reserved for future unit, functional, and GUI tests.
```

The employee login/registration storage uses SQLite through the repository layer. The database file is created as `clinicvets.db` in the application output folder when the app starts.

For a full assignment progress summary, including what is implemented and what still needs to be added, see:

- [ASSIGNMENT_PROGRESS.md](ASSIGNMENT_PROGRESS.md)

Run the project:

```powershell
dotnet run --project ClinicVets.csproj
```
