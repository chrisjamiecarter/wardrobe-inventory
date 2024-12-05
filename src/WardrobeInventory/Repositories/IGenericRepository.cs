using WardrobeInventory.Entities;

namespace WardrobeInventory.Repositories;

public interface IGenericRepository<T> where T : BaseEntity
{
    Task<bool> CreateAsync(T entity);
    Task<bool> DeleteAsync(T entity);
    Task<IReadOnlyList<T>> ReturnAsync();
    Task<T?> ReturnAsync(Guid id);
    Task<bool> UpdateAsync(T entity);
}