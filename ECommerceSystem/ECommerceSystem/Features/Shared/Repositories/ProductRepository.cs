using ECommerceSystem.DomainObjects;

namespace ECommerceSystem.Features.Shared.Repositories;

public class ProductRepository
{
    private readonly List<Product> _products = [];

    public ProductRepository()
    {
        SeedProducts();
    }
    
    private void SeedProducts()
    {
        _products.Add(new Product("Laptop", "Electronics", 1000.00m));
        _products.Add(new Product("Headphones", "Electronics", 150.00m));
        _products.Add(new Product("Shirt", "Clothing", 30.00m));
        _products.Add(new Product("Shoes", "Clothing", 70.00m));
        _products.Add(new Product("Novel", "Books", 20.00m));
        _products.Add(new Product("Cookbook", "Books", 25.00m));
    }

    public ProductList GetProducts() => new (_products);
}