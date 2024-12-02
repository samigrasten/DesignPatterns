using ECommerceSystem.Features.Shared;
using ECommerceSystem.Features.Shared.Renderers;

namespace ECommerceSystem.Features.Application.MainMenu;

public class CommandReader(IEnumerable<IAction> actions)
{
    public int GetNextCommand()
    {
        Screen.Output();
        foreach (var action in actions)
        {
            Screen.Output($"{action.Id}. {action.Name}");    
        }

        return Screen.GetInteger(
            "Select an option: ",
            actions.Min(a => a.Id),
            actions.Max(a => a.Id),
            "Invalid option, please try again.");
    }
}
