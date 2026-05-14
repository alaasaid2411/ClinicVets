using ClinicVets.Models;
using ClinicVets.Repositories;
using ClinicVets.Validators;

namespace ClinicVets.Services;

/// <summary>
/// Handles customer registration, lookup, and customer-animal relationships.
/// </summary>
public class CustomerService(
    ICustomerRepository customerRepository,
    IAnimalRepository animalRepository,
    CustomerValidator customerValidator)
{
    public OperationResult<Customer> RegisterCustomer(
        Employee currentUser,
        string fullName,
        string identityNumber,
        string phone,
        string email)
    {
        if (currentUser.Role != StaffRole.Secretary)
        {
            return OperationResult<Customer>.Failure(ValidationMessages.SecretaryOnly);
        }

        OperationResult<bool> validationResult = customerValidator.ValidateCustomer(
            fullName,
            identityNumber,
            phone,
            email);

        if (!validationResult.IsSuccess)
        {
            return OperationResult<Customer>.Failure(validationResult.ErrorMessage);
        }

        if (customerRepository.ExistsByIdentityNumber(identityNumber))
        {
            return OperationResult<Customer>.Failure(ValidationMessages.DuplicateCustomer);
        }

        Customer customer = new()
        {
            FullName = fullName,
            IdentityNumber = identityNumber,
            Phone = phone,
            Email = email
        };

        Customer savedCustomer = customerRepository.Add(customer);
        return OperationResult<Customer>.Success(savedCustomer);
    }

    public Customer? SearchByIdentityOrPhone(string searchText)
    {
        return customerRepository.FindByIdentityOrPhone(searchText);
    }

    public IReadOnlyList<Animal> GetCustomerAnimals(int customerId)
    {
        return animalRepository.FindByOwnerCustomerId(customerId);
    }
}
