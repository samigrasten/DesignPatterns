using ECommerceSystem.DomainObjects;
using ECommerceSystem.Features.Basket.Checkout.Models.PaymentMethods;
using ECommerceSystem.Features.Basket.Checkout.Models.ShippingMethods;

namespace ECommerceSystem.Features.Basket.Checkout;

public record CheckoutContext(OrderBasket OrderBasket)
{
    public IPaymentMethod PaymentMethod { get; init; } = new CreditCardPayment();
    public IShippingMethod ShippingMethod { get; init; } = new FreeShipping();
}