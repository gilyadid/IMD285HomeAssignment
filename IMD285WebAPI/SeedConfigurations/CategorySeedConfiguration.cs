using IMD285WebAPI.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IMD285WebAPI.SeedConfigurations;

public class CategorySeedConfiguration : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.HasData(
            new Category
            {
                Id = SeedingConstants.CategoriesDefinitions[SeedingConstants.MilkAndCheeseCategory],
                Name = SeedingConstants.MilkAndCheeseCategory,
                HebrewName = "חלב וגבינות"
            },
            new Category
            {
                Id = SeedingConstants.CategoriesDefinitions[SeedingConstants.ToiletriesCategory],
                Name = SeedingConstants.ToiletriesCategory,
                HebrewName = "טואלטיקה"
            },
            new Category
            {
                Id = SeedingConstants.CategoriesDefinitions[SeedingConstants.MeatCategory],
                Name = SeedingConstants.MeatCategory,
                HebrewName = "בשר"
            },
            new Category
            {
                Id = SeedingConstants.CategoriesDefinitions[SeedingConstants.FruitAndVegetableCategory],
                Name = SeedingConstants.FruitAndVegetableCategory,
                HebrewName = "ירקות ופירות"
            });
    }
}
