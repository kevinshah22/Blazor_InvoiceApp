using System.ComponentModel.DataAnnotations;

namespace BlazorApp.ViewModel
{
    public class InvoiceModel
    {
        public int Id { get; set; }
        [Required]
        public DateTime InvoiceDate { get; set; }
        [Required]
        public int StoreId { get; set; }
        [Required]
        public decimal BillAmount { get; set; }
        
        public string? Description { get; set; }

        public string? StoreName { get; set; }
                
        public List<StoreModel>? Stores { get; set; }

        public InvoiceModel()
        {
            this.InvoiceDate = DateTime.Now;
            Stores = new();
        }
    }
}
