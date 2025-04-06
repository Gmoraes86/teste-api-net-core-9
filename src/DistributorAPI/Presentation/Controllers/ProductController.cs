using DistributorAPI.Application.ProductUseCases;
using DistributorAPI.Presentation.DTOs;
using DistributorAPI.Presentation.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace DistributorAPI.Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductController(
    RegisterProductHandler registerProductHandler,
    UpdateProductHandler updateProductHandler,
    DeleteProductHandler deleteProductHandler,
    GetProductHandler getProductHandler) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] ProductDto dto)
    {
        var product = ProductMapper.ToEntity(dto);
        var result = await registerProductHandler.Handle(product);
        var response = ProductMapper.ToDto(result);
        return CreatedAtAction(nameof(GetById), new { id = result.Id }, response);
    }

    [HttpPut("{id:Guid}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] ProductDto dto)
    {
        var product = ProductMapper.ToEntity(dto);
        product.Id = id;
        var updatedProduct = await updateProductHandler.Handle(product);
        var response = ProductMapper.ToDto(updatedProduct);
        return Ok(response);
    }

    [HttpDelete("{id:Guid}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        await deleteProductHandler.Handle(id);
        return NoContent();
    }

    [HttpGet("{id:Guid}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var product = await getProductHandler.GetByIdAsync(id);
        if (product == null) return NotFound(new { message = "Product not found." });
        var response = ProductMapper.ToDto(product);
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var products = await getProductHandler.GetAllAsync();
        var response = products.Select(ProductMapper.ToDto).ToList();
        return Ok(response);
    }
}
