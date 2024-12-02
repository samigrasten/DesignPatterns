namespace ECommerceSystem.Features.Shared;

public interface IAction
{
    int Id { get; }
    string Name { get; }
    void Handle();
}