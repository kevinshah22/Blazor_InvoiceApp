using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Linq.Expressions;

namespace BlazorApp.Data.Repository
{
    /// <summary>
    /// Item repositroy
    /// </summary>
    public class ItemRepository: IItemRepository
    {
        private readonly BlazorContext _blazorContext;
        public ItemRepository(BlazorContext context)
        {
            _blazorContext = context;
        }

        /// <summary>
        /// Add item 
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public async Task<int> Create(Data.Models.Item item)
        {
            await _blazorContext.Items.AddAsync(item);
            await _blazorContext.SaveChangesAsync();

            return item.Id;
        }

        /// <summary>
        /// update item
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public async Task<int> Update(Data.Models.Item item)
        {
            _blazorContext.Entry(item).State = EntityState.Modified;
            return await _blazorContext.SaveChangesAsync();
        }

        /// <summary>
        /// Delete item
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>

        public async Task<int> Delete(Data.Models.Item item)
        {
            _blazorContext.Entry(item).State = EntityState.Deleted;
            return await _blazorContext.SaveChangesAsync();
        }

        /// <summary>
        /// Get item based on predicate
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public async Task<Data.Models.Item> GetItem(Expression<Func<Data.Models.Item, bool>> predicate)
        {

            Data.Models.Item item = await _blazorContext.Items.Where(predicate).Include(x=> x.CategoryData).FirstOrDefaultAsync();
            return item;
        }

        /// <summary>
        /// Get list of items based on predicate
        /// </summary>        
        /// <returns></returns>
        public async Task<List<Data.Models.Item>> GetItems()
        {
            return await _blazorContext.Items.Include(x=> x.CategoryData).ToListAsync();
        }
    }
}
