namespace BlazorApp.ViewModel
{
    /// <summary>
    /// Invoice model for chart
    /// </summary>
    public class InvoiceChartModel
    {
        
        public decimal Total { get; set; }
        public int InvoiceId { get; set; }
        public int StoreId { get; set; }
        public string StoreName { get; set; }
        public DateTime InvoiceDate { get; set; }

        //public List<InvoiceItemChartModel> InvoiceItems { get; set; }
    }
}
