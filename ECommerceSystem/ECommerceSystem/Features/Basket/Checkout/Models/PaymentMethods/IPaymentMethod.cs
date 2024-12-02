namespace ECommerceSystem.Features.Basket.Checkout.Models.PaymentMethods;

public interface IPaymentMethod
{
    int Id { get; }
    bool ProcessPayment(decimal totalCost);
}