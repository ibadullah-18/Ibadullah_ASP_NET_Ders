using ASP_NET_03._Razor_Pages_Products_site.Models;
using ASP_NET_03._Razor_Pages_Products_site.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ASP_NET_03._Razor_Pages_Products_site.Pages;

public class IndexModel : PageModel
{
    private readonly ProductService _service;
    public IndexModel(ProductService service)
    {
        _service = service;
    }

    public void OnPost(string name, string description, decimal price, uint count) 
    {
        var product = new Product
        {
            Name = name,
            Description = description,
            Price = price,
            Count = count
        };
        _service.AddProduct(product);
    }
}
