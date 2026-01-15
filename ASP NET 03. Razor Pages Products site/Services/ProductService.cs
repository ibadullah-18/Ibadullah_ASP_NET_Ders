using ASP_NET_03._Razor_Pages_Products_site.Data;
using ASP_NET_03._Razor_Pages_Products_site.Models;
using Bogus;

namespace ASP_NET_03._Razor_Pages_Products_site.Services;

public class ProductService
{
    private readonly IProductsRepository _repository;

    public ProductService(IProductsRepository repository)
    {
        _repository = repository;
    }

    public Product GetProduct(Product product)
    {
        var faker = new Faker<Product>().RuleFor(p => p.Id, f => f.Random.Int(1));
        product.Id = faker.Generate().Id;
        if(product.Count > 0)
        {
            product.IsAviable = true;
        }
        _repository.AddProduct(product);
        return product;
    }
    public async Task<Product> GetProductByIdAsync(int id)
        =>await _repository.GetProductByIdAsync(id);

    public async Task<IEnumerable<Product>> GetProductAsync()
        =>await _repository.GetProductAsync();

    internal void AddProduct(Product product)
    {

        _repository.AddProduct(product);
    }

    internal Product GetById(int id)
    {
        return _repository.GetProductByIdAsync(id).Result;
    }
}
