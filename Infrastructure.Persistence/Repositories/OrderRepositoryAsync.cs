namespace Infrastructure.Persistence.Repositories
{
    public class OrderRepositoryAsync : GenericRepositoryAsync<Order>, IOrderRepositoryAsync
    {
        private readonly DbSet<Order> _order;
        public OrderRepositoryAsync(ApplicationDbContext dbContext) : base(dbContext)
        {
            _order = dbContext.Set<Order>();
        }

        public async ValueTask<List<Order>> GetAllOrderByStatusAsync(int statusType)
        {
            IQueryable<Order> query = _order.Where(o => (int)o.OrderStatusType == statusType && o.OrderDetails.Count > 0)
                                            .Include(include => include.OrderDetails)
                                            .ThenInclude(include => include.Product);
            return await query.ToListAsync();
        }

        public async ValueTask<List<Order>> GetAllOrdersAsync()
        {
            IQueryable<Order> query = _order
                                            .Include(include => include.OrderDetails)
                                            .ThenInclude(include => include.Product);
            return await query.ToListAsync();
        }

        public async ValueTask<int> GetLastOrderNumber()
        {
            IQueryable<Order> query = _order.Where(item => item.OrderStatusType == Domain.Enums.OrderStatusType.Pending || item.OrderStatusType != Domain.Enums.OrderStatusType.Pending);
            return await query.OrderByDescending(item => item.Id).Select(o => o.OrderNumber).FirstOrDefaultAsync();
        }

        public async ValueTask<bool> IsUniqueOrderAsync(int orderNumber)
        {
            return await _order.AnyAsync(query => query.OrderNumber.Equals(orderNumber));
        }
    }
}
