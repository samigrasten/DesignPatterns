namespace ECommerceSystem.Features.Basket.Checkout.Models;

public sealed class Unsubscriber<T>(ISet<IObserver<T>> observers, IObserver<T> observer) : IDisposable
{
    public void Dispose() => observers.Remove(observer);
}