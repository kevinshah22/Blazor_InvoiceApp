using Microsoft.EntityFrameworkCore;
using BlazorApp.Data.Models;

namespace BlazorApp.Data
{
    public class BlazorContext : DbContext
    {
        public BlazorContext() { }

        public BlazorContext(DbContextOptions<BlazorContext> options) : base(options)
        {

        }

        public virtual DbSet<Item> Items { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Store> Stores { get; set; }
        public virtual DbSet<Invoice> Invoices { get; set; }
        public virtual DbSet<InvoiceItem> InvoicesItem { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}
