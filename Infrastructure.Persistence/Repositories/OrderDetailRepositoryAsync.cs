namespace Infrastructure.Persistence.Repositories
{
    public class OrderDetailRepositoryAsync : GenericRepositoryAsync<OrderDetail>, IOrderDetailRepositoryAsync
    {
        private readonly DbSet<OrderDetail> _orderDetail;
        public OrderDetailRepositoryAsync(ApplicationDbContext dbContext) : base(dbContext)
        {
            _orderDetail = dbContext.Set<OrderDetail>();
        }

        public async ValueTask<List<OrderDetail>> GetAllOrderDetailsByOrderIdAsync(int orderId)
        {
            IQueryable<OrderDetail> query = _orderDetail.Where(o => o.OrderId.Equals(orderId))
                                                         .Include(d => d.Product);

            return await query.ToListAsync();
        }
    }
}
