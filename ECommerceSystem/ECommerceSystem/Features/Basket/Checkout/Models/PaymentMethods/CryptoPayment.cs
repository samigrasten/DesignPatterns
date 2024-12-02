using ECommerceSystem.Features.Shared.Renderers;

namespace ECommerceSystem.Features.Basket.Checkout.Models.PaymentMethods;

public class CryptoPayment : IPaymentMethod
{
    public int Id => 3;
    public bool ProcessPayment(decimal totalCost)
    {
        Screen.OutputHighlight("Processing payment with Crypto...");
        return true;
    }
}