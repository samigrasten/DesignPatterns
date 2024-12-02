using ECommerceSystem.DomainObjects;
using ECommerceSystem.Features.Basket.Checkout.PaymentMethods;
using ECommerceSystem.Features.Basket.Checkout.ShippingMethods;

namespace ECommerceSystem.Features.Basket.Checkout.CheckoutSteps;

public record CheckoutContext(OrderBasket OrderBasket, IPaymentMethod PaymentMethod, IShippingMethod ShippingMethod);