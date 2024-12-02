namespace ECommerceSystem.Features.Basket.Checkout.ShippingMethods;

public interface IShippingMethod
{
    int Id { get; }
    decimal GetShippingCost();
    string GetMethodName();
}