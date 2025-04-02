using BlazorApp.ViewModel;
using System.Linq.Expressions;

namespace BlazorApp.Data.Repository
{
    public interface IInvoiceRepository
    {
        /// <summary>
        /// Add category 
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        Task<int> Create(Data.Models.Invoice invoice);

        /// <summary>
        /// update category
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        Task<int> Update(Data.Models.Invoice invoice);

        /// <summary>
        /// Get category based on predicate
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        Task<Data.Models.Invoice> GetInvoice(Expression<Func<Data.Models.Invoice, bool>> predicate);

        /// <summary>
        /// Get list of category based on predicate
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        Task<List<Data.Models.Invoice>> GetInvoices();

        /// <summary>
        /// Get list of category based on predicate
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        Task<List<Data.Models.Invoice>> GetInvoices(Expression<Func<Data.Models.Invoice, bool>> predicate);

        /// <summary>
        /// Get Current year invoices
        /// </summary>
        /// <returns></returns>
        Task<List<InvoiceChartModel>> GetInvocieDataByYear(int year);

        /// <summary>
        /// Invoice items by year.
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        Task<List<InvoiceItemChartModel>> GetInvoiceItemsByYear(int year);
    }
}
