using BlazorApp.Core;
using BlazorApp.ViewModel;
using Flurl;
using Flurl.Http;

namespace BlazorApp.Services
{
    public class InvoiceService : IInvoiceService
    {
        private readonly ApplicationSettings _settings;

        public InvoiceService(ApplicationSettings settings)
        {
            _settings = settings;
        }

        /// <summary>
        /// Get list of category 
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public async Task<InvoiceModel> GetInvoice(int invoiceId)
        {
            APIResponse apiResponse = await _settings.APIEndPoint.AppendPathSegment($"{APIRoutes.InvoiceController}/{invoiceId}")
                                           //.SetQueryParam("id", id)
                                           .GetJsonAsync<APIResponse>();

            return ResponseHelper.GetResponse<InvoiceModel>(apiResponse);
        }

        /// <summary>
        /// Get list of category 
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public async Task<List<InvoiceItemModel>> GetInvoiceItems(int invoiceId)
        {
            APIResponse apiResponse = await _settings.APIEndPoint.AppendPathSegment($"{APIRoutes.InvoiceController}/invoice-items/{invoiceId}")
                                           .GetJsonAsync<APIResponse>();

            return ResponseHelper.GetResponse<List<InvoiceItemModel>>(apiResponse);
        }

        /// <summary>
        /// Add category 
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        public async Task<int> Create(InvoiceCreateModel invoice)
        {
            APIResponse apiResponse = await _settings.APIEndPoint.AppendPathSegment(APIRoutes.InvoiceController)
                                        .PostJsonAsync(invoice)
                                        .ReceiveJson<APIResponse>();

            return ResponseHelper.GetResponse<int>(apiResponse);
        }

        /// <summary>
        /// Add category 
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        public async Task<int> Update(InvoiceCreateModel invoice)
        {
            APIResponse apiResponse = await _settings.APIEndPoint.AppendPathSegment(APIRoutes.InvoiceController)
                                        .PutJsonAsync(invoice)
                                        .ReceiveJson<APIResponse>();

            return ResponseHelper.GetResponse<int>(apiResponse);
        }


        /// <summary>
        /// Get list of category 
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public async Task<List<InvoiceModel>> GetInvoices()
        {
            APIResponse apiResponse = await _settings.APIEndPoint.AppendPathSegment($"{APIRoutes.InvoiceController}")
                                           .GetJsonAsync<APIResponse>();

            return ResponseHelper.GetResponse<List<InvoiceModel>>(apiResponse);
        }
    }
}
