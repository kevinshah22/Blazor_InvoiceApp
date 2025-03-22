using BlazorApp.ViewModel;

namespace BlazorApp.Services
{
    /// <summary>
    /// Item service
    /// </summary>
    public interface IItemService
    {
        /// <summary>
        /// Get item
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<ItemModel> Get(int id);

        /// <summary>
        /// Add category 
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        Task<int> Create(ItemModel item);

        /// <summary>
        /// update category
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        Task<int> Update(ItemModel item);

        /// <summary>
        /// Get list of category based on predicate
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        Task<List<ItemModel>> GetItems();
    }
}
