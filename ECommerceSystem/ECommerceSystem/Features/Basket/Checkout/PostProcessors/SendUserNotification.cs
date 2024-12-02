using ECommerceSystem.DomainObjects;
using ECommerceSystem.Features.Basket.Checkout.Exceptions;
using ECommerceSystem.Features.Shared;
using ECommerceSystem.Features.Shared.Renderers;

namespace ECommerceSystem.Features.Basket.Checkout.PostProcessors;

public class SendUserNotification : IObserver<Order>
{
    public void OnCompleted()
    {
    }

    public void OnError(Exception error)
    {
        if (error is PaymentProcessingError paymentError)
        {
            Screen.OutputError(paymentError.Reason);
        }
    }

    public void OnNext(Order value)
    {
        Screen.OutputSuccess("Order placed successfully!");
    }
}
