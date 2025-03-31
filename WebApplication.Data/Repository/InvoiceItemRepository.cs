using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace BlazorApp.Data.Repository
{
    public class InvoiceItemRepository : IInvoiceItemRepository
    {
        private readonly BlazorContext _context;

        public InvoiceItemRepository(BlazorContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Add category 
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        public async Task<int> Create(List<Data.Models.InvoiceItem> invoiceItems)
        {
            try
            {
                _context.InvoicesItem.AddRange(invoiceItems);
                return await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            
        }

        public async Task<int> Delete(List<Data.Models.InvoiceItem> invoiceItems)
        {
            foreach (var invoiceitem in invoiceItems)
            {
                _context.Entry(invoiceitem).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
            }

            return await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Get list of category based on predicate
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public async Task<List<Data.Models.InvoiceItem>> GetInvoiceItems(Expression<Func<Data.Models.InvoiceItem, bool>> predicate)
        {
            return await _context.InvoicesItem.Where(predicate).Include(x => x.ItemData).ToListAsync();
        }
    }
}
