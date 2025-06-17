using MediatR;
using Play.Catalog.Service.Repositories;
using Play.Catalog.Service.Requests.Queries;

namespace Play.Catalog.Service.Requests.Handlers
{
    public class GetAllItemsQueryHandler(IItemRepository repository) : IRequestHandler<GetAllItemsQuery, IEnumerable<ItemDtoOut>>
    {
        private readonly IItemRepository _repository = repository ?? throw new ArgumentNullException(nameof(repository), "Repository cannot be null.");

        public async Task<IEnumerable<ItemDtoOut>> Handle(GetAllItemsQuery request, CancellationToken cancellationToken)
        {
            var items = await _repository.GetAllAsync();
            return items.Select(item => new ItemDtoOut(Id: item.Id.ToString(), Name: item.Name, Description: item.Description ?? string.Empty, Price: item.Price, CreatedDate: item.CreatedDate));
        }
    }
}
