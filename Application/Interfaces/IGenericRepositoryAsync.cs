namespace Application.Interfaces
{
    public interface IGenericRepositoryAsync<T> where T : class
    {
        ValueTask<T> GetByIdAsync(int id);
        ValueTask<IReadOnlyList<T>> GetAllAsync();
        ValueTask<T> AddAsync(T entity);
        ValueTask UpdateAsync(T entity);
        ValueTask DeleteAsync(T entity);
    }
}
