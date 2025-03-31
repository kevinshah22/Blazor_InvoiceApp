using AutoMapper;
using BlazorApp.Data.Models;
using BlazorApp.Data.Repository;
using BlazorApp.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    [Route("v1/[controller]")]
    [ApiController]
    public class JobApplicationController : ControllerBase
    {
        private readonly IJobApplicationRepository _jobApplicationRepository;
        private readonly IMapper _mapper;
        public JobApplicationController(IJobApplicationRepository jobApplicationRepository, IMapper mapper)
        {
            _jobApplicationRepository = jobApplicationRepository;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetJob(int id)
        {
            return Ok(_mapper.Map<ItemModel>(await _jobApplicationRepository.GetItem(x => x.Id == id)));
        }

        [HttpPost]
        public async Task<IActionResult> Create(JobApplicationModel jobApplication)
        {
            JobApplication createItem = _mapper.Map<JobApplication>(jobApplication);
            return Ok(await _jobApplicationRepository.Create(createItem));
        }

        [HttpGet]
        public async Task<IActionResult> GetJobs()
        {
            return Ok(_mapper.Map<List<JobApplicationModel>>(await _jobApplicationRepository.GetJobs()));
        }

        [HttpPut]
        public async Task<IActionResult> Update(JobApplicationModel jobApplication)
        {
            JobApplication dbItem = await _jobApplicationRepository.GetItem(x => x.Id == jobApplication.Id);

            if (dbItem != null)
            {
                dbItem.JobTitle = jobApplication.JobTitle;
                dbItem.JobDescription = jobApplication.JobDescription;
                dbItem.SalaryRange = jobApplication.SalaryRange;
                dbItem.CompanyName = jobApplication.CompanyName;
                dbItem.JobLink = jobApplication.JobLink;
                dbItem.JobStatus = jobApplication.JobStatus;


                return Ok(await _jobApplicationRepository.Update(dbItem));
            }

            return NotFound("Item not found");
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(JobApplicationModel item)
        {
            JobApplication dbItem = await _jobApplicationRepository.GetItem(x => x.Id == item.Id);

            if (dbItem != null)
            {
                return Ok(await _jobApplicationRepository.Delete(dbItem));
            }

            return NotFound("Job not found");
        }
    }
}
