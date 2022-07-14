using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Repositories
{
    public interface IOrderRepositoryAsync : IGenericRepositoryAsync<Order>
    {
        ValueTask<List<Order>> GetAllOrderByStatusAsync(int statusType);
        ValueTask<bool> IsUniqueOrderAsync(int orderNumber);
        ValueTask<List<Order>> GetAllOrdersAsync();
        ValueTask<int> GetLastOrderNumber();
    }
}
