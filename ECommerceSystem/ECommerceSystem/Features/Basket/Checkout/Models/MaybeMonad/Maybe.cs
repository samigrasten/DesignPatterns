namespace ECommerceSystem.Features.Basket.Checkout.Models.MaybeMonad;

public abstract record Maybe<T>
{
    public abstract bool HasValue { get; }

    public static None<T> None => new ();

    public static implicit operator Maybe<T>(T value)
        => new Some<T>(value);

    public static implicit operator T(Maybe<T> maybeValue)
        => maybeValue.HasValue
            ? ((Some<T>)maybeValue).Value
            : throw new InvalidOperationException("Tried to get value from None");

}