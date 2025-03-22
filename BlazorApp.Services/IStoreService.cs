using BlazorApp.ViewModel;

namespace BlazorApp.Services
{
    /// <summary>
    /// Store service
    /// </summary>
    public interface IStoreService
    {
        /// <summary>
        /// Get store
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<StoreModel> Get(int id);

        /// <summary>
        /// Add category 
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        Task<int> Create(StoreModel store);

        /// <summary>
        /// update category
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        Task<int> Update(StoreModel store);

        /// <summary>
        /// Get list of category based on predicate
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        Task<List<StoreModel>> GetStores();
    }
}
