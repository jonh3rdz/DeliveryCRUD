namespace Domain.Customers;

public interface ICustomerRepository
{
    Task<Customer?> GetByIdAsync(CustomerId id);
    Task<List<Customer>> GetAllAsync();
    Task Add(Customer customer);
    Task Update(Customer customer);
    Task Delete(CustomerId id);
}