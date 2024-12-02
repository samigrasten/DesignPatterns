using ECommerceSystem.DomainObjects;
using ECommerceSystem.Features.Products.Shared.Renderers;
using ECommerceSystem.Features.Shared;
using ECommerceSystem.Features.Shared.Renderers;
using ECommerceSystem.Features.Shared.Repositories;

namespace ECommerceSystem.Features.Products.AddProductToBasket;

public class AddProductToBasketAction(ProductRepository productRepository, OrderBasket orderBasket) : IAction
{
    public int Id => 2;
    public string Name => "Add Product to Basket";

    public void Handle()
    {
        var products = productRepository.GetProducts();
        Screen.Output();
        products.Render(new ProductRenderer());
        var productIndex = Screen.GetInteger(
            "Select a product by number:", 
            0, 
            products.Count, 
            "Invalid product selection.");
        var quantity = Screen.GetInteger(
            "Enter quantity:", 
            1, 
            errorMessage: "Quantity must be at least 1.");

        products.AddToBasket(productIndex, quantity, orderBasket);
    }
}