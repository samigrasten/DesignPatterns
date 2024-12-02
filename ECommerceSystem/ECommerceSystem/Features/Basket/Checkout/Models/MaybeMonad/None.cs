namespace ECommerceSystem.Features.Basket.Checkout.Models.MaybeMonad;

public sealed record None<T> : Maybe<T>
{
    public override bool HasValue => false;
}