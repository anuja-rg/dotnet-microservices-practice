using MediatR;
using Play.Catalog.Service.Models;
using Play.Catalog.Service.Repositories;
using Play.Catalog.Service.Requests.Commands;

namespace Play.Catalog.Service.Requests.Handlers
{
    public class CreateItemCommandHandler(IItemRepository repository) : IRequestHandler<CreateItemCommand, CreatedItemDto>
    {
        private readonly IItemRepository _repository = repository ?? throw new ArgumentNullException(nameof(repository), "Repository cannot be null.");
        public async Task<CreatedItemDto> Handle(CreateItemCommand request, CancellationToken cancellationToken)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request), "Request cannot be null.");
            }

            var item = new Item
            {
                Id = Guid.NewGuid(),
                Name = request.Name,
                Description = request.Description ?? string.Empty,
                Price = request.Price,
                CreatedDate = DateTime.UtcNow
            };
            var savedItem = await _repository.AddAsync(item);
            return savedItem == null
                ? throw new InvalidOperationException("Failed to create item.")
                : new CreatedItemDto(
                    Name: savedItem.Name,
                    Description: savedItem.Description ?? string.Empty,
                    Price: savedItem.Price
                );
        }
    }
}
