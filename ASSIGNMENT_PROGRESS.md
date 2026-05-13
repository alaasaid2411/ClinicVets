# ClinicVets Assignment Progress

This document summarizes the current implementation of the ClinicVets Software Testing course project, what has already been completed, and what still needs to be added.

## My Assignment Part

According to the assignment screenshot, this part focuses on two modules:

1. Login and employee registration for clinic staff.
2. Customer management for animal owners, allowed only for a secretary.

## Login And Employee Registration

Required by the assignment:

- Login using username and password from the system database.
- Register a new employee.
- Username must contain 6-8 characters.
- Username may contain at most 2 digits.
- Username must use English letters and digits.
- Password must contain 8-10 characters.
- Password must include at least one letter, one digit, and one special character from `!`, `#`, `$`.
- Employee number must contain exactly 4 digits.
- Email must be valid and include `@` and a domain ending such as `.com`.
- Employee role must be either secretary or veterinarian.

What is already implemented:

- `LoginForm` GUI with username and password fields.
- Improved centered clinic-style login card.
- Password field hides typed text.
- Login button calls `AuthService`.
- `AuthService.Login` checks the login workflow.
- `EmployeeValidator` validates username, password, employee number, email, and identity number.
- `EmployeeService.RegisterEmployee` contains employee registration business logic.
- `PasswordHasher` stores hashed passwords instead of plain text.
- `SqliteEmployeeRepository` saves and reads employees from SQLite.
- SQLite `Employees` table contains unique username, employee number, email, identity number, and a role foreign key.
- SQLite `Roles` table contains `Veterinarian` and `Secretary`.
- Demo users are seeded through the service layer so the login screen can be tested.

What still needs to be added:

- Complete the `RegisterEmployeeForm` GUI.
- Add text boxes for username, password, employee number, email, identity number, and role.
- Connect the registration form to `EmployeeService.RegisterEmployee`.
- Show validation messages in the form.
- Add manual GUI test cases for employee registration.

## Customer Management, Secretary Only

Required by the assignment:

- Register a new customer.
- Customer full name should contain letters only.
- Customer identity number should contain exactly 9 digits.
- Customer phone number should contain digits only.
- Search customer by identity number or phone.
- Display all animals linked to a specific customer.
- Only a secretary can manage/register customers.

What is already implemented:

- `Customer` model exists.
- `CustomerValidator` validates full name, identity number, phone, and email.
- `CustomerService.RegisterCustomer` checks that the current employee is a secretary.
- `CustomerService.RegisterCustomer` validates customer input before saving.
- `CustomerService.SearchByIdentityOrPhone` supports customer search.
- `CustomerService.GetCustomerAnimals` returns animals for a customer.
- `CustomerRepository` exists behind the service layer.
- UI does not access customer data directly.

What still needs to be added:

- Create `CustomerManagementForm`.
- Add input fields for full name, identity number, phone, and email.
- Connect the customer form to `CustomerService`.
- Add customer search by identity number or phone.
- Add a screen/table to display the customer's animals.
- Move customer storage from temporary in-memory repository to SQLite or Excel.
- Add manual GUI tests for secretary-only customer management.

## Architecture

The project uses a simple testable structure:

- `UI`: WinForms screens only collect input, show output, and call services.
- `Services`: business logic, permissions, and workflow rules.
- `Validators`: validation logic suitable for unit tests and boundary value testing.
- `Repositories`: data access, including SQLite for employees.
- `Models`: simple domain objects.
- `Data`: database initialization and temporary in-memory store.

## SQLite Database

Implemented tables:

```sql
CREATE TABLE IF NOT EXISTS Roles (
    Id INTEGER PRIMARY KEY AUTOINCREMENT,
    Name TEXT NOT NULL UNIQUE
);

CREATE TABLE IF NOT EXISTS Employees (
    Id INTEGER PRIMARY KEY AUTOINCREMENT,
    Username TEXT NOT NULL UNIQUE,
    PasswordHash TEXT NOT NULL,
    EmployeeNumber TEXT NOT NULL UNIQUE,
    Email TEXT NOT NULL UNIQUE,
    IdentityNumber TEXT NOT NULL UNIQUE,
    RoleId INTEGER NOT NULL,
    FOREIGN KEY (RoleId) REFERENCES Roles(Id)
);
```

Seeded roles:

- `Veterinarian`
- `Secretary`

## Testing Candidates

Good unit test candidates:

- `EmployeeValidator.ValidateUsername`
- `EmployeeValidator.ValidatePassword`
- `EmployeeValidator.ValidateEmployeeNumber`
- `EmployeeValidator.ValidateIdentityNumber`
- `CustomerValidator.ValidatePhone`
- `CustomerValidator.ValidateIdentityNumber`
- `AuthService.Login`
- `EmployeeService.RegisterEmployee`
- `CustomerService.RegisterCustomer`

Good boundary value tests:

- Username length: 5, 6, 8, 9.
- Username digit count: 2 and 3.
- Password length: 7, 8, 10, 11.
- Employee number length: 3, 4, 5.
- Employee identity number length: 8, 9, 10.
- Customer identity number length: 8, 9, 10.
- Empty customer name and valid customer name.
- Empty phone, phone with letters, valid phone.

Good decision table candidates:

- `AuthService.Login`
- `EmployeeService.RegisterEmployee`
- `CustomerService.RegisterCustomer`

Good GUI testing candidates:

- Login form displays error for empty username.
- Login form displays error for empty password.
- Login form opens dashboard after valid login.
- Dashboard displays current employee username and role.
- Logout closes dashboard and returns to login.
- Register employee link opens the registration form.

## Current Status Summary

Completed:

- C# WinForms project.
- Clean layered structure.
- Login screen with improved design.
- Dashboard screen.
- Domain models.
- Repository pattern.
- Service layer.
- Validator classes.
- Employee authentication.
- Password hashing.
- SQLite database for roles and employees.
- Seeded roles.
- Documentation foundation.

Partially completed:

- Employee registration logic exists, but GUI is still a placeholder.
- Customer logic exists, but GUI screen and persistent customer storage are not complete.
- Animal, visit, and medicine logic exists, but GUI screens are not complete.
- Repository layer exists for all modules, but only employees currently use SQLite.

Not completed yet:

- Full employee registration GUI.
- Customer management GUI.
- Animal management GUI.
- Visit management GUI.
- Full database persistence for all modules.
- Automated tests.
- Full testing documentation package.
