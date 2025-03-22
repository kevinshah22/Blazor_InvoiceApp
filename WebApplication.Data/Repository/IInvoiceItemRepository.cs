using System.Linq.Expressions;

namespace BlazorApp.Data.Repository
{
    public interface IInvoiceItemRepository
    {
        /// <summary>
        /// Add category 
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        Task<int> Create(List<Data.Models.InvoiceItem> invoiceItems);

        Task<int> Delete(List<Data.Models.InvoiceItem> invoiceItems);

        /// <summary>
        /// Get list of category based on predicate
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        Task<List<Data.Models.InvoiceItem>> GetInvoiceItems(Expression<Func<Data.Models.InvoiceItem, bool>> predicate);
    }
}
