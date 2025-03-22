using System.Linq.Expressions;

namespace BlazorApp.Data.Repository
{
    /// <summary>
    /// Item repositroy
    /// </summary>
    public interface IItemRepository
    {
        /// <summary>
        /// Add item 
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        Task<int> Create(Data.Models.Item item);

        /// <summary>
        /// update item
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        Task<int> Update(Data.Models.Item item);

        /// <summary>
        /// Delete item
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        Task<int> Delete(Data.Models.Item item);

        /// <summary>
        /// Get item based on predicate
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        Task<Data.Models.Item> GetItem(Expression<Func<Data.Models.Item, bool>> predicate);

        /// <summary>
        /// Get list of items based on predicate
        /// </summary>        
        /// <returns></returns>
        Task<List<Data.Models.Item>> GetItems();
    }
}
