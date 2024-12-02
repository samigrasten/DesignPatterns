using ECommerceSystem.Features.Basket.Checkout.CheckoutSteps;
using ECommerceSystem.Features.Basket.Checkout.Factories;
using ECommerceSystem.Features.Basket.Checkout.Models;

namespace ECommerceSystem.Features.Basket.Checkout;

public class CheckoutStepList(
    PaymentMethodFactory paymentMethodFactory,
    ShippingMethodFactory shippingMethodFactory)
{
    public IPipelineStep<CheckoutContext>[] GetSteps(ProcessOrder orderProcessor)
        => [
            new CheckBasketHasItems(),
            new SelectPaymentMethod(paymentMethodFactory),
            new SelectShippingMethod(shippingMethodFactory),
            orderProcessor,
            new EmptyBasket()
        ];
}