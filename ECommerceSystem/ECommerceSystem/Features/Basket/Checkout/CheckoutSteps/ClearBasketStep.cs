using ECommerceSystem.DomainObjects;
using ECommerceSystem.Features.Basket.Checkout.Models;
using ECommerceSystem.Features.Basket.Checkout.Models.CheckoutPipeline;
using ECommerceSystem.Features.Basket.Checkout.Models.MaybeMonad;

namespace ECommerceSystem.Features.Basket.Checkout.CheckoutSteps;

public class ClearBasketStep : IPipelineStep<CheckoutContext>
{
    public Maybe<CheckoutContext> Run(CheckoutContext context)
    {
        context.OrderBasket.Clear();
        return context;
    }
}