using ASP_NET_03._Razor_Pages_Products_site.Models;
using Bogus;

namespace ASP_NET_03._Razor_Pages_Products_site.Data;

public class InMemoryRepository : IProductsRepository
{
    private readonly List<Product> _products = new();
    public InMemoryRepository()
    {
        var faker = new Faker<Product>()
            .RuleFor(p => p.Id, f => f.IndexFaker + 1)
            .RuleFor(p => p.Name, f => f.Commerce.ProductName())
            .RuleFor(p => p.Description, f => f.Commerce.ProductDescription())
            .RuleFor(p => p.Count, f => (uint)f.Random.Int(0, 100))
            .RuleFor(p => p.Price, f => decimal.Parse(f.Commerce.Price(1, 1000)))
            .RuleFor(p => p.IsAviable, true);

        _products.AddRange(faker.GenerateBetween(20,20));
    }
    public Product AddProduct(Product product)
    {
        _products.Add(product);
        return product;
    }
    

    public Task<Product>  GetProductByIdAsync(int id)
        => Task.FromResult(_products.FirstOrDefault(p => p.Id == id))!;
    public Task<IEnumerable<Product>> GetProductAsync()
        => Task.FromResult(_products.AsEnumerable());
}
