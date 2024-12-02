using ECommerceSystem.Features.Basket.Checkout.Models;
using ECommerceSystem.Features.Basket.Checkout.Models.CheckoutPipeline;
using ECommerceSystem.Features.Basket.Checkout.Models.MaybeMonad;
using ECommerceSystem.Features.Shared.Renderers;

namespace ECommerceSystem.Features.Basket.Checkout.CheckoutSteps.SelectPaymentMethod;

public class SelectPaymentMethodStep(PaymentMethodFactory paymentMethodFactory) : IPipelineStep<CheckoutContext>
{
    public Maybe<CheckoutContext> Run(CheckoutContext context)
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