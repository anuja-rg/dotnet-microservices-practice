using Microsoft.AspNetCore.Mvc;

namespace Play.Catalog.Service.Controllers
{
    [ApiController]
    [Route("items")]
    public class ItemsController : ControllerBase
    {
        private static readonly List<ItemDto> items =
        [
                new ItemDto(Guid.NewGuid(), "Item 1", "Description for Item 1", 10, DateTimeOffset.UtcNow),
                new ItemDto(Guid.NewGuid(), "Item 2", "Description for Item 2", 7, DateTimeOffset.UtcNow),
                new ItemDto(Guid.NewGuid(), "Item 3", "Description for Item 3", 5, DateTimeOffset.UtcNow)
        ];

        [HttpGet]
        public IEnumerable<ItemDto> Get()
        {
            return items;
        }

        [HttpGet("{Id}")]
        public ActionResult<ItemDto> GetById(Guid Id)
        {
            var item = items.FirstOrDefault(item => item.Id == Id);
            if (item == null)
            {
                return NotFound();
            }
            return item;
        }

        [HttpPost]
        public ActionResult<ItemDto> Post(CreatedItemDto createdItemDto)
        {
            var item = new ItemDto(Guid.NewGuid(), createdItemDto.Name, createdItemDto.Description, createdItemDto.Price, DateTimeOffset.UtcNow);
            items.Add(item);
            return CreatedAtAction(nameof(GetById), new {id = item.Id}, item);
        }

        [HttpPut("{Id}")]
        public IActionResult Put(Guid Id, UpdateItemDto updateItemDto) { 
            var existingItem = items.Where(item =>  item.Id == Id).FirstOrDefault();
            if (existingItem == null)
            {
                return NotFound();
            }

            var updatedItem = existingItem with
            {
                Name = updateItemDto.Name,
                Description = updateItemDto.Description,
                Price = updateItemDto.Price
            };

            var index = items.FindIndex(item => item.Id == Id);
            items[index] = updatedItem;
            return NoContent();
        }

        [HttpDelete("{Id}")]
        public IActionResult Delete(Guid Id) { 
            var index = items.FindIndex(item => item.Id == Id);
            if (index < 0)
            {
                return NotFound();
            }
            items.RemoveAt(index);
            return NoContent();
        }
    }
}
