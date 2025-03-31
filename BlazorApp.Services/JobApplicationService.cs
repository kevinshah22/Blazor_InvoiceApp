using BlazorApp.Core;
using BlazorApp.ViewModel;
using Flurl;
using Flurl.Http;

namespace BlazorApp.Services
{
    public class JobApplicationService : IJobApplicationService
    {
        private readonly ApplicationSettings _settings;

        public JobApplicationService(ApplicationSettings settings)
        {
            _settings = settings;
        }

        /// <summary>
        /// Get item
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<JobApplicationModel> Get(int id)
        {
            APIResponse apiResponse = await _settings.APIEndPoint.AppendPathSegment($"{APIRoutes.JobApplicationController}/{id}")
                                           .GetJsonAsync<APIResponse>();

            return ResponseHelper.GetResponse<JobApplicationModel>(apiResponse);
        }

        /// <summary>
        /// Add category 
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        public async Task<int> Create(JobApplicationModel jobApplication)
        {
            APIResponse apiResponse = await _settings.APIEndPoint.AppendPathSegment(APIRoutes.JobApplicationController)
                                           .PostJsonAsync(jobApplication)
                                           .ReceiveJson<APIResponse>();

            return ResponseHelper.GetResponse<int>(apiResponse);
        }

        /// <summary>
        /// update category
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        public async Task<int> Update(JobApplicationModel jobApplication)
        {
            APIResponse apiResponse = await _settings.APIEndPoint.AppendPathSegment(APIRoutes.JobApplicationController)
                                               .PutJsonAsync(jobApplication)
                                               .ReceiveJson<APIResponse>();

            return ResponseHelper.GetResponse<int>(apiResponse);
        }

        /// <summary>
        /// Get list of category based on predicate
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public async Task<List<JobApplicationModel>> GetJobs()
        {
            APIResponse apiResponse = await _settings.APIEndPoint.AppendPathSegment(APIRoutes.JobApplicationController)
                                               .GetJsonAsync<APIResponse>();

            return ResponseHelper.GetResponse<List<JobApplicationModel>>(apiResponse);
        }
    }
}
