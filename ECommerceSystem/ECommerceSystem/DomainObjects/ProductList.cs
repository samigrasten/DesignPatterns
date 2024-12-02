using ECommerceSystem.Features.Shared;
using ECommerceSystem.Features.Shared.Renderers;

namespace ECommerceSystem.DomainObjects;

public class ProductList(List<Product> products)
{
    public int Count => products.Count;
    
    public void Render(IRenderer<Product> renderer)
        => renderer.Render(products);

    public void AddToBasket(int index, int quantity, OrderBasket orderBasket)
    {
        var selectedProduct = products[index-1];
        orderBasket.AddProduct(new OrderItem(selectedProduct, quantity));
        Screen.OutputSuccess($"{quantity} x {selectedProduct.Name} added to basket.");
    }
}