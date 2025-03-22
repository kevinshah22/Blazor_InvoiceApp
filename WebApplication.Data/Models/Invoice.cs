using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlazorApp.Data.Models
{
    [Table("Invoices")]
    public class Invoice
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public DateTime InvoiceDate { get; set; }

        [Required]
        public int StoreId { get; set; }
        [Required]
        public decimal BillAmount { get; set; }
        [Required]
        public string Description { get; set; }

        public virtual Store? StoreData { get; set; }
    }
}
