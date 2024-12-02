﻿using ECommerceSystem.Features.Basket.Checkout.PaymentMethods;

namespace ECommerceSystem.Features.Basket.Checkout.Factories;

public class PaymentMethodFactory(IEnumerable<IPaymentMethod> paymentMethods)
{
    public IPaymentMethod CreateFrom(int paymentMethodId)
    {
        var paymentMethod = paymentMethods.FirstOrDefault(p => p.Id == paymentMethodId);
        if (paymentMethod is null) throw new ArgumentOutOfRangeException($"Unknown payment method: {paymentMethodId}");
        return paymentMethod;
    }
}