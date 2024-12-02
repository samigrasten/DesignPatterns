namespace ECommerceSystem.Features.Basket.Checkout.PaymentMethods;

public interface IPaymentMethod
{
    int Id { get; }
    bool ProcessPayment(decimal totalCost);
}