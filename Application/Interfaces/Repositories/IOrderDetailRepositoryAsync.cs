namespace Application.Interfaces.Repositories
{
    public interface IOrderDetailRepositoryAsync : IGenericRepositoryAsync<OrderDetail>
    {
        ValueTask<List<OrderDetail>> GetAllOrderDetailsByOrderIdAsync(int orderId);
    }
}
