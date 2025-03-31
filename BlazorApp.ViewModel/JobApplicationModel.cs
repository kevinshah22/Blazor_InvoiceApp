using System.ComponentModel.DataAnnotations;

namespace BlazorApp.ViewModel
{
    public class JobApplicationModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please enter job title")]
        public string JobTitle { get; set; }
        [Required(ErrorMessage = "Please enter company name")]
        public string CompanyName { get; set; }
        public string? JobLink { get; set; }
        [Required(ErrorMessage = "Please enter job description")]

        public string JobDescription { get; set; }
        public string? SalaryRange { get; set; }
        [Required(ErrorMessage = "Please select job status")]
        public byte JobStatus { get; set; }
        public DateTime AppliedDate { get; set; }
        public string? RejectionReason { get; set; }
    }
}
