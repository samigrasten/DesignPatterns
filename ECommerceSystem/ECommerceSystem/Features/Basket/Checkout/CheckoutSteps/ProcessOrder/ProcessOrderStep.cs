using ECommerceSystem.DomainObjects;
using ECommerceSystem.Features.Basket.Checkout.Models;
using ECommerceSystem.Features.Basket.Checkout.Models.CheckoutPipeline;
using ECommerceSystem.Features.Basket.Checkout.Models.MaybeMonad;

namespace ECommerceSystem.Features.Basket.Checkout.CheckoutSteps.ProcessOrder;

public class ProcessOrderStep(OrderRepository orderRepository) : IPipelineStep<CheckoutContext>
{
    private readonly HashSet<IObserver<Order>> _observers = [];
    
    public Maybe<CheckoutContext> Run(CheckoutContext context) 
    {
        var order = context.OrderBasket.ToOrder(context.PaymentMethod, context.ShippingMethod);
        orderRepository.SaveOrder(order);
        if (!order.ProcessPayment())
        {
            SendFailedNotification(new PaymentProcessingError(order, "Payment failed. Order not placed."));
            return Maybe<CheckoutContext>.None;
        }
        
        SendOrderProcessedNotification(order);
        return context;
    }
    
    private void SendOrderProcessedNotification(Order order)
    {
        foreach (var observer in _observers) observer.OnNext(order);
    }

    private void SendFailedNotification(Exception exception)
    {
        foreach (var observer in _observers) observer.OnError(exception);
    }
    
    public Unsubscriber<Order> Subscribe(IObserver<Order> observer)
    {
        _observers.Add(observer);
        return new Unsubscriber<Order>(_observers, observer);
    }
}