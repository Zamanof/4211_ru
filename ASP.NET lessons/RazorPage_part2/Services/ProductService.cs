using Bogus;
using RazorPage_part2.Models;

namespace RazorPage_part2.Services;

public class ProductService
{
    private readonly List<Product> _products = new();

    public ProductService()
    {
        var faker = new Faker<Product>()
            .RuleFor(p=> p.Id, f=>f.Random.Int(1))
            .RuleFor(p=>p.Name, f=>f.Commerce.Product())
            .RuleFor(p=>p.Description, f=>f.Commerce.ProductDescription())
            .RuleFor(p =>p.Count, f=>f.Random.UInt(0))
            .RuleFor(p=>p.Price, f=>f.Random.Decimal(1));
        _products.AddRange(faker.GenerateBetween(30, 30));
    }
    public Task<IEnumerable<Product>> GetProductsAsync()
    {
        return Task.FromResult(_products.AsEnumerable());
    }

    public Task<Product?> GetProductById(int id)
    {
        return Task.FromResult(_products.FirstOrDefault(p => p.Id == id));
    }

   public Product AddProduct(Product product)
    {
        var faker = new Faker<Product>()
            .RuleFor(p => p.Id, f => f.Random.Int(1));
        product.Id = faker.Generate().Id;
        if (product.Count > 0) product.Available = true;
        _products.Add(product);
        return product;
    }
}
