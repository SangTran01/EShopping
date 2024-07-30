using System.Text.Json;
using Catalog.Core.Entities;
using MongoDB.Driver;

namespace Catalog.Infrastructure.Data;

public static class BrandContextSeed
{
    public static void SeedData(IMongoCollection<ProductBrand> collection)
    {
        bool checkBrands = collection.Find(b => true).Any();
        string path = Path.Combine("Data", "SeedData", "brands.json");
        if (!checkBrands)
        {
            var brandsData = File.ReadAllText(path);
            var brandsList = JsonSerializer.Deserialize<List<ProductBrand>>(brandsData);

            if (brandsList != null)
            {
                foreach (ProductBrand brand in brandsList)
                {
                    collection.InsertOneAsync(brand);
                }
            }
        }
    }
}