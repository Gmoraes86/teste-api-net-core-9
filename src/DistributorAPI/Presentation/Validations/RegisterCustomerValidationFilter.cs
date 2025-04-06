using DistributorAPI.Helpers;
using DistributorAPI.Presentation.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace DistributorAPI.Presentation.Validations;

public class RegisterCustomerValidationFilter : IActionFilter
{
    public void OnActionExecuting(ActionExecutingContext context)
    {
        // Verificar se o DTO está presente nos argumentos da ação
        if (!context.ActionArguments.TryGetValue("dto", out var value) || value is not CreateCustomerDto dto)
        {
            context.Result = new BadRequestObjectResult(new { message = "Invalid request payload." });
            return;
        }

        // Validações do Document
        if (string.IsNullOrWhiteSpace(dto.Document)) // Renomeado de Cnpj para Document
        {
            context.Result = new BadRequestObjectResult(new { message = "Document is required." });
            return;
        }

        if (!CnpjUtils.IsValid(dto.Document)) // Renomeado de Cnpj para Document
            context.Result = new BadRequestObjectResult("Invalid Document.");

        if (dto.Document.Length != 14 || !dto.Document.All(char.IsDigit)) // Renomeado de Cnpj para Document
        {
            context.Result = new BadRequestObjectResult(new { message = "Document must be 14 numeric characters." });
            return;
        }

        // Validações do FullName
        if (string.IsNullOrWhiteSpace(dto.FullName))
        {
            context.Result = new BadRequestObjectResult(new { message = "Corporate Name is required." });
            return;
        }

        switch (dto.FullName.Length)
        {
            case < 5:
                context.Result =
                    new BadRequestObjectResult(new { message = "Corporate Name cannot less then 5 characters." });
                return;
            case > 255:
                context.Result =
                    new BadRequestObjectResult(new { message = "Corporate Name cannot exceed 255 characters." });
                return;
        }

        // Validações do TradeName
        if (string.IsNullOrWhiteSpace(dto.TradeName))
        {
            context.Result = new BadRequestObjectResult(new { message = "Trade Name is required." });
            return;
        }

        switch (dto.TradeName.Length)
        {
            case < 5:
                context.Result =
                    new BadRequestObjectResult(new { message = "Trade Name cannot less then 5 characters" });
                return;
            case > 255:
                context.Result =
                    new BadRequestObjectResult(new { message = "Trade Name cannot exceed 255 characters." });
                return;
        }

        // Validações do Email
        if (string.IsNullOrWhiteSpace(dto.Email))
        {
            context.Result = new BadRequestObjectResult(new { message = "Email is required." });
            return;
        }

        if (!EmailUtils.IsValid(dto.Email)) context.Result = new BadRequestObjectResult("Invalid email format.");

        // Validações de Contacts
        if (dto.Contacts.Count == 0)
        {
            context.Result = new BadRequestObjectResult(new { message = "At least one contact name is required." });
            return;
        }

        // Validações de DeliveryAddresses
        if (dto.Addresses.Count != 0) return;
        context.Result = new BadRequestObjectResult(new { message = "At least one delivery address is required." });
    }

    public void OnActionExecuted(ActionExecutedContext context)
    {
    }
}