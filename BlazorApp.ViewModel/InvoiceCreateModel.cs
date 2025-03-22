namespace BlazorApp.ViewModel
{
    public class InvoiceCreateModel
    {
        public InvoiceModel Invoice { get; set; }
        public List<InvoiceItemModel> InvoiceItems { get; set; }
    }
}
