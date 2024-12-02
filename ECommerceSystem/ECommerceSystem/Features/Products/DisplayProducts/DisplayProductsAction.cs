using ECommerceSystem.Features.Products.Shared.Renderers;
using ECommerceSystem.Features.Shared;
using ECommerceSystem.Features.Shared.Renderers;
using ECommerceSystem.Features.Shared.Repositories;

namespace ECommerceSystem.Features.Products.DisplayProducts;

public class DisplayProductsAction(ProductRepository productRepository) : IAction
{
    public int Id => 1;
    public string Name => "View Products";

    public void Handle()
    {
        Screen.Output("\nAvailable Products:");
        var products = productRepository.GetProducts();
        products.Render(new ProductRenderer());
    }
}