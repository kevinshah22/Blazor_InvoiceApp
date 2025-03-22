using System.Linq.Expressions;

namespace BlazorApp.Data.Repository
{
    public interface ICategoryRepository
    {
        /// <summary>
        /// Add category 
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        Task<int> Create(Data.Models.Category category);

        /// <summary>
        /// update category
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        Task<int> Update(Data.Models.Category category);

        /// <summary>
        /// Get category based on predicate
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        Task<Data.Models.Category> Getcategory(Expression<Func<Data.Models.Category, bool>> predicate);

        /// <summary>
        /// Get list of category based on predicate
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        Task<List<Data.Models.Category>> GetCategories();
    }
}
