using ECommerceSystem.DomainObjects;
using ECommerceSystem.Features.Basket.Checkout.CheckoutSteps;
using ECommerceSystem.Features.Basket.Checkout.CheckoutSteps.ProcessOrder;
using ECommerceSystem.Features.Basket.Checkout.Models;
using ECommerceSystem.Features.Basket.Checkout.Models.CheckoutPipeline;
using ECommerceSystem.Features.Basket.Checkout.Models.OperationResults;
using ECommerceSystem.Features.Shared;
using ECommerceSystem.Features.Shared.Renderers;

namespace ECommerceSystem.Features.Basket.Checkout;

public sealed class CheckoutAction :  IAction, IDisposable
{
    private readonly CheckoutContext _context;
    private readonly List<Unsubscriber<Order>> _processors;
    private readonly Pipeline<CheckoutContext> _pipeline;
    private bool _disposed;

    public CheckoutAction(
        IEnumerable<IObserver<Order>> orderPostProcessors,
        OrderBasket orderBasket,
        ProcessOrderStep orderProcessorStep,
        CheckoutStepList stepList)
    {
        _context = new(orderBasket);
        _processors = SubscribePostProcessors(orderProcessorStep, orderPostProcessors);
        _pipeline = new(stepList.GetSteps(orderProcessorStep));
    }

    public int Id => 4;
    public string Name => "Checkout";

    public void Handle()
    {
        ThrowIfDisposed();
        var result = _pipeline.Invoke(_context);
        if (result is FailResult failResult) Screen.OutputError(failResult.ErrorMessage);            
    }

    private static List<Unsubscriber<Order>> SubscribePostProcessors(ProcessOrderStep orderProcessor, IEnumerable<IObserver<Order>> orderPostProcessors)
        => orderPostProcessors
            .Select(orderProcessor.Subscribe)
            .ToList();

    private void UnsubscribeProcessors()
    {
        foreach (var processor in _processors)
        {
            processor.Dispose();
        }
    }

    private void ThrowIfDisposed()
    {
        if (!_disposed) return;
        throw new ObjectDisposedException(nameof(CheckoutAction));
    }

    public void Dispose()
    {
        if (_disposed) return;
        
        UnsubscribeProcessors();
        _disposed = true;
    }
}