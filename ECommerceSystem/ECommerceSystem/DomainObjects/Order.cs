using ECommerceSystem.Features.Basket.Checkout.Models.PaymentMethods;
using ECommerceSystem.Features.Basket.Checkout.Models.ShippingMethods;
using ECommerceSystem.Features.Shared;
using ECommerceSystem.Features.Shared.Renderers;

namespace ECommerceSystem.DomainObjects;

public class Order
{
    public required List<OrderItem> Items { get; init; }
    public required IPaymentMethod PaymentMethod { get; init; }
    public required IShippingMethod ShippingMethod { get; init; }
    public required decimal ShippingCost { get; init; }
    public required decimal TotalCost { get; init; }

    public string ShippingMethodName => ShippingMethod.GetMethodName();

    public bool ProcessPayment()
    {
        var cost = TotalCost + ShippingCost;
        var isSuccess = PaymentMethod.ProcessPayment(cost);
        if (isSuccess) Screen.OutputSuccess($"Payment of {cost} € was successful!");
        return isSuccess;
    }

    public void RenderOrder(IRenderer<Order, OrderItem> renderer)
        => renderer.Render(this, Items);
}