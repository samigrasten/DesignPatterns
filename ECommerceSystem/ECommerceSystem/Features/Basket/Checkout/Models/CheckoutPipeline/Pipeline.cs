﻿using ECommerceSystem.Features.Basket.Checkout.Models.OperationResults;
using ECommerceSystem.Features.Shared.Renderers;

namespace ECommerceSystem.Features.Basket.Checkout.Models.CheckoutPipeline;

public class Pipeline<T>(params IPipelineStep<T>[] pipelineSteps) where T:class
{

    public OperationResult Invoke(T context)
    {
        foreach (var step in pipelineSteps)
        {
            try
            {
                var maybeNewContext = step.Run(context);
                if (!maybeNewContext.HasValue) return OperationResult.Fail("Pipeline step returned None");
                context = maybeNewContext;
            }
            catch (Exception)
            {
                Screen.OutputError($"Composition failed!");
                return OperationResult.Fail("Pipeline step failed");
            }
        }

        return OperationResult.Success();
    }
}