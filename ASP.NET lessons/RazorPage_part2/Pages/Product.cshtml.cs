using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPage_part2.Models;
using RazorPage_part2.Services;

namespace RazorPage_part2.Pages
{
    public class ProductModel : PageModel
    {
        private readonly ProductService _productService;
        public Product? Product { get; set; }

        public ProductModel(ProductService productService)
        {
            _productService = productService;
        }

        public async void OnGetAsync(int id)
        {
           Product = await _productService.GetProductById(id);
        }
    }
}
