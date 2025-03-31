namespace BlazorApp.ViewModel
{
    /// <summary>
    /// Invoice item Model for chart
    /// </summary>
    public class InvoiceItemChartModel
    {
        public int Quantity { get; set; }
        public string ItemName { get; set; }
        public int ItemId { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public decimal Price { get; set; }
    }
}
