using Microsoft.EntityFrameworkCore;
using WarehouseSystem.Api.Models;
namespace WarehouseSystem.Api.Data
{
    public class WarehouseDbContext : DbContext
    {
        public WarehouseDbContext(DbContextOptions<WarehouseDbContext> options)
       : base(options)
        {
        }

        public DbSet<Warehouse> Warehouses => Set<Warehouse>();
        public DbSet<Bin> Bins => Set<Bin>();
        public DbSet<Product> Products => Set<Product>();
        public DbSet<InventoryRecord> InventoryRecords => Set<InventoryRecord>();
        public DbSet<Order> Orders => Set<Order>();
        public DbSet<OrderLine> OrderLines => Set<OrderLine>();
        public DbSet<StockMovement> StockMovements => Set<StockMovement>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Prevent duplicate SKUs
            modelBuilder.Entity<Product>()
                .HasIndex(p => p.SKU)
                .IsUnique();

            // Prevent duplicate order numbers
            modelBuilder.Entity<Order>()
                .HasIndex(o => o.OrderNumber)
                .IsUnique();

            // A product can only have one inventory record per bin
            modelBuilder.Entity<InventoryRecord>()
                .HasIndex(ir => new { ir.ProductId, ir.BinId })
                .IsUnique();
        }

    }
}
