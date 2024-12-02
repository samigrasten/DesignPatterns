using ECommerceSystem.Features.Basket.Checkout.Models.MaybeMonad;

namespace ECommerceSystem.Features.Basket.Checkout.Models.CheckoutPipeline;

public interface IPipelineStep<T> where T:class
{
    Maybe<T> Run(T context);
}