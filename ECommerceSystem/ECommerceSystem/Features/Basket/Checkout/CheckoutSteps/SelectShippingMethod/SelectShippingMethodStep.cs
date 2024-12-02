using ECommerceSystem.Features.Basket.Checkout.Models;
using ECommerceSystem.Features.Basket.Checkout.Models.CheckoutPipeline;
using ECommerceSystem.Features.Basket.Checkout.Models.MaybeMonad;
using ECommerceSystem.Features.Shared.Renderers;

namespace ECommerceSystem.Features.Basket.Checkout.CheckoutSteps.SelectShippingMethod;

public class SelectShippingMethodStep(ShippingMethodFactory shippingMethodFactory): IPipelineStep<CheckoutContext>
{
    public Maybe<CheckoutContext> Run(CheckoutContext context)
    {
        var shippingMethod = Screen.GetChoice(
            "Choose a shipping method:",
            ["Standard (Free)", "Express (15.00 €)", "International (25.00 €)"],
            "Select shipping method:");
        
        return context with
        {
            ShippingMethod = shippingMethodFactory.CreateFrom(shippingMethod)
        };
    }
}