using MainAPI.Application.DistributorUseCases;
using MainAPI.Presentation.DTOs;
using MainAPI.Presentation.Mappers;
using MainAPI.Presentation.Validations;
using Microsoft.AspNetCore.Mvc;

namespace MainAPI.Presentation.Controllers;


[ApiController]
[Route("api/[controller]")]
public class DistributorController(
    RegisterDistributorHandler registerDistributorHandler,
    GetDistributorHandler getDistributorHandler,
    DeleteDistributorHandler deleteDistributorHandler,
    UpdateDistributorHandler updateDistributorHandler)
    : ControllerBase
{
    [HttpPost]
    [ServiceFilter(typeof(RegisterDistributorValidationFilter))]
    public async Task<IActionResult> Create([FromBody] CreateDistributorDto dto)
    {
        try
        {
            var distributor = DistributorMapper.ToEntity(dto);
            
            var result = await registerDistributorHandler.Handle(distributor);
            var response = DistributorMapper.ToDto(result);
            
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
        var distributors = await getDistributorHandler.GetAllAsync();
        if (distributors.Count == 0)
        {
            return NotFound(new { message = "Distributors not found." });
        }
        var response = DistributorMapper.ToDtoList(distributors);
        
        return Ok(response);
    }
    
    [HttpGet("{id:Guid}")]
    public async Task<IActionResult>? GetById(Guid id)
    {
        var distributor = await getDistributorHandler.GetByIdAsync(id);
        
        if (distributor == null)
        {
            return NotFound(new { message = "Distributor not found." });
        }
        
        var response = DistributorMapper.ToDto(distributor);
        return Ok(response);
    }
    
    [HttpPut("{id:Guid}")]
    [ServiceFilter(typeof(UpdateDistributorValidationFilter))]
    public async Task<IActionResult> Update(Guid id, [FromBody] UpdateDistributorDto dto)
    {
        try
        {
            var distributor = DistributorMapper.ToEntity(dto, id);
            var result = await updateDistributorHandler.Handle(distributor);
            var response = DistributorMapper.ToDto(result);
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
            await deleteDistributorHandler.Handle(id);
            return NoContent();
        }
        catch (InvalidOperationException ex)
        {
            return NotFound(new { message = ex.Message });
        }
    }
}
