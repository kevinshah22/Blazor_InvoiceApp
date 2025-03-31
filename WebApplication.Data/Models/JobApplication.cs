using System.ComponentModel.DataAnnotations;

namespace BlazorApp.Data.Models
{
    public class JobApplication
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string JobTitle { get; set; }
        [Required]
        public string CompanyName { get; set; }
        public string JobLink { get; set; }
        [Required]
        public string JobDescription { get; set; }
        public string SalaryRange { get; set; }
        [Required]
        public byte JobStatus { get; set; }
        public DateTime AppliedDate { get; set; }
        public string? RejectionReason { get; set; }
    }
}
