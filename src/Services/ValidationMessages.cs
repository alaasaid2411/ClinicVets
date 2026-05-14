namespace ClinicVets.Services;

/// <summary>
/// Centralized validation and authentication messages used by services and GUI screens.
/// </summary>
public static class ValidationMessages
{
    public const string UsernameRequired = "Username is required.";
    public const string PasswordRequired = "Password is required.";
    public const string InvalidUsernameFormat = "Username must be 6-8 English letters/digits with up to 2 digits.";
    public const string InvalidPasswordFormat = "Password must be 8-10 chars and include a letter, digit, and !/#/$.";
    public const string InvalidEmployeeNumber = "Employee number must contain exactly 4 digits.";
    public const string InvalidEmailOrIdentity = "Email or identity number format is invalid.";
    public const string DuplicateEmployee = "An employee with these unique details already exists.";
    public const string WrongCredentials = "Username or password is incorrect.";
    public const string NotAuthenticated = "No user is currently logged in.";

    public const string SecretaryOnly = "Only a secretary can register customers.";
    public const string InvalidFullName = "Full name must contain letters only.";
    public const string InvalidIdentityNumber = "Identity number must contain exactly 9 digits.";
    public const string InvalidPhoneOrEmail = "Phone or email format is invalid.";
    public const string DuplicateCustomer = "Customer identity number already exists.";

    public const string InvalidAnimalName = "Animal name must contain letters only.";
    public const string InvalidAnimalWeight = "Animal weight must be between 0.1 and 100 kg.";
    public const string InvalidAnimalBirthDate = "Birth date cannot be future date or earlier than year 2000.";
    public const string AnimalOwnerRequired = "Animal must be linked to an existing customer.";
    public const string DuplicateChipNumber = "Chip number already exists.";

    public const string MedicineNameRequired = "Medicine name is required.";
    public const string InvalidMedicinePriceOrQuantity = "Medicine price and quantity cannot be negative.";

    public const string VeterinarianOnly = "Only a veterinarian can open visits.";
    public const string AnimalNotFound = "Animal was not found.";
    public const string VisitReasonRequired = "Visit reason is required.";
}
