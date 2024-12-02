using ECommerceSystem.DomainObjects;
using ECommerceSystem.Features.Shared;
using ECommerceSystem.Features.Shared.Renderers;

namespace ECommerceSystem.Features.Basket.ViewBasket;

public class ViewBasketAction(OrderBasket orderBasket) : IAction
{
    public int Id => 3;
    public string Name => "View Basket";

    public void Handle()
    {
        if (orderBasket.IsEmpty)
        {
            Screen.OutputWarning("\nYour basket is empty.");
            return;
        }

        Screen.Output("\nYour Basket:");
        orderBasket.Render(new OrderBasketRenderer());
    }
}