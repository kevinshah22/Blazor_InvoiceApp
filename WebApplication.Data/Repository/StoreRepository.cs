using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace BlazorApp.Data.Repository
{
    public class StoreRepository : IStoreRepository
    {
        private readonly BlazorContext _blazorContext;
        public StoreRepository(BlazorContext context)
        {
            _blazorContext = context;
        }


        /// <summary>
        /// Add category 
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        public async Task<int> Create(Models.Store store)
        {
            await _blazorContext.Stores.AddAsync(store);
            await _blazorContext.SaveChangesAsync();

            return store.Id;
        }

        /// <summary>
        /// update category
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        public async Task<int> Update(Models.Store store)
        {
            _blazorContext.Entry(store).State = EntityState.Modified;
            return await _blazorContext.SaveChangesAsync();
        }

        /// <summary>
        /// delete store
        /// </summary>
        /// <param name="store"></param>
        /// <returns></returns>
        public async Task<int> Delete(Models.Store store)
        {
            _blazorContext.Entry(store).State = EntityState.Deleted;
            return await _blazorContext.SaveChangesAsync();
        }

        /// <summary>
        /// Get category based on predicate
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public async Task<Data.Models.Store> GetStore(Expression<Func<Data.Models.Store, bool>> predicate)
        {
            return await _blazorContext.Stores.Where(predicate).FirstOrDefaultAsync();
        }

        /// <summary>
        /// Get list of category based on predicate
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public async Task<List<Data.Models.Store>> GetStores()
        {
            try
            {
                return await _blazorContext.Stores.ToListAsync();
            }
            catch (Exception ex)
            {

                throw;
            }
            
        }
    }
}
