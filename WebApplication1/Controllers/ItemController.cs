using AutoMapper;
using BlazorApp.Data.Models;
using BlazorApp.Data.Repository;
using BlazorApp.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    [Route("v1/[controller]")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        private readonly IItemRepository _itemRepository;
        private readonly IMapper _mapper;
        public ItemController(IItemRepository itemRepository, IMapper mapper)
        {
            _itemRepository = itemRepository;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetItem(int id)
        {
            return Ok(_mapper.Map<ItemModel>(await _itemRepository.GetItem(x => x.Id == id)));
        }

        [HttpPost]
        public async Task<IActionResult> Create(ItemModel item)
        {
            Item createItem = _mapper.Map<Item>(item);
            return Ok(await _itemRepository.Create(createItem));
        }

        [HttpGet]
        public async Task<IActionResult> GetCategories()
        {
            return Ok(_mapper.Map<List<ItemModel>>(await _itemRepository.GetItems()));
        }

        [HttpPut]
        public async Task<IActionResult> Update(ItemModel item)
        {
            Item dbItem = await _itemRepository.GetItem(x => x.Id == item.Id);

            if (dbItem != null)
            {
                dbItem.Name = item.Name;
                dbItem.Description = item.Description;
                dbItem.CategoryId = item.CategoryId;

                return Ok(await _itemRepository.Update(dbItem));
            }

            return NotFound("Item not found");
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(ItemModel item)
        {
            Item dbItem = await _itemRepository.GetItem(x => x.Id == item.Id);

            if (dbItem != null)
            {
                return Ok(await _itemRepository.Delete(dbItem));
            }

            return NotFound("Item not found");
        }
    }
}
