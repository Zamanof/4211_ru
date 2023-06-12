using DependencyInjection.Data;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DependencyInjection.Pages
{
    public class IndexModel : PageModel
    {

        private readonly IProductRepository _repository;
        public IndexModel(IProductRepository repository)
        {
            _repository = repository;
        }

        public void OnGet()
        {
            var products = _repository.GetProducts();
            ViewData["Products"] = products;
        }

    }
}