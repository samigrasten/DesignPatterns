using ECommerceSystem.DomainObjects;

namespace ECommerceSystem.Features.Shared.Renderers;

public class OrderBasketRenderer : IRenderer<OrderItem>
{
    public void Render(IEnumerable<OrderItem> items)
    {
        var total = 0.0m;
        foreach (var item in items)
        {
            var itemTotal = item.Product.Price * item.Quantity;
            total += itemTotal;
            Screen.Output($"{item.Quantity} x {item.Product.Name} - {item.Product.Price} € each (Total: {itemTotal}€)");
        }
        Screen.OutputHighlight($"Total: {total} €");
    }
}