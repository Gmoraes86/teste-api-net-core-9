using DistributorAPI.Application.CustomerUseCases;
using DistributorAPI.Presentation.DTOs;
using DistributorAPI.Presentation.Mappers;
using DistributorAPI.Presentation.Validations;
using Microsoft.AspNetCore.Mvc;

namespace DistributorAPI.Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CustomerController(
    RegisterCustomerHandler registerCustomerHandler,
    GetCustomerHandler getCustomerHandler,
    DeleteCustomerHandler deleteCustomerHandler,
    UpdateCustomerHandler updateCustomerHandler)
    : ControllerBase
{
    [HttpPost]
    [ServiceFilter(typeof(RegisterCustomerValidationFilter))]
    public async Task<IActionResult> Create([FromBody] CreateCustomerDto dto)
    {
        try
        {
            var customer = CustomerMapper.ToEntity(dto);

            var result = await registerCustomerHandler.Handle(customer);
            var response = CustomerMapper.ToDto(result);

            return CreatedAtAction(nameof(GetById), new { id = response.Id }, response);
        }
        catch (InvalidOperationException ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var customers = await getCustomerHandler.GetAllAsync();
        if (customers.Count == 0) return NotFound(new { message = "Customers not found." });
        var response = CustomerMapper.ToDtoList(customers);

        return Ok(response);
    }

    [HttpGet("{id:Guid}")]
    public async Task<IActionResult>? GetById(Guid id)
    {
        var customer = await getCustomerHandler.GetByIdAsync(id);

        if (customer == null) return NotFound(new { message = "Customer not found." });

        var response = CustomerMapper.ToDto(customer);
        return Ok(response);
    }

    [HttpPut("{id:Guid}")]
    [ServiceFilter(typeof(UpdateCustomerValidationFilter))]
    public async Task<IActionResult> Update(Guid id, [FromBody] UpdateCustomerDto dto)
    {
        try
        {
            var customer = CustomerMapper.ToEntity(dto, id);
            var result = await updateCustomerHandler.Handle(customer);
            var response = CustomerMapper.ToDto(result);
            return Ok(response);
        }
        catch (InvalidOperationException ex)
        {
            return NotFound(new { message = ex.Message });
        }
    }

    [HttpDelete("{id:Guid}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        try
        {
            await deleteCustomerHandler.Handle(id);
            return NoContent();
        }
        catch (InvalidOperationException ex)
        {
            return NotFound(new { message = ex.Message });
        }
    }
}