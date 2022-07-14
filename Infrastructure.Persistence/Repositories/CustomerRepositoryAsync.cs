namespace Infrastructure.Persistence.Repositories
{
    public class CustomerRepositoryAsync : GenericRepositoryAsync<Customer>, ICustomerRepositoryAsync
    {
        private readonly DbSet<Customer> _customer;

        public CustomerRepositoryAsync(ApplicationDbContext dbContext) : base(dbContext)
        {
            _customer = dbContext.Set<Customer>();
        }

        public async ValueTask<List<Customer>> GetAllCustomerAsync()
        {
            IQueryable<Customer> query = _customer.AsQueryable();
            return await query.ToListAsync();
        }


        public async ValueTask<Customer> GetCustomerByIdAsync(int id)
        {
            IQueryable<Customer> query = _customer.Where(q => q.Id.Equals(id));
            return await query.SingleOrDefaultAsync();
        }

        public async ValueTask<bool> IsUniqueCustomerAsync(string email)
        {
            return await _customer.AnyAsync(q => q.Email.Equals(email));
        }
    }
}
