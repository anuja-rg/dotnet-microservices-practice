using MediatR;

namespace Play.Catalog.Service.Requests.Queries
{
    public record GetItemByIdQuery(Guid Id) : IRequest<ItemDtoOut>
    {
    }
}
