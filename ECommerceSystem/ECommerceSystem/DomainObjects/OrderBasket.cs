using System.Collections;
using ECommerceSystem.Features.Basket.Checkout.Models.PaymentMethods;
using ECommerceSystem.Features.Basket.Checkout.Models.ShippingMethods;
using ECommerceSystem.Features.Shared;
using ECommerceSystem.Features.Shared.Renderers;

namespace ECommerceSystem.DomainObjects;

public class OrderBasket
{
    private readonly List<OrderItem> _items = [];
    
    public bool IsEmpty => _items.Count == 0;

    public void AddProduct(OrderItem orderItem)
        => _items.Add(orderItem);

    public void Render(IRenderer<OrderItem> renderer)
        => renderer.Render(_items);
    
    public Order ToOrder(IPaymentMethod paymentMethod, IShippingMethod shippingMethod)
    {
        var shippingCost = shippingMethod.GetShippingCost();
        var totalAmount = _items.Sum(item => item.Product.Price * item.Quantity);
        Screen.Output($"Shipping cost: €{shippingCost}");
        
        return new Order
        {
            Items = _items,
            PaymentMethod = paymentMethod,
            ShippingMethod = shippingMethod,
            ShippingCost = shippingCost,
            TotalCost = totalAmount + shippingCost
        };
    }
    
    public void Clear()
    {
        _items.Clear();
    }
}