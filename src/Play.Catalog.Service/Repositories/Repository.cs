
namespace Play.Catalog.Service.Repositories
{
    public class Repository<T>(AppDbContext context) : IRepository<T> where T : class
    {

        protected readonly AppDbContext _context = context ?? throw new ArgumentNullException(nameof(context));
        public Task<T?> AddAsync(T entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<T>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<T?> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<T?> UpdateAsync(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
