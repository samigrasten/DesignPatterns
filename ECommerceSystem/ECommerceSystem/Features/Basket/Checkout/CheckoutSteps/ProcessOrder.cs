using ECommerceSystem.DomainObjects;
using ECommerceSystem.Features.Basket.Checkout.Exceptions;
using ECommerceSystem.Features.Basket.Checkout.Models;

namespace ECommerceSystem.Features.Basket.Checkout.CheckoutSteps;

public class ProcessOrder(OrderRepository orderRepository) : IPipelineStep<CheckoutContext>
{
    private readonly HashSet<IObserver<Order>> _observers = [];
    
    public CheckoutContext? Run(CheckoutContext context)
    {
        var order = context.OrderBasket.ToOrder(context.PaymentMethod, context.ShippingMethod);
        orderRepository.SaveOrder(order);
        if (!order.ProcessPayment())
        {
            SendFailedNotification(new PaymentProcessingError(order, "Payment failed. Order not placed."));
            return null;
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