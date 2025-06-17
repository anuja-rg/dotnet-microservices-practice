using MediatR;
using Play.Catalog.Service.Requests.Commands;

namespace Play.Catalog.Service.Requests.Handlers
{
    public class CreateItemCommandHandler : IRequestHandler<CreateItemCommand, ItemDto>
    {
        public Task<ItemDto> Handle(CreateItemCommand request, CancellationToken cancellationToken)
        {
            // Here you would typically interact with your data store to create the item
            // For this example, we will just return a new Guid as if the item was created successfully
            var newItemId = Guid.NewGuid();
            return Task.FromResult(newItemId);
        }
    }
}
