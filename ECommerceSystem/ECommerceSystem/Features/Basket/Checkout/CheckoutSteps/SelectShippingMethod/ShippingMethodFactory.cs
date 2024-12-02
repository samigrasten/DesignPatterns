using ECommerceSystem.Features.Basket.Checkout.Models.ShippingMethods;

namespace ECommerceSystem.Features.Basket.Checkout.CheckoutSteps.SelectShippingMethod;

public class ShippingMethodFactory(IEnumerable<IShippingMethod> shippingMethods)
{
    public IShippingMethod CreateFrom(int shippingMethodId)
    {
        var shippingMethod = shippingMethods.FirstOrDefault(s => s.Id == shippingMethodId);
        if (shippingMethod is null) throw new ArgumentOutOfRangeException($"Unknown shipping method: {shippingMethodId}");
        return shippingMethod;
    }
}