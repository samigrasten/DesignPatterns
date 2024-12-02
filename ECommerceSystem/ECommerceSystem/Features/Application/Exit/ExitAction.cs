using ECommerceSystem.Features.Shared;
using ECommerceSystem.Features.Shared.Renderers;

namespace ECommerceSystem.Features.Application.Exit;

public class ExitAction : IAction
{
    public int Id => 5;
    public string Name => "Exit";

    public void Handle()
    {
        Screen.OutputHighlight("Thank you for using E-commerce System!");
    }
}