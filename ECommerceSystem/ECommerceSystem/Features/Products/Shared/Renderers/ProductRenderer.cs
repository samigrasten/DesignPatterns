using ECommerceSystem.DomainObjects;
using ECommerceSystem.Features.Shared;
using ECommerceSystem.Features.Shared.Renderers;

namespace ECommerceSystem.Features.Products.Shared.Renderers;

public class ProductRenderer : IRenderer<Product>
{
    public void Render(IEnumerable<Product> items)
    {
        var index = 1;
        foreach (var item in items)
        {
            Screen.Output($"{index++}. {item.Name} ({item.Category}) - {item.Price} €");            
        }
    }
}