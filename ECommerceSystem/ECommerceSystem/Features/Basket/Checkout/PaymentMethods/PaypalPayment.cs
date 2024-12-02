using ECommerceSystem.Features.Shared;
using ECommerceSystem.Features.Shared.Renderers;

namespace ECommerceSystem.Features.Basket.Checkout.PaymentMethods;

public class PaypalPayment : IPaymentMethod
{
    public int Id => 2;
    
    public bool ProcessPayment(decimal totalCost)
    {
        Screen.OutputHighlight("Processing payment with Paypal...");
        return true;
    }
}