using BlazorApp.Core;
using BlazorApp.ViewModel;
using Flurl;
using Flurl.Http;

namespace BlazorApp.Services
{
    public class ItemService : IItemService
    {
        private readonly ApplicationSettings _settings;

        public ItemService(ApplicationSettings settings)
        {
            _settings = settings;
        }


        /// <summary>
        /// Get Item
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ItemModel> Get(int id)
        {
            APIResponse apiResponse = await _settings.APIEndPoint.AppendPathSegment($"{APIRoutes.ItemController}/{id}")
                                        .GetJsonAsync<APIResponse>();

            return ResponseHelper.GetResponse<ItemModel>(apiResponse);
        }

        /// <summary>
        /// Add category 
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        public async Task<int> Create(ItemModel item)
        {
            APIResponse apiResponse = await _settings.APIEndPoint.AppendPathSegment(APIRoutes.ItemController)
                                        .PostJsonAsync(item)
                                        .ReceiveJson<APIResponse>();

            return ResponseHelper.GetResponse<int>(apiResponse);
        }

        /// <summary>
        /// update category
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        public async Task<int> Update(ItemModel item)
        {
            APIResponse apiResponse = await _settings.APIEndPoint.AppendPathSegment(APIRoutes.ItemController)
                                            .PutJsonAsync(item)
                                            .ReceiveJson<APIResponse>();

            return ResponseHelper.GetResponse<int>(apiResponse);
        }

        /// <summary>
        /// Get list of category based on predicate
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public async Task<List<ItemModel>> GetItems()
        {
            APIResponse apiResponse = await _settings.APIEndPoint.AppendPathSegment(APIRoutes.ItemController)
                                               .GetJsonAsync<APIResponse>();

            return ResponseHelper.GetResponse<List<ItemModel>>(apiResponse);
        }
    }
}
