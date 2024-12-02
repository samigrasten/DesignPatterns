namespace ECommerceSystem.Features.Basket.Checkout.ShippingMethods;

public class ExressShipping : IShippingMethod
{
    public int Id => 2;
    public decimal GetShippingCost() => 15.0m;
    public string GetMethodName() => "Express";
}