using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPage_part2.Models;
using RazorPage_part2.Services;

namespace RazorPage_part2.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ProductService _service;

        public IndexModel(ProductService service)
        {
            _service = service;
        }

        public void OnPost(Product product)
        {
            _service.AddProduct(product);
        }
    }
}