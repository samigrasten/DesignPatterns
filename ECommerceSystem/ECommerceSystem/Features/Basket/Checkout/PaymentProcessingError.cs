using ECommerceSystem.DomainObjects;

namespace ECommerceSystem.Features.Basket.Checkout;

public class PaymentProcessingError(Order order, string reason) : Exception
{
    public Order Order => order;
    public string Reason => reason;
}

