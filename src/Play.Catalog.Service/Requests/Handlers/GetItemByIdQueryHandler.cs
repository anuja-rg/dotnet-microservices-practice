using MediatR;
using Play.Catalog.Service.Repositories;
using Play.Catalog.Service.Requests.Queries;

namespace Play.Catalog.Service.Requests.Handlers
{
    public class GetItemByIdQueryHandler(IItemRepository repository) : IRequestHandler<GetItemByIdQuery, ItemDtoOut>
    {
        private readonly IItemRepository _repository = repository ?? throw new ArgumentNullException(nameof(repository), "Repository cannot be null.");
        public async Task<ItemDtoOut> Handle(GetItemByIdQuery request, CancellationToken cancellationToken)
        {
            var item = await _repository.GetByIdAsync(request.Id);
            return item == null
                ? throw new KeyNotFoundException($"Item with ID {request.Id} not found.")
                : new ItemDtoOut(Id: item.Id.ToString(), Name: item.Name, Description: item.Description ?? string.Empty, Price: item.Price, CreatedDate: item.CreatedDate);
        }
    }
    
}
