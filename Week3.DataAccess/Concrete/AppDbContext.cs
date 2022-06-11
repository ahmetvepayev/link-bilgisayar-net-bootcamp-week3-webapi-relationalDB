using Microsoft.EntityFrameworkCore;
using Week3.Entities.Concrete;

namespace Week3.DataAccess.Concrete;

public class AppDbContext : DbContext
{
    public DbSet<Category> Categories { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<ProductFeature> ProductFeatures { get; set; }

    // For custom model query using a stored procedure
    public DbSet<ProductFullModel> ProductFullModels { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Indicate to EfCore that this is just a model with no physical representation in the database
        modelBuilder.Entity<ProductFullModel>().HasNoKey();

        base.OnModelCreating(modelBuilder);
    }
}