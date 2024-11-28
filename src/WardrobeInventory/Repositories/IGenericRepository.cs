namespace WardrobeInventory.Repositories;

public interface IGenericRepository<T> where T : class
{
    Task<bool> CreateAsync(T entity);
    Task<bool> DeleteAsync(Guid id);
    Task<IReadOnlyList<T>> ReturnAsync();
    Task<T?> ReturnAsync(Guid id);
    Task<bool> UpdateAsync(T entity);
}