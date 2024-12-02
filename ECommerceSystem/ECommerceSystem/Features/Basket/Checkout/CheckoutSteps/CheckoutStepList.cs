using ECommerceSystem.Features.Basket.Checkout.CheckoutSteps.ProcessOrder;
using ECommerceSystem.Features.Basket.Checkout.CheckoutSteps.SelectPaymentMethod;
using ECommerceSystem.Features.Basket.Checkout.CheckoutSteps.SelectShippingMethod;
using ECommerceSystem.Features.Basket.Checkout.Models;
using ECommerceSystem.Features.Basket.Checkout.Models.CheckoutPipeline;

namespace ECommerceSystem.Features.Basket.Checkout.CheckoutSteps;

public class CheckoutStepList(
    PaymentMethodFactory paymentMethodFactory,
    ShippingMethodFactory shippingMethodFactory)
{
    public IPipelineStep<CheckoutContext>[] GetSteps(ProcessOrderStep orderProcessor)
        => [
            new CheckBasketHasItemsStep(),
            new SelectPaymentMethodStep(paymentMethodFactory),
            new SelectShippingMethodStep(shippingMethodFactory),
            orderProcessor,
            new ClearBasketStep()
        ];
}