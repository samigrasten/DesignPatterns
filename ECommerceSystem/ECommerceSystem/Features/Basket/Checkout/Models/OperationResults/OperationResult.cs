namespace ECommerceSystem.Features.Basket.Checkout.Models.OperationResults;

public abstract class OperationResult
{
    public abstract bool IsSuccess { get; }
    
    public static OperationResult Success() => new SuccessResult();
    public static OperationResult Fail(string message) => new FailResult(message);
}