using System.ComponentModel.DataAnnotations;

namespace BlazorApp.ViewModel
{
    /// <summary>
    /// Invoice item Model
    /// </summary>
    public class InvoiceItemModel
    {
        public int Id { get; set; }
        public int InvoiceId { get; set; }
        [Required]
        public int ItemId { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public int Quantity { get; set; }
        public decimal Total { get; set; }
    }
}
