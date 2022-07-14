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
