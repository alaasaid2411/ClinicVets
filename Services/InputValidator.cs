using System.Text.RegularExpressions;

namespace ClinicVets.Services;

public static partial class InputValidator
{
    public static bool IsUsernameValid(string username)
    {
        if (!UsernameRegex().IsMatch(username))
        {
            return false;
        }

        return username.Count(char.IsDigit) <= 2;
    }

    public static bool IsPasswordValid(string password)
    {
        return PasswordRegex().IsMatch(password);
    }

    public static bool IsEmployeeNumberValid(string employeeNumber)
    {
        return Regex.IsMatch(employeeNumber, @"^\d{4}$");
    }

    public static bool IsIdentityNumberValid(string identityNumber)
    {
        return Regex.IsMatch(identityNumber, @"^\d{9}$");
    }

    public static bool IsEmailValid(string email)
    {
        return EmailRegex().IsMatch(email);
    }

    public static bool IsPhoneValid(string phone)
    {
        return Regex.IsMatch(phone, @"^0\d{8,9}$");
    }

    public static bool IsEnglishOrHebrewName(string name)
    {
        return NameRegex().IsMatch(name.Trim());
    }

    public static bool IsPetWeightValid(decimal weightKg)
    {
        return weightKg >= 0.1m && weightKg <= 100m;
    }

    public static bool IsPetBirthDateValid(DateOnly birthDate)
    {
        DateOnly today = DateOnly.FromDateTime(DateTime.Today);
        return birthDate <= today && birthDate.Year >= 2000;
    }

    [GeneratedRegex(@"^[A-Za-z0-9]{6,8}$")]
    private static partial Regex UsernameRegex();

    [GeneratedRegex(@"^(?=.*[A-Za-z])(?=.*\d)(?=.*[!#$])[A-Za-z\d!#$]{8,10}$")]
    private static partial Regex PasswordRegex();

    [GeneratedRegex(@"^[^@\s]+@[^@\s]+\.[^@\s]+$")]
    private static partial Regex EmailRegex();

    [GeneratedRegex(@"^[A-Za-zא-ת]+(?: [A-Za-zא-ת]+)*$")]
    private static partial Regex NameRegex();
}
