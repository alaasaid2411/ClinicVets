using ClinicVets.Data;
using ClinicVets.Models;

namespace ClinicVets.Services;

public class StaffService(ClinicDataStore dataStore)
{
    public OperationResult<StaffMember> RegisterStaff(
        string username,
        string password,
        string employeeNumber,
        string email,
        string identityNumber,
        StaffRole role)
    {
        if (!InputValidator.IsUsernameValid(username))
        {
            return OperationResult<StaffMember>.Failure("Username must be 6-8 English letters/digits with up to 2 digits.");
        }

        if (!InputValidator.IsPasswordValid(password))
        {
            return OperationResult<StaffMember>.Failure("Password must be 8-10 chars and include a letter, digit, and !/#/$.");
        }

        if (!InputValidator.IsEmployeeNumberValid(employeeNumber))
        {
            return OperationResult<StaffMember>.Failure("Employee number must contain exactly 4 digits.");
        }

        if (!InputValidator.IsEmailValid(email) || !InputValidator.IsIdentityNumberValid(identityNumber))
        {
            return OperationResult<StaffMember>.Failure("Email or identity number format is invalid.");
        }

        if (dataStore.StaffMembers.Any(staff => staff.Username == username || staff.EmployeeNumber == employeeNumber))
        {
            return OperationResult<StaffMember>.Failure("A staff member with this username or employee number already exists.");
        }

        StaffMember staffMember = new()
        {
            Id = dataStore.GetNextStaffId(),
            Username = username,
            Password = password,
            EmployeeNumber = employeeNumber,
            Email = email,
            IdentityNumber = identityNumber,
            Role = role
        };

        dataStore.StaffMembers.Add(staffMember);
        return OperationResult<StaffMember>.Success(staffMember);
    }

    public OperationResult<StaffMember> Login(string username, string password)
    {
        StaffMember? staffMember = dataStore.StaffMembers
            .FirstOrDefault(staff => staff.Username == username && staff.Password == password);

        return staffMember is null
            ? OperationResult<StaffMember>.Failure("Username or password is incorrect.")
            : OperationResult<StaffMember>.Success(staffMember);
    }
}
