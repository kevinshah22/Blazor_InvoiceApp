using BlazorApp.ViewModel;

namespace BlazorApp.Services
{
    public interface IInvoiceService
    {
        /// <summary>
        /// Add category 
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        Task<int> Create(InvoiceCreateModel invoice);

        /// <summary>
        /// Add category 
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        Task<int> Update(InvoiceCreateModel invoice);

        /// <summary>
        /// Get category based on predicate
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        Task<InvoiceModel> GetInvoice(int invoiceId);

        /// <summary>
        /// Get list of category based on predicate
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        Task<List<InvoiceItemModel>> GetInvoiceItems(int invoiceId);

        /// <summary>
        /// List of invoices
        /// </summary>
        /// <returns></returns>
        Task<List<InvoiceModel>> GetInvoices();
    }
}
