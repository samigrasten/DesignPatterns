namespace ECommerceSystem.Features.Basket.Checkout.Models.ShippingMethods;

public interface IShippingMethod
{
    int Id { get; }
    decimal GetShippingCost();
    string GetMethodName();
}