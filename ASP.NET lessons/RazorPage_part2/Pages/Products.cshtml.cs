using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPage_part2.Models;
using RazorPage_part2.Services;

namespace RazorPage_part2.Pages
{
    public class ProductsModel : PageModel
    {
        private readonly ProductService _productService;
        public IEnumerable<Product> Products { get; set; } 
            = Enumerable.Empty<Product>();

        public ProductsModel(ProductService productService)
        {
            _productService = productService;
        }

        public async void OnGet()
        {
            Products = await _productService.GetProductsAsync();
        }
    }
}
