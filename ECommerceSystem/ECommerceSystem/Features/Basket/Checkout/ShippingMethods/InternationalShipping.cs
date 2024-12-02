namespace ECommerceSystem.Features.Basket.Checkout.ShippingMethods;

public class InternationalShipping : IShippingMethod
{
    public int Id => 3;
    public decimal GetShippingCost() => 25.0m;
    public string GetMethodName() => "International";

}