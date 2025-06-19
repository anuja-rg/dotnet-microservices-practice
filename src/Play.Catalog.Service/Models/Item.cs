using Microsoft.EntityFrameworkCore;

namespace Play.Catalog.Service.Models
{
    public class Item : IEntity
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public required string Name { get; set; }
        public required string? Description { get; set; }
        [Precision(18, 2)]
        public decimal Price { get; set; }
        public DateTimeOffset CreatedDate { get; set; } = DateTimeOffset.UtcNow;
    }
}
