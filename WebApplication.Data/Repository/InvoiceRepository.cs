using BlazorApp.Data.Models;
using BlazorApp.ViewModel;
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
            return await _context.Invoices.Where(predicate).Include(x => x.StoreData).AsNoTracking().FirstOrDefaultAsync();
        }

        /// <summary>
        /// Get list of category based on predicate
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public async Task<List<Data.Models.Invoice>> GetInvoices()
        {
            return await _context.Invoices.Include(x => x.StoreData).ToListAsync();
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

        /// <summary>
        /// Invoice data by year
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        public async Task<List<InvoiceChartModel>> GetInvocieDataByYear(int year)
        {
            return await (from i in _context.Invoices.AsNoTracking().Include(x => x.InvoiceItemData).Include(x => x.StoreData)
                          where i.InvoiceDate.Year == year
                          select new InvoiceChartModel
                          {
                              InvoiceDate = i.InvoiceDate,
                              InvoiceId = i.Id,
                              StoreId = i.StoreId,
                              StoreName = i.StoreData != null ? i.StoreData.Name : string.Empty,
                              Total = i.BillAmount
                          }

                    ).ToListAsync();
        }


        /// <summary>
        /// Invoice items by year.
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        public async Task<List<InvoiceItemChartModel>> GetInvoiceItemsByYear(int year)
        {
            return await (from i in _context.InvoicesItem.AsNoTracking().Include(x => x.InvoiceData).Include(x => x.ItemData)
                          where i.InvoiceData != null && i.InvoiceData.InvoiceDate.Year == year
                          select new InvoiceItemChartModel
                          {
                              InvoiceDate = i.InvoiceData.InvoiceDate,
                              ItemId = i.ItemId,
                              Price = i.Price,
                              Quantity = i.Quantity,
                              Total = i.Total,
                              ItemName = i.ItemData != null ? i.ItemData.Name : string.Empty,
                              CategoryId = i.ItemData != null ? i.ItemData.CategoryId : 0,
                              CategoryName = i.ItemData != null ? i.ItemData.CategoryData != null ? i.ItemData.CategoryData.Name : string.Empty : string.Empty
                          }).ToListAsync();
        }
    }
}
