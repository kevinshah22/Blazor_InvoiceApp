using System.Linq.Expressions;

namespace BlazorApp.Data.Repository
{
    public interface IStoreRepository
    {
        /// <summary>
        /// Add store 
        /// </summary>
        /// <param name="store"></param>
        /// <returns></returns>
        Task<int> Create(Data.Models.Store store);

        /// <summary>
        /// update store
        /// </summary>
        /// <param name="store"></param>
        /// <returns></returns>
        Task<int> Update(Data.Models.Store store);

        /// <summary>
        /// Delete Store
        /// </summary>
        /// <param name="store"></param>
        /// <returns></returns>
        Task<int>Delete (Data.Models.Store store);

        /// <summary>
        /// Get store based on predicate
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        Task<Data.Models.Store> GetStore(Expression<Func<Data.Models.Store, bool>> predicate);

        /// <summary>
        /// Get list of stores based on predicate
        /// </summary>        
        /// <returns></returns>
        Task<List<Data.Models.Store>> GetStores();
    }
}
