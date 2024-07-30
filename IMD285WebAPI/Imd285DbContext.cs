using IMD285WebAPI.Entities;
using IMD285WebAPI.SeedConfigurations;
using Microsoft.EntityFrameworkCore;

namespace IMD285WebAPI;

public class Imd285DbContext : DbContext
{
    public Imd285DbContext()
    { }

    public Imd285DbContext(DbContextOptions<Imd285DbContext> options)
        : base(options)
    { }

    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Category>().ToTable("Categories");
        modelBuilder.Entity<Product>().ToTable("Products");

        modelBuilder.ApplyConfiguration(new CategorySeedConfiguration());
        modelBuilder.ApplyConfiguration(new ProductSeedConfiguration());
    }
}
