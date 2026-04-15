using EcoRouteLogisticAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace EcoRouteLogisticAPI.Infrastructure.Data
{
    public class EcoRouteDbContext : DbContext
    {
        public EcoRouteDbContext(DbContextOptions op) : base(op)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configuration of owned entities
            modelBuilder.Entity<Order>(builder =>
            {
                builder.OwnsOne(o => o.DeliveryAdress);

                builder.OwnsOne(o => o.LastLocation);
            });

            // Configuration of relationships and constraints
            modelBuilder.Entity<Order>()
                .HasOne(o => o.Driver)
                .WithMany(d => d.Orders)
                .HasForeignKey(o => o.DriverId)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<DeliveryHistory>()
                .HasOne(h => h.Order)
                .WithMany(o => o.DeliveryHistories)
                .OnDelete(DeleteBehavior.Cascade);
        }
        

        public DbSet<Driver> Drivers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<DeliveryHistory> DeliveryHistories { get; set; }
    }
}
