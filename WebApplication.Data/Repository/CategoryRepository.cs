using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace BlazorApp.Data.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly BlazorContext _blazorContext;
        public CategoryRepository(BlazorContext context)
        {
            _blazorContext = context;
        }


        /// <summary>
        /// Add category 
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        public async Task<int> Create(Models.Category category)
        {
            await _blazorContext.Categories.AddAsync(category);
            await _blazorContext.SaveChangesAsync();

            return category.Id;
        }

        /// <summary>
        /// update category
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        public async Task<int> Update(Models.Category category)
        {
            _blazorContext.Entry(category).State = EntityState.Modified;
            return await _blazorContext.SaveChangesAsync();
        }

        /// <summary>
        /// Get category based on predicate
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public async Task<Models.Category> Getcategory(Expression<Func<Models.Category, bool>> predicate)
        {
            return await _blazorContext.Categories.Where(predicate).FirstOrDefaultAsync();
        }

        /// <summary>
        /// Get list of category based on predicate
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public async Task<List<Data.Models.Category>> GetCategories()
        {
            return await _blazorContext.Categories.ToListAsync();
        }
    }
}
