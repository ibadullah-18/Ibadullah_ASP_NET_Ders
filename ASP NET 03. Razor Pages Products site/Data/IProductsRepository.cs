using ASP_NET_03._Razor_Pages_Products_site.Models;

namespace ASP_NET_03._Razor_Pages_Products_site.Data;

public interface IProductsRepository
{
    public Product AddProduct(Product product);
    public Task<Product> GetProductByIdAsync(int id);
    public Task<IEnumerable<Product>> GetProductAsync();
}
