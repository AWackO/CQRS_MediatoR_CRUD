using CQRS_MediatorR_Library.Models;
using Microsoft.EntityFrameworkCore;

namespace CQRS_MediatorR_Library.DbData;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
    }

    public DbSet<GroceryModel> Groceries { get; set; }
}
