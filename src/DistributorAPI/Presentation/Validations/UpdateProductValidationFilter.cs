using DistributorAPI.Presentation.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace DistributorAPI.Presentation.Validations;

public class UpdateProductValidationFilter : IActionFilter
{
    public void OnActionExecuting(ActionExecutingContext context)
    {
        if (!context.ActionArguments.TryGetValue("dto", out var value) || value is not ProductDto dto)
        {
            context.Result = new BadRequestObjectResult(new { message = "Invalid request payload." });
            return;
        }

        if (string.IsNullOrWhiteSpace(dto.Sku))
        {
            context.Result = new BadRequestObjectResult(new { message = "Product sku is required." });
            return;
        }

        if (dto.Price <= 0)
        {
            context.Result = new BadRequestObjectResult(new { message = "Price must be greater than zero." });
            return;
        }

    }

    public void OnActionExecuted(ActionExecutedContext context)
    {
    }
}
