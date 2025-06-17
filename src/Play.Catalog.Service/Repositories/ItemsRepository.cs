using Play.Catalog.Service.Models;

namespace Play.Catalog.Service.Repositories
{
    public class ItemsRepository(AppDbContext context) : Repository<Item>(context), IItemRepository
    {
        
    }
}
