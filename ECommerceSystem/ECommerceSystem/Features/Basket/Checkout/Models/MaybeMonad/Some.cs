namespace ECommerceSystem.Features.Basket.Checkout.Models.MaybeMonad;

public sealed record Some<T>(T value) : Maybe<T>
{
    public override bool HasValue => true;

    public T Value { get; } = value ?? throw new ArgumentNullException(nameof(value), "Value cannot be null for Some.");
}