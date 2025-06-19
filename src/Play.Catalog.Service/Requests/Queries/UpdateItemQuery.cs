using MediatR;

namespace Play.Catalog.Service.Requests.Queries
{
    public record UpdateItemQuery : IRequest<ItemDtoOut>
    {
    }
}
