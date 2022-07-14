namespace Infrastructure.Persistence.Repositories
{
    public class ProductRepositoryAsync : GenericRepositoryAsync<Product>, IProductRepositoryAsync
    {
        private readonly DbSet<Product> _product;
        public ProductRepositoryAsync(ApplicationDbContext dbContext) : base(dbContext)
        {
            _product = dbContext.Set<Product>();
        }

        public async ValueTask<List<Product>> GetAllProductsExistentsAsync()
        {

            IQueryable<Product> query = _product.Where(p => p.Quantity > 0);
            return await query.ToListAsync();
        }
    }
}
