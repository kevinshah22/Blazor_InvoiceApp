using System.ComponentModel.DataAnnotations;

namespace BlazorApp.ViewModel
{
    public class ItemModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please enter name.")]
        public string Name { get; set; }
        public string? Description { get; set; }

        [Required(ErrorMessage = "Please select category.")]
        public int CategoryId { get; set; }

        public string? CategoryName { get; set; }        
    }
}
