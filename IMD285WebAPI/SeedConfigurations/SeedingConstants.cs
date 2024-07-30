using System.Collections.ObjectModel;

namespace IMD285WebAPI.SeedConfigurations;

public static class SeedingConstants
{
    public const string MilkAndCheeseCategory = "Milk & Cheese";
    public const string ToiletriesCategory = "Toiletries";
    public const string MeatCategory = "Meat";
    public const string FruitAndVegetableCategory = "Fruit & Vegetable";

    public const string CottageProduct = "Cottage";
    public const string Milk3PercentProduct = "Milk 3 Percent";
    public const string SourCreamProduct = "Sour Cream";
    public const string SausageProduct = "Sausage";
    public const string CalvesProduct = "Calves";
    public const string SalmonProduct = "Salmon";
    public const string SoapProduct = "Soap";
    public const string ShampooProduct = "Shampoo";

    private static readonly Dictionary<string, Guid> _categoriesDefinitions = new()
    {
        { MilkAndCheeseCategory, Guid.Parse("BACA1D06-6C48-42E9-90C8-F4CE0C092934") },
        { ToiletriesCategory, Guid.Parse("515FD745-63B3-4E46-8BB4-4303CDB2A4EC") },
        { MeatCategory, Guid.Parse("4A82A87F-2903-42C1-95F1-ED8428B91A50") },
        { FruitAndVegetableCategory, Guid.Parse("358CC0EB-8CC9-460C-A790-B7911DDAFAE5") }
    };

    private static readonly Dictionary<string, Guid> _productsDefinitions = new()
    {
        { CottageProduct, Guid.Parse("51455015-F2A5-4087-8E81-1BA33C9EE4B6") },
        { Milk3PercentProduct, Guid.Parse("C00F7014-935D-42BB-B0A8-61ECC7FBED2F") },
        { SourCreamProduct, Guid.Parse("C6C21008-7B7F-41AF-969E-EFEA00794B0D") },
        { SausageProduct, Guid.Parse("532C8209-270D-41B4-A8AF-80BAF532823D") },
        { CalvesProduct, Guid.Parse("BF0E7EF7-3EA6-4E68-800D-37D5883F4ED0") },
        { SalmonProduct, Guid.Parse("99A51DF2-2F31-4637-92CC-4F6B9B51A761") },
        { SoapProduct, Guid.Parse("1A6BDFCC-D097-46E6-A87D-9077E39C6E3C") },
        { ShampooProduct, Guid.Parse("5888AAA9-D8CD-40C9-8332-A6571A75492D") }
    };

    public static readonly ReadOnlyDictionary<string, Guid> CategoriesDefinitions = new(_categoriesDefinitions);
    public static readonly ReadOnlyDictionary<string, Guid> ProductsDefinitions = new(_productsDefinitions);
}
