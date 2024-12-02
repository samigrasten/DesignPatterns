namespace ECommerceSystem.Features.Basket.Checkout.Models;

public interface IPipelineStep<T> where T:class
{
    T? Run(T context);
}