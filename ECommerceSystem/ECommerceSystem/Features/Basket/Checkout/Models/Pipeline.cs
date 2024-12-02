using ECommerceSystem.Features.Shared.Renderers;

namespace ECommerceSystem.Features.Basket.Checkout.Models;

public class Pipeline<T>(params IPipelineStep<T>[] pipelineSteps) where T:class
{
    public bool Invoke(T context)
    {
        foreach (var step in pipelineSteps)
        {
            try
            {
                var newContext = step.Run(context);
                if (newContext is null) return false;
                context = newContext;
            }
            catch (Exception e)
            {
                Screen.OutputError($"Composition failed!");
                return false;
            }
        }

        return true;
    }
}