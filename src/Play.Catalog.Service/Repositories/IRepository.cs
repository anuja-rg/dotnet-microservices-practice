using Play.Catalog.Service.Models;

namespace Play.Catalog.Service.Repositories
{
    public interface IRepository<T> where T : IEntity
    {
        Task<T?> GetByIdAsync(Guid id);
        Task<IEnumerable<T>> GetAllAsync();
        Task<T?> AddAsync(T entity);
        Task<T?> UpdateAsync(T entity);
        Task<bool> DeleteAsync(Guid id);
    }
}
