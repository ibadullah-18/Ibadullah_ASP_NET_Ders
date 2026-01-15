using ASP_NET_03._Razor_Pages_Products_site.Models;
using ASP_NET_03._Razor_Pages_Products_site.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ASP_NET_03._Razor_Pages_Products_site.Pages
{
    public class ProductsModel : PageModel
    {
        private readonly ProductService _service;
        public ProductsModel(ProductService service)
        {
            _service = service;
        }
        public IEnumerable<Product> Products { get; set; } = Enumerable.Empty<Product>();
        public async Task OnGet()
        {
            Products = await _service.GetProductAsync();
        }
    }
}

