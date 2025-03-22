using AutoMapper;
using BlazorApp.Data.Models;
using BlazorApp.Data.Repository;
using BlazorApp.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    [Route("v1/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;
        public CategoryController(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategory(int id)
        {
            return Ok(_mapper.Map<CategoryModel>(await _categoryRepository.Getcategory(x => x.Id == id)));
        }

        [HttpPost]
        public async Task<IActionResult> Create(CategoryModel category)
        {
            Category createCategory = _mapper.Map<Category>(category);
            return Ok(await _categoryRepository.Create(createCategory));
        }

        [HttpGet]
        public async Task<IActionResult> GetCategories()
        {
            return Ok(_mapper.Map<List<CategoryModel>>(await _categoryRepository.GetCategories()));
        }

        [HttpPut]
        public async Task<IActionResult> Update(CategoryModel category)
        {
            Category dbcategory = await _categoryRepository.Getcategory(x => x.Id == category.Id);

            if (dbcategory != null)
            {
                dbcategory.Name = category.Name;
                dbcategory.Description = category.Description;

                return Ok(await _categoryRepository.Update(dbcategory));
            }

            return NotFound("Category not found");
        }
    }
}
