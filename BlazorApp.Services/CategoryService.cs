using BlazorApp.Core;
using BlazorApp.ViewModel;
using Flurl;
using Flurl.Http;

namespace BlazorApp.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ApplicationSettings _settings;

        public CategoryService(ApplicationSettings settings)
        {
            _settings = settings;
        }

        /// <summary>
        /// Get list of category 
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public async Task<CategoryModel> GetCategory(int id)
        {
            APIResponse apiResponse = await _settings.APIEndPoint.AppendPathSegment($"{APIRoutes.CategoryController}/{id}")
                                           //.SetQueryParam("id", id)
                                           .GetJsonAsync<APIResponse>();

            return ResponseHelper.GetResponse<CategoryModel>(apiResponse);
        }

        /// <summary>
        /// Add category 
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        public async Task<int> Create(CategoryModel category)
        {
            APIResponse apiResponse = await _settings.APIEndPoint.AppendPathSegment(APIRoutes.CategoryController)
                                        .PostJsonAsync(category)
                                        .ReceiveJson<APIResponse>();

            return ResponseHelper.GetResponse<int>(apiResponse);
        }

        /// <summary>
        /// update category
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        public async Task<int> Update(CategoryModel category)
        {
            APIResponse apiResponse = await _settings.APIEndPoint.AppendPathSegment(APIRoutes.CategoryController)
                                            .PutJsonAsync(category)
                                            .ReceiveJson<APIResponse>();

            return ResponseHelper.GetResponse<int>(apiResponse);
        }

        /// <summary>
        /// Get list of category based on predicate
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public async Task<List<CategoryModel>> GetCategories()
        {
            APIResponse apiResponse = await _settings.APIEndPoint.AppendPathSegment(APIRoutes.CategoryController)
                                               .GetJsonAsync<APIResponse>();

            return ResponseHelper.GetResponse<List<CategoryModel>>(apiResponse);
        }

    }
}
