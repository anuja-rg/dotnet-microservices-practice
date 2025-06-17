using Microsoft.EntityFrameworkCore;
using Play.Catalog.Service.Models;

namespace Play.Catalog.Service
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public DbSet<Item> Items => Set<Item>();
    protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Item>().HasData(
     new Item { Id = Guid.Parse("11111111-1111-1111-1111-111111111111"), Name = "Item 1", Description = "Description for Item 1", Price = 10.8M, CreatedDate = DateTimeOffset.Parse("2024-01-01T00:00:00Z") },
     new Item { Id = Guid.Parse("22222222-2222-2222-2222-222222222222"), Name = "Item 2", Description = "Description for Item 2", Price = 15.5M, CreatedDate = DateTimeOffset.Parse("2024-01-02T00:00:00Z") },
     new Item { Id = Guid.Parse("33333333-3333-3333-3333-333333333333"), Name = "Item 3", Description = "Description for Item 3", Price = 20.2M, CreatedDate = DateTimeOffset.Parse("2024-01-03T00:00:00Z") }
 );
        }
    }
}
