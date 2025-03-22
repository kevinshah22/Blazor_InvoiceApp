using BlazorApp.ViewModel;

namespace BlazorApp.Services
{
    /// <summary>
    /// Category service
    /// </summary>
    public interface ICategoryService
    {
        /// <summary>
        /// Get list of category 
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        Task<CategoryModel> GetCategory(int id);

        /// <summary>
        /// Add category 
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        Task<int> Create(CategoryModel category);

        /// <summary>
        /// update category
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        Task<int> Update(CategoryModel category);

        /// <summary>
        /// Get list of category based on predicate
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        Task<List<CategoryModel>> GetCategories();
    }
}
