using DistributorAPI.Application.OrderUseCases;
using DistributorAPI.Domain.Entities;
using DistributorAPI.Presentation.DTOs;
using DistributorAPI.Presentation.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace DistributorAPI.Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrderController(CreateOrderHandler createOrderHandler) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateOrderDto dto)
    {
        if (!dto.IsValid(out var errorMessage))
            return BadRequest(new { message = errorMessage });

        var orderEntity = OrderMapper.ToEntity(dto);
        var createdOrder = await createOrderHandler.Handle(orderEntity.CustomerId, dto.Products.Select(p => (p.ProductId, p.Quantity)).ToList());
        var response = OrderMapper.ToDto(createdOrder);
        return CreatedAtAction(nameof(GetById), new { id = response.Id }, response);
    }

    [HttpGet("{id:Guid}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var order = await createOrderHandler.GetByIdAsync(id);
        if (order == null)
            return NotFound(new { message = "Order not found." });

        var response = OrderMapper.ToDto(order);
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var orders = await createOrderHandler.GetAllAsync();
        var response = orders.Select(OrderMapper.ToDto).ToList();
        return Ok(response);    
    }
        
        
    [HttpPatch("{id:Guid}/status")]
     public async Task<IActionResult> UpdateStatus(Guid id, [FromBody] OrderStatus newStatus)
    {
        try
        {
            var updatedOrder = await createOrderHandler.UpdateStatusAsync(id, newStatus);
            var response = OrderMapper.ToDto(updatedOrder);
            return Ok(response);
        }
        catch (InvalidOperationException ex)
        {
            return NotFound(new { message = ex.Message });
        }
    }
}
