using ECommerceSystem.DomainObjects;
using ECommerceSystem.Features.Basket.Checkout.CheckoutSteps;
using ECommerceSystem.Features.Basket.Checkout.Factories;
using ECommerceSystem.Features.Basket.Checkout.Models;
using ECommerceSystem.Features.Basket.Checkout.PaymentMethods;
using ECommerceSystem.Features.Basket.Checkout.ShippingMethods;
using ECommerceSystem.Features.Shared;
using ECommerceSystem.Features.Shared.Renderers;

namespace ECommerceSystem.Features.Basket.Checkout;

public class CheckoutAction(
    IEnumerable<IObserver<Order>> orderPostProcessors,
    OrderBasket orderBasket,
    ProcessOrder orderProcessor,
    CheckoutStepList stepList) : IAction
{
    private static readonly IShippingMethod DefaultShipping = new FreeShipping();
    private static readonly IPaymentMethod DefaultPayment = new CreditCardPayment();
    private readonly CheckoutContext _context = new(orderBasket, DefaultPayment, DefaultShipping);
    private readonly List<Unsubscriber<Order>> _processors = SubscribePostProcessors(orderProcessor, orderPostProcessors);
    private readonly Pipeline<CheckoutContext> _pipeline = new(stepList.GetSteps(orderProcessor));

    public int Id => 4;
    public string Name => "Checkout";

    ~CheckoutAction()
    {
        UnsubscribeProcessors(_processors);
    }

    public void Handle() => _pipeline.Invoke(_context);
    
    private static List<Unsubscriber<Order>> SubscribePostProcessors(ProcessOrder orderProcessor, IEnumerable<IObserver<Order>> orderPostProcessors)
        => orderPostProcessors
            .Select(orderProcessor.Subscribe)
            .ToList();

    private static void UnsubscribeProcessors(List<Unsubscriber<Order>> processors)
        => processors.ForEach(processor => processor.Dispose());
}