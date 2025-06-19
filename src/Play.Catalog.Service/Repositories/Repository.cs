
using Microsoft.EntityFrameworkCore;

namespace Play.Catalog.Service.Repositories
{
    public class Repository<T>(AppDbContext context) : IRepository<T> where T : class
    {

        protected readonly AppDbContext _context = context ?? throw new ArgumentNullException(nameof(context));
        public async Task<T?> AddAsync(T entity)
        {
            _context.Set<T>().Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var entity = await _context.Set<T>().FindAsync(id);
            if (entity == null)
            {
                return false;
            }
            _context.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<T?> GetByIdAsync(Guid id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task<T?> UpdateAsync(T entity)
        {
            var entry = await _context.Set<T>().FindAsync(_context.Entry(entity).Property("Id").CurrentValue);
            if (entry == null) return null;

            _context.Entry(entry).CurrentValues.SetValues(entity);
            await _context.SaveChangesAsync();
            return entry;
        }
    }
}
