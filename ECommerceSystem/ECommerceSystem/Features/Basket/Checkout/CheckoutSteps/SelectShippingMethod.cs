using ECommerceSystem.Features.Basket.Checkout.Factories;
using ECommerceSystem.Features.Basket.Checkout.Models;
using ECommerceSystem.Features.Shared.Renderers;

namespace ECommerceSystem.Features.Basket.Checkout.CheckoutSteps;

public class SelectShippingMethod(ShippingMethodFactory shippingMethodFactory): IPipelineStep<CheckoutContext>
{
    public CheckoutContext? Run(CheckoutContext context)
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