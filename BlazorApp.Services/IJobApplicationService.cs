using BlazorApp.ViewModel;

namespace BlazorApp.Services
{
    public interface IJobApplicationService
    {
        /// <summary>
        /// Get item
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<JobApplicationModel> Get(int id);

        /// <summary>
        /// Add category 
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        Task<int> Create(JobApplicationModel jobApplication);

        /// <summary>
        /// update category
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        Task<int> Update(JobApplicationModel jobApplication);

        /// <summary>
        /// Get list of category based on predicate
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        Task<List<JobApplicationModel>> GetJobs();
    }
}
