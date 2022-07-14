namespace Application.Interfaces.Repositories
{
    public interface IProductRepositoryAsync : IGenericRepositoryAsync<Product>
    {
        ValueTask<List<Product>> GetAllProductsExistentsAsync();
    }
}
