using ECommerceSystem.Features.Shared;

namespace ECommerceSystem.Features.Application.MainMenu;

public class ActionFactory(IEnumerable<IAction> actions)
{
    public IAction CreateAction(int command)
    {
        var action = actions.FirstOrDefault(a => a.Id == command);
        if (action == null) throw new ArgumentOutOfRangeException($"Unknown command: {command}");
        return action;
    }
}