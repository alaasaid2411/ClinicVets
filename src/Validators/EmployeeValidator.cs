using ClinicVets.Services;

namespace ClinicVets.Validators;

/// <summary>
/// Validates employee registration and login input.
/// </summary>
public class EmployeeValidator
{
    public OperationResult<bool> ValidateRegistration(
        string username,
        string password,
        string employeeNumber,
        string email,
        string identityNumber)
    {
        if (!ValidateUsername(username))
        {
            return OperationResult<bool>.Failure(ValidationMessages.InvalidUsernameFormat);
        }

        if (!ValidatePassword(password))
        {
            return OperationResult<bool>.Failure(ValidationMessages.InvalidPasswordFormat);
        }

        if (!ValidateEmployeeNumber(employeeNumber))
        {
            return OperationResult<bool>.Failure(ValidationMessages.InvalidEmployeeNumber);
        }

        if (!ValidateEmail(email) || !ValidateIdentityNumber(identityNumber))
        {
            return OperationResult<bool>.Failure(ValidationMessages.InvalidEmailOrIdentity);
        }

        return OperationResult<bool>.Success(true);
    }

    public OperationResult<bool> ValidateLogin(string username, string password)
    {
        if (string.IsNullOrWhiteSpace(username))
        {
            return OperationResult<bool>.Failure(ValidationMessages.UsernameRequired);
        }

        if (string.IsNullOrWhiteSpace(password))
        {
            return OperationResult<bool>.Failure(ValidationMessages.PasswordRequired);
        }

        if (!ValidateUsername(username))
        {
            return OperationResult<bool>.Failure(ValidationMessages.InvalidUsernameFormat);
        }

        return OperationResult<bool>.Success(true);
    }

    public bool ValidateUsername(string username) => ValidationRules.IsUsernameValid(username);
    public bool ValidatePassword(string password) => ValidationRules.IsPasswordValid(password);
    public bool ValidateEmployeeNumber(string employeeNumber) => ValidationRules.IsEmployeeNumberValid(employeeNumber);
    public bool ValidateIdentityNumber(string identityNumber) => ValidationRules.IsIdentityNumberValid(identityNumber);
    public bool ValidateEmail(string email) => ValidationRules.IsEmailValid(email);
}
