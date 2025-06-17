using MediatR;

namespace Play.Catalog.Service.Requests.Queries
{
    public record GetAllItemsQuery : IRequest<IEnumerable<ItemDtoOut>>
    {
    }
}
