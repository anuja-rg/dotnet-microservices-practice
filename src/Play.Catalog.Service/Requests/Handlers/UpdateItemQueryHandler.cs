using MediatR;
using Play.Catalog.Service.Repositories;
using Play.Catalog.Service.Requests.Queries;

namespace Play.Catalog.Service.Requests.Handlers
{
    public class UpdateItemQueryHandler(IItemRepository repository) : IRequestHandler<UpdateItemQuery, ItemDtoOut>
    {
        private readonly IItemRepository _repository = repository;

        public Task<ItemDtoOut> Handle(UpdateItemQuery request, CancellationToken cancellationToken)
        {
            var item = _repository.GetByIdAsync(request.Id).Result;
            if (item == null)
            {
                throw new KeyNotFoundException($"Item with ID {request.Id} not found.");
            }
            item.Name = request.UpdateItemDto.Name;
            item.Description = request.UpdateItemDto.Description;
            item.Price = request.UpdateItemDto.Price;

            _repository.UpdateAsync(item);
            return Task.FromResult(new ItemDtoOut(
                Id: item.Id.ToString(),
                Name: item.Name,
                Description: item.Description ?? string.Empty,
                Price: item.Price,
                CreatedDate: item.CreatedDate));
        }
    }
}
