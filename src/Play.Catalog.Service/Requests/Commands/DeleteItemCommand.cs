using MediatR;

namespace Play.Catalog.Service.Requests.Commands
{
    public record DeleteItemCommand(Guid Id) : IRequest<bool>
    {
    }
}
