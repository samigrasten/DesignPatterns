using ECommerceSystem.Features.Basket.Checkout.Models;
using ECommerceSystem.Features.Basket.Checkout.Models.CheckoutPipeline;
using ECommerceSystem.Features.Basket.Checkout.Models.MaybeMonad;
using ECommerceSystem.Features.Shared.Renderers;

namespace ECommerceSystem.Features.Basket.Checkout.CheckoutSteps;

public class CheckBasketHasItemsStep : IPipelineStep<CheckoutContext>
{
    public Maybe<CheckoutContext> Run(CheckoutContext context)
    {
        if (context.OrderBasket.IsEmpty)
        {
            Screen.OutputWarning("\nYour basket is empty. Add items before finalizing the order.");
            return Maybe<CheckoutContext>.None;
        }

        context.OrderBasket.Render(new OrderBasketRenderer());
        return context;
    }
}