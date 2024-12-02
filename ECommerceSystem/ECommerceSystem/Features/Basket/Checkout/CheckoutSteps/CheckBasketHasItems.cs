using ECommerceSystem.Features.Basket.Checkout.Models;
using ECommerceSystem.Features.Shared.Renderers;

namespace ECommerceSystem.Features.Basket.Checkout.CheckoutSteps;

public class CheckBasketHasItems : IPipelineStep<CheckoutContext>
{
    public CheckoutContext? Run(CheckoutContext context)
    {
        if (context.OrderBasket.IsEmpty)
        {
            Screen.OutputWarning("\nYour basket is empty. Add items before finalizing the order.");
            return null;
        }

        context.OrderBasket.Render(new OrderBasketRenderer());
        return context;
    }
}