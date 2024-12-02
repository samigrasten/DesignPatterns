using ECommerceSystem.DomainObjects;
using ECommerceSystem.Features.Shared;
using ECommerceSystem.Features.Shared.Renderers;

namespace ECommerceSystem.Features.Basket.Checkout.PostProcessors.CreateOrderConfirmation;

public sealed class OrderConfirmationRenderer : IRenderer<Order, OrderItem>
{
    public void Render(Order order, IEnumerable<OrderItem> items)
    {
        Screen.Output($"\nOrder Confirmation:");
        foreach (var item in items)
        {
            Screen.Output($"{item.Quantity} x {item.Product.Name} - {item.Product.Price} € each");
        }
        Screen.Output($"Shipping: {order.ShippingMethodName} ({order.ShippingCost} €)");
        Screen.OutputHighlight($"Total Cost: {order.TotalCost} €");
    }
}