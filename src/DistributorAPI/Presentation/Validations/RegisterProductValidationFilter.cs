using DistributorAPI.Presentation.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace DistributorAPI.Presentation.Validations;

public class RegisterProductValidationFilter : IActionFilter
{
    public void OnActionExecuting(ActionExecutingContext context)
    {
        if (!context.ActionArguments.TryGetValue("dto", out var value) || value is not ProductDto dto)
        {
            context.Result = new BadRequestObjectResult(new { message = "Invalid request payload." });
            return;
        }

        if (string.IsNullOrWhiteSpace(dto.Name))
        {
            context.Result = new BadRequestObjectResult(new { message = "Product name is required." });
            return;
        }

        if (dto.Price <= 0)
        {
            context.Result = new BadRequestObjectResult(new { message = "Price must be greater than zero." });
            return;
        }

        if (dto.Stock < 0)
        {
            context.Result = new BadRequestObjectResult(new { message = "Stock cannot be negative." });
            return;
        }

    }

    public void OnActionExecuted(ActionExecutedContext context)
    {
    }
}
