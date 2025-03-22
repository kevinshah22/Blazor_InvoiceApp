using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace BlazorApp.Data.Repository
{
    public class InvoiceRepository : IInvoiceRepository
    {
        private readonly BlazorContext _context;

        public InvoiceRepository(BlazorContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Add category 
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        public async Task<int> Create(Data.Models.Invoice invoice)
        {
            _context.Invoices.Add(invoice);
            return await _context.SaveChangesAsync();
        }

        /// <summary>
        /// update category
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        public async Task<int> Update(Data.Models.Invoice invoice)
        {
            _context.Entry(invoice).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            return await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Get category based on predicate
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public async Task<Data.Models.Invoice> GetInvoice(Expression<Func<Data.Models.Invoice, bool>> predicate)
        {
            return await _context.Invoices.Where(predicate).Include(x=> x.StoreData).FirstOrDefaultAsync();
        }

        /// <summary>
        /// Get list of category based on predicate
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public async Task<List<Data.Models.Invoice>> GetInvoices()
        {
            return await _context.Invoices.ToListAsync();
        }

        /// <summary>
        /// Get list of category based on predicate
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public async Task<List<Data.Models.Invoice>> GetInvoices(Expression<Func<Data.Models.Invoice, bool>> predicate)
        {
            return await _context.Invoices.Where(predicate).ToListAsync();
        }
    }
}
