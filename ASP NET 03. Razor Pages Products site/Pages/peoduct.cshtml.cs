    using ASP_NET_03._Razor_Pages_Products_site.Models;
    using ASP_NET_03._Razor_Pages_Products_site.Services;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.RazorPages;
    using System.Threading.Tasks;

    namespace ASP_NET_03._Razor_Pages_Products_site.Pages
    {
        public class productModel : PageModel   
        {
            private readonly ProductService _Service;

            public productModel(ProductService service)
            {
                _Service = service;
            }

            public Product Product { get; set; }

            public async Task OnGet(int id)
            {
                Product = await _Service.GetProductByIdAsync(id);
            }
        }
    }

