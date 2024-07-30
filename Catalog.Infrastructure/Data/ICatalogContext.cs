using Catalog.Core.Entities;
using MongoDB.Driver;

namespace Catalog.Infrastructure.Data;

public interface ICatalogContext
{
    IMongoCollection<Product> Products { get; set; }
    IMongoCollection<ProductBrand> Brands { get; set; }
    IMongoCollection<ProductType> Types { get; set; }
}