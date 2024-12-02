using ECommerceSystem.Features.Application.Exit;
using ECommerceSystem.Features.Shared;
using ECommerceSystem.Features.Shared.Renderers;

namespace ECommerceSystem.Features.Application.MainMenu;

public class MainMenu(ActionFactory actionFactory, CommandReader commandReader)
{
    public void Run()
    {
        Screen.OutputHighlight("Welcome to the E-commerce System!");
        IAction action;
        do
        {
            var command = commandReader.GetNextCommand();
            action = actionFactory.CreateAction(command);
            action.Handle();
        } 
        while (action is not ExitAction);
    }
}