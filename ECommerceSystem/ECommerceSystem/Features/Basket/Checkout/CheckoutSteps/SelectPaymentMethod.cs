using ECommerceSystem.Features.Basket.Checkout.Factories;
using ECommerceSystem.Features.Basket.Checkout.Models;
using ECommerceSystem.Features.Shared.Renderers;

namespace ECommerceSystem.Features.Basket.Checkout.CheckoutSteps;

public class SelectPaymentMethod(PaymentMethodFactory paymentMethodFactory) : IPipelineStep<CheckoutContext>
{
    public CheckoutContext? Run(CheckoutContext context)
    {
        Screen.Output();
        var paymentMethod =  Screen.GetChoice(
            "Choose a payment method:",
            ["Credit Card", "PayPal", "Crypto"],
            "Select payment method:");
        
        return context with
        {
            PaymentMethod = paymentMethodFactory.CreateFrom(paymentMethod)
        };
    }
}