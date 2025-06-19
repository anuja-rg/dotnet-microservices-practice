using Microsoft.AspNetCore.Mvc;
using MediatR;
using System.Threading.Tasks;
using Play.Catalog.Service.Requests.Commands;
using Play.Catalog.Service.Requests.Queries;

namespace Play.Catalog.Service.Controllers
{
    [ApiController]
    [Route("items")]
    public class ItemsController(IMediator mediator) : ControllerBase
    {
        private readonly IMediator _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator), "Mediator cannot be null.");

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var query = new GetAllItemsQuery();
            var items = await _mediator.Send(query);

            if (items == null || !items.Any())
            {
                return NotFound("No items found.");
            }
            return Ok(items);

        }

        [HttpGet("{Id}")]
        public ActionResult<ItemDto> GetById(Guid Id)
        {
            var item = new GetItemByIdQuery(Id);

            try
            {
                var itemDto = _mediator.Send(item);
                return Ok(itemDto.Result);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
           
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CreateItemCommand command)
        {
            var createdItem = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetById), new { Id = createdItem.Name }, createdItem);
        }

        [HttpPut("{Id}")]
        public IActionResult Put(Guid Id, [FromBody] UpdateItemDto updateItemDto) { 
            
            var updatedItem = new UpdateItemQuery(Id, updateItemDto);
            try
            {
                var itemDto = _mediator.Send(updatedItem);
                return Ok(itemDto.Result);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete(Guid Id)
        {
            var result = await _mediator.Send(new DeleteItemCommand(Id));
            if (result)
            {
                return NoContent();
            }
            else
            {
                return NotFound();
            }
        }
    }
}
