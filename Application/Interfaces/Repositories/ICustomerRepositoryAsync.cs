using Domain.Entities;

namespace Application.Interfaces.Repositories
{
    public interface ICustomerRepositoryAsync : IGenericRepositoryAsync<Customer>
    {
       ValueTask<Customer> GetCustomerByIdAsync(int id);
       ValueTask<bool> IsUniqueCustomerAsync(string email);
       ValueTask<List<Customer>> GetAllCustomerAsync();
    }
}
