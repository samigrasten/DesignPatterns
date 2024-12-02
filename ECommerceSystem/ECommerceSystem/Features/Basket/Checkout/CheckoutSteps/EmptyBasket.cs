using ECommerceSystem.DomainObjects;
using ECommerceSystem.Features.Basket.Checkout.Models;

namespace ECommerceSystem.Features.Basket.Checkout.CheckoutSteps;

public class EmptyBasket : IPipelineStep<CheckoutContext>
{
    public CheckoutContext? Run(CheckoutContext context)
    {
        context.OrderBasket.Clear();
        return context;
    }
}