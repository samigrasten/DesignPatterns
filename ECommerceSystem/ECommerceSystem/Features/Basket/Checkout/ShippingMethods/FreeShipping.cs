namespace ECommerceSystem.Features.Basket.Checkout.ShippingMethods;

public class FreeShipping : IShippingMethod
{
    public int Id => 1;
    public decimal GetShippingCost() => 0.0m;
    public string GetMethodName() => "Free";
}