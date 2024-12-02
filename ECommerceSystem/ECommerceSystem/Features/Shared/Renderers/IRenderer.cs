namespace ECommerceSystem.Features.Shared.Renderers;

public interface IRenderer<in T>
{
    void Render(IEnumerable<T> rows);
}

public interface IRenderer<in T, in TU>
{
    void Render(T item, IEnumerable<TU> rows);
}
