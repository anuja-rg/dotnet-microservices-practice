using MediatR;

namespace Play.Catalog.Service.Requests.Commands
{
    public record CreateItemCommand(string Name, string Description, decimal Price) : IRequest<ItemDto>
    {
    }
}
