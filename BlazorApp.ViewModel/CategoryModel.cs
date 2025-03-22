using System.ComponentModel.DataAnnotations;

namespace BlazorApp.ViewModel
{
    public class CategoryModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Category name is required.")]
        [MaxLength(100)]
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
