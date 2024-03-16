using CQRS_MediatorR_Library.Models;
using Microsoft.EntityFrameworkCore;

namespace CQRS_MediatorR_Library.DbData;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
    }

    public DbSet<GroceryModel> Groceries { get; set; }
    public DbSet<ShoppingBag> ShoppingBags { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<GroceryModel>()
            .HasOne(g => g.ShoppingBag)
            .WithMany(sb => sb.GroceryModels)
            .HasForeignKey(g => g.ShoppingBagId);

        modelBuilder.Entity<ShoppingBag>()
            .HasMany(sb => sb.GroceryModels)
            .WithOne(g => g.ShoppingBag)
            .HasForeignKey(g => g.ShoppingBagId);
    }
}
