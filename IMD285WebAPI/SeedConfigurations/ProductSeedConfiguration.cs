using IMD285WebAPI.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IMD285WebAPI.SeedConfigurations;

public class ProductSeedConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.HasData(
            new Product
            {
                Id = SeedingConstants.ProductsDefinitions[SeedingConstants.CottageProduct],
                Name = SeedingConstants.CottageProduct,
                HebrewName = "קוטג",
                CategoryId = SeedingConstants.CategoriesDefinitions[SeedingConstants.MilkAndCheeseCategory]
            },
            new Product
            {
                Id = SeedingConstants.ProductsDefinitions[SeedingConstants.Milk3PercentProduct],
                Name = SeedingConstants.Milk3PercentProduct,
                HebrewName = "חלב 3%",
                CategoryId = SeedingConstants.CategoriesDefinitions[SeedingConstants.MilkAndCheeseCategory]
            },
            new Product
            {
                Id = SeedingConstants.ProductsDefinitions[SeedingConstants.SourCreamProduct],
                Name = SeedingConstants.SourCreamProduct,
                HebrewName = "שמנת חמוצה",
                CategoryId = SeedingConstants.CategoriesDefinitions[SeedingConstants.MilkAndCheeseCategory]
            },
            new Product
            {
                Id = SeedingConstants.ProductsDefinitions[SeedingConstants.SausageProduct],
                Name = SeedingConstants.SausageProduct,
                HebrewName = "נקניקיות",
                CategoryId = SeedingConstants.CategoriesDefinitions[SeedingConstants.MeatCategory]
            },
            new Product
            {
                Id = SeedingConstants.ProductsDefinitions[SeedingConstants.CalvesProduct],
                Name = SeedingConstants.CalvesProduct,
                HebrewName = "שוקיים",
                CategoryId = SeedingConstants.CategoriesDefinitions[SeedingConstants.MeatCategory]
            },
            new Product
            {
                Id = SeedingConstants.ProductsDefinitions[SeedingConstants.SalmonProduct],
                Name = SeedingConstants.SalmonProduct,
                HebrewName = "סלמון",
                CategoryId = SeedingConstants.CategoriesDefinitions[SeedingConstants.MeatCategory]
            },
            new Product
            {
                Id = SeedingConstants.ProductsDefinitions[SeedingConstants.SoapProduct],
                Name = SeedingConstants.SoapProduct,
                HebrewName = "סבון",
                CategoryId = SeedingConstants.CategoriesDefinitions[SeedingConstants.ToiletriesCategory]
            },
            new Product
            {
                Id = SeedingConstants.ProductsDefinitions[SeedingConstants.ShampooProduct],
                Name = SeedingConstants.ShampooProduct,
                HebrewName = "שמפו",
                CategoryId = SeedingConstants.CategoriesDefinitions[SeedingConstants.ToiletriesCategory]
            }
        );
    }
}
