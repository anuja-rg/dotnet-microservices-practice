using MediatR;
using Play.Catalog.Service.Repositories;
using Play.Catalog.Service.Requests.Commands;

namespace Play.Catalog.Service.Requests.Handlers
{
    public class DeleteItemCommandHandler(IItemRepository repository) : IRequestHandler<DeleteItemCommand, bool>

    {
        private readonly IItemRepository _repository = repository ?? throw new ArgumentNullException(nameof(repository), "Repository cannot be null.");
        public Task<bool> Handle(DeleteItemCommand request, CancellationToken cancellationToken)
        {
            //var item = _repository.GetByIdAsync(request.Id);
            //if (item == null)
            //{
            //    return Task.FromResult(false);
            //} else
            //{
            return _repository.DeleteAsync(request.Id);
                
            //}
        }
    }
}
