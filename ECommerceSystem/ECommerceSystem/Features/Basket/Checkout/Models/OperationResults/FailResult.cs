namespace ECommerceSystem.Features.Basket.Checkout.Models.OperationResults;


public class FailResult : OperationResult
{
    public override bool IsSuccess => false;
    public string ErrorMessage { get; }

    public FailResult(string errorMessage)
    {
        ErrorMessage = errorMessage;
    }
}
