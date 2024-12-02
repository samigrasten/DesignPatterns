using ECommerceSystem.Features.Shared;
using ECommerceSystem.Features.Shared.Renderers;

namespace ECommerceSystem.Features.Basket.Checkout.PaymentMethods;

public class CreditCardPayment : IPaymentMethod
{
    public int Id => 1;
    
    public bool ProcessPayment(decimal totalCost)
    {
        Screen.OutputHighlight("Processing payment with Credit card...");
        return true;
    }
}