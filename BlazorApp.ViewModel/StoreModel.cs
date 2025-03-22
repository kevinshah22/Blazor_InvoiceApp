using System.ComponentModel.DataAnnotations;

namespace BlazorApp.ViewModel
{
    public class StoreModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Store name is required.")]
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
