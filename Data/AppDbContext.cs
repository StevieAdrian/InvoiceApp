namespace InvoiceApp.Data
{
    using Microsoft.EntityFrameworkCore;
    using InvoiceApp.Models;

    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<LtCourierFee> LtCourierFees { get; set; }
        public DbSet<MsCourier> MsCouriers { get; set; }
        public DbSet<MsPayment> MsPayments { get; set; }
        public DbSet<MsProduct> MsProducts { get; set; }
        public DbSet<MsSales> MsSales { get; set; }
        public DbSet<TrInvoice> TrInvoice { get; set; }
        public DbSet<TrInvoiceDetail> TrInvoiceDetail { get; set; }
    }
}