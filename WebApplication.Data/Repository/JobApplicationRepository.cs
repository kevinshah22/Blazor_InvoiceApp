using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace BlazorApp.Data.Repository
{
    public class JobApplicationRepository : IJobApplicationRepository
    {
        private readonly BlazorContext _blazorContext;
        public JobApplicationRepository(BlazorContext context)
        {
            _blazorContext = context;
        }

        /// <summary>
        /// Add item 
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public async Task<int> Create(Data.Models.JobApplication jobApplicaton)
        {
            _blazorContext.JobApplications.Add(jobApplicaton);
            await _blazorContext.SaveChangesAsync();

            return jobApplicaton.Id;
        }

        /// <summary>
        /// update item
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public async Task<int> Update(Data.Models.JobApplication jobApplicaton)
        {
            _blazorContext.Entry(jobApplicaton).State = EntityState.Modified;
            return await _blazorContext.SaveChangesAsync();
        }

        /// <summary>
        /// Delete item
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public async Task<int> Delete(Data.Models.JobApplication jobApplicaton)
        {
            _blazorContext.Entry(jobApplicaton).State = EntityState.Deleted;
            return await _blazorContext.SaveChangesAsync();
        }

        /// <summary>
        /// Get item based on predicate
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public async Task<Data.Models.JobApplication> GetItem(Expression<Func<Data.Models.JobApplication, bool>> predicate)
        {
            Data.Models.JobApplication item = await _blazorContext.JobApplications.Where(predicate).FirstOrDefaultAsync();
            return item;
        }

        /// <summary>
        /// Get list of items based on predicate
        /// </summary>        
        /// <returns></returns>
        public async Task<List<Data.Models.JobApplication>> GetJobs()
        {
            return await _blazorContext.JobApplications.ToListAsync();
        }
    }
}
