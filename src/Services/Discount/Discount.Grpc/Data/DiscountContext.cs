using Discount.Grpc.Models;
using Microsoft.EntityFrameworkCore;

namespace Discount.Grpc.Data;

public class DiscountContext : DbContext
{
    public DbSet<Coupon> Coupons { get; set; } = default!;
    public DiscountContext(DbContextOptions<DiscountContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Coupon>().HasData(
            new Coupon { Id = 1, ProductName = "Moto Edge 40", Description = "Moto description", Amount = 30000 },
            new Coupon { Id = 2, ProductName = "Moto Edge 30", Description = "Moto 30 description", Amount = 20000 }
            );
    }
}



 

