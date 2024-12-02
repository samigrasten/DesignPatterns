using ECommerceSystem.DomainObjects;

namespace ECommerceSystem.Features.Basket.Checkout.PostProcessors.CreateOrderConfirmation;

public class CreateOrderConfirmation : IObserver<Order>
{
    public void OnCompleted()
    {
    }

    public void OnError(Exception error)
    {
    }

    public void OnNext(Order order)
    {
        order.RenderOrder(new OrderConfirmationRenderer());
    }
}