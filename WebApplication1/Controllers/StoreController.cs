using AutoMapper;
using BlazorApp.Data.Models;
using BlazorApp.Data.Repository;
using BlazorApp.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    [Route("v1/[controller]")]
    [ApiController]
    public class StoreController : ControllerBase
    {
        private readonly IStoreRepository _storeRepository;
        private readonly IMapper _mapper;
        public StoreController(IStoreRepository storeRepository, IMapper mapper)
        {
            _storeRepository = storeRepository;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetStore(int id)
        {
            return Ok(_mapper.Map<StoreModel>(await _storeRepository.GetStore(x => x.Id == id)));
        }

        [HttpPost]
        public async Task<IActionResult> Create(StoreModel store)
        {
            Store createStore = _mapper.Map<Store>(store);
            return Ok(await _storeRepository.Create(createStore));
        }

        [HttpGet]
        public async Task<IActionResult> GetCategories()
        {
            return Ok(_mapper.Map<List<StoreModel>>(await _storeRepository.GetStores()));
        }

        [HttpPut]
        public async Task<IActionResult> Update(StoreModel store)
        {
            Store dbStore = await _storeRepository.GetStore(x => x.Id == store.Id);

            if (dbStore != null)
            {
                dbStore.Name = store.Name;
                dbStore.Description = store.Description;

                return Ok(await _storeRepository.Update(dbStore));
            }

            return NotFound("Store not found");
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(StoreModel store)
        {
            Store dbStore = await _storeRepository.GetStore(x => x.Id == store.Id);

            if (dbStore != null)
            {
                return Ok(await _storeRepository.Delete(dbStore));
            }

            return NotFound("Store not found");
        }
    }
}
