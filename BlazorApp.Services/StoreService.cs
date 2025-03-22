using BlazorApp.Core;
using BlazorApp.ViewModel;
using Flurl;
using Flurl.Http;

namespace BlazorApp.Services
{
    /// <summary>
    /// Store service
    /// </summary>
    public class StoreService : IStoreService
    {
        private readonly ApplicationSettings _settings;

        public StoreService(ApplicationSettings settings)
        {
            _settings = settings;
        }

        /// <summary>
        /// Get store
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<StoreModel> Get(int id)
        {
            APIResponse apiResponse = await _settings.APIEndPoint.AppendPathSegment(APIRoutes.StoreController)
                                           .SetQueryParam("id", id)
                                           .GetJsonAsync<APIResponse>();

            return ResponseHelper.GetResponse<StoreModel>(apiResponse);
        }

        /// <summary>
        /// Add category 
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        public async Task<int> Create(StoreModel store)
        {
            APIResponse apiResponse = await _settings.APIEndPoint.AppendPathSegment(APIRoutes.StoreController)
                                        .PostJsonAsync(store)
                                        .ReceiveJson<APIResponse>();

            return ResponseHelper.GetResponse<int>(apiResponse);
        }

        /// <summary>
        /// update category
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        public async Task<int> Update(StoreModel store)
        {
            APIResponse apiResponse = await _settings.APIEndPoint.AppendPathSegment(APIRoutes.StoreController)
                                            .PutJsonAsync(store)
                                            .ReceiveJson<APIResponse>();

            return ResponseHelper.GetResponse<int>(apiResponse);
        }

        /// <summary>
        /// Get list of category based on predicate
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public async Task<List<StoreModel>> GetStores()
        {
            APIResponse apiResponse = await _settings.APIEndPoint.AppendPathSegment(APIRoutes.StoreController)
                                               .GetJsonAsync<APIResponse>();

            return ResponseHelper.GetResponse<List<StoreModel>>(apiResponse);
        }
    }
}
