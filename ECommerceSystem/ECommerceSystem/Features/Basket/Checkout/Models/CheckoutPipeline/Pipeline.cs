using ECommerceSystem.Features.Shared.Renderers;

namespace ECommerceSystem.Features.Basket.Checkout.Models.CheckoutPipeline;

public class Pipeline<T>(params IPipelineStep<T>[] pipelineSteps) where T:class
{
    public bool Invoke(T context)
    {
        foreach (var step in pipelineSteps)
        {
            try
            {
                var maybeNewContext = step.Run(context);
                if (!maybeNewContext.HasValue) return false;
                context = maybeNewContext;
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