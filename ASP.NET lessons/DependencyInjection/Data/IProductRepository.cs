using DependencyInjection.Models;
namespace DependencyInjection.Data;

public interface IProductRepository
{
    public Product AddProduct(Product product);
    public IEnumerable<Product> GetProducts();
}
