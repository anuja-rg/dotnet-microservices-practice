using MediatR;

namespace Play.Catalog.Service.Requests.Queries
{
    public record UpdateItemQuery(Guid Id, UpdateItemDto UpdateItemDto) : IRequest<ItemDtoOut>
    {
    }
}
