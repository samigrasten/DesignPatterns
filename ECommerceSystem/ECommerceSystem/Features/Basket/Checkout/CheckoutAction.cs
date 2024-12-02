using ECommerceSystem.DomainObjects;
using ECommerceSystem.Features.Basket.Checkout.CheckoutSteps;
using ECommerceSystem.Features.Basket.Checkout.CheckoutSteps.ProcessOrder;
using ECommerceSystem.Features.Basket.Checkout.Models;
using ECommerceSystem.Features.Basket.Checkout.Models.CheckoutPipeline;
using ECommerceSystem.Features.Shared;
using ECommerceSystem.Features.Shared.Renderers;

namespace ECommerceSystem.Features.Basket.Checkout;

public class CheckoutAction(
    IEnumerable<IObserver<Order>> orderPostProcessors,
    OrderBasket orderBasket,
    ProcessOrderStep orderProcessorStep,
    CheckoutStepList stepList) : IAction
{
    private readonly CheckoutContext _context = new (orderBasket);
    private readonly List<Unsubscriber<Order>> _processors = SubscribePostProcessors(orderProcessorStep, orderPostProcessors);
    private readonly Pipeline<CheckoutContext> _pipeline = new(stepList.GetSteps(orderProcessorStep));

    public int Id => 4;
    public string Name => "Checkout";

    public void Handle() => _pipeline.Invoke(_context);

    private static List<Unsubscriber<Order>> SubscribePostProcessors(ProcessOrderStep orderProcessor, IEnumerable<IObserver<Order>> orderPostProcessors)
        => orderPostProcessors
            .Select(orderProcessor.Subscribe)
            .ToList();

    private static void UnsubscribeProcessors(List<Unsubscriber<Order>> processors)
        => processors.ForEach(processor => processor.Dispose());

    ~CheckoutAction()
    {
        UnsubscribeProcessors(_processors);
    }
}