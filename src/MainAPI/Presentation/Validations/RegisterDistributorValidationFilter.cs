using MainAPI.Helpers;
using MainAPI.Presentation.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace MainAPI.Presentation.Validations;

public class RegisterDistributorValidationFilter: IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
            // Verificar se o DTO está presente nos argumentos da ação
            if (!context.ActionArguments.TryGetValue("dto", out var value) || value is not CreateDistributorDto dto)
            {
                context.Result = new BadRequestObjectResult(new { message = "Invalid request payload." });
                return;
            }

            // Validações do CNPJ
            if (string.IsNullOrWhiteSpace(dto.Cnpj))
            {
                context.Result = new BadRequestObjectResult(new { message = "CNPJ is required." });
                return;
            }
            if (!CnpjUtils.IsValid(dto.Cnpj))
            {
                context.Result = new BadRequestObjectResult("Invalid CNPJ.");
            }

            if (dto.Cnpj.Length != 14 || !dto.Cnpj.All(char.IsDigit))
            {
                context.Result = new BadRequestObjectResult(new { message = "CNPJ must be 14 numeric characters." });
                return;
            }

            // Validações do CorporateName
            if (string.IsNullOrWhiteSpace(dto.CorporateName))
            {
                context.Result = new BadRequestObjectResult(new { message = "Corporate Name is required." });
                return;
            }
            switch (dto.CorporateName.Length)
            {
                case < 5:
                    context.Result = new BadRequestObjectResult(new { message = "Corporate Name cannot less then 5 characters." });
                    return;
                case > 255:
                    context.Result = new BadRequestObjectResult(new { message = "Corporate Name cannot exceed 255 characters." });
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
                    context.Result = new BadRequestObjectResult(new { message = "Trade Name cannot less then 5 characters" });
                    return;
                case > 255:
                    context.Result = new BadRequestObjectResult(new { message = "Trade Name cannot exceed 255 characters." });
                    return;
            }

            // Validações do Email
            if (string.IsNullOrWhiteSpace(dto.Email))
            {
                context.Result = new BadRequestObjectResult(new { message = "Email is required." });
                return;
            }
            
            if (!EmailUtils.IsValid(dto.Email))
            {
                context.Result = new BadRequestObjectResult("Invalid email format.");
            }

            // Validações de Contacts
            if (dto.Contacts.Count == 0)
            {
                context.Result = new BadRequestObjectResult(new { message = "At least one contact name is required." });
                return;
            }

            // Validações de DeliveryAddresses
            if (dto.Addresses.Count != 0) return;
            context.Result = new BadRequestObjectResult(new { message = "At least one delivery address is required." });
            return;
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            
        }
    }