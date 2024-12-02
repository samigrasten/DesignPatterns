using ECommerceSystem.DomainObjects;

namespace ECommerceSystem.Features.Basket.Checkout;

public class OrderRepository
{
    private readonly List<Order> _orders = [];

    public List<Order> GetOrders => _orders;

    public void SaveOrder(Order order)
    {
        _orders.Add(order);
    }
}