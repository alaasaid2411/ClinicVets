# ClinicVets Implementation Summary

This file describes what has been implemented so far in the `ClinicVets` project.

## Current Assignment Part

The current student assignment part focuses on:

1. Login and employee registration for clinic staff.
2. Customer management for animal owners, allowed only for secretary users.

## Implemented So Far

- C# WinForms application.
- Clean layered structure with `UI`, `Services`, `Validators`, `Repositories`, `Models`, and `Data`.
- Login GUI in `LoginForm`.
- Improved `LoginForm` design with a centered clinic-style card.
- Dashboard after login.
- Employee validation and registration logic.
- Customer validation and service logic.
- Secretary-only permission rule for customer registration.
- SQLite database setup for `Roles` and `Employees`.
- Seeded roles: `Veterinarian` and `Secretary`.
- Password hashing before employee storage.

## Still Needed

- Complete `RegisterEmployeeForm`.
- Create `CustomerManagementForm`.
- Add customer search by identity number or phone in the GUI.
- Show all animals linked to a selected customer.
- Move customer persistence from memory to SQLite or Excel.
- Add unit tests and testing documentation.

## Demo Users

```text
Username: Sara12
Password: Pass123!
Role: Secretary

Username: DrAvi1
Password: Vet12345!
Role: Veterinarian
```
