using System.ComponentModel.DataAnnotations;
using apbd15_test2.DTOs.Request;
using apbd15_test2.Exceptions;
using apbd15_test2.Services;
using Microsoft.AspNetCore.Mvc;

namespace apbd15_test2.Controllers;

[ApiController]
[Route("washing-machines")]
public class WashingMachinesController : ControllerBase
{
    private readonly IDbService _dbService;
    
    public WashingMachinesController(IDbService dbService)
    {
        _dbService = dbService;
    }
    
    [HttpPost]
    public async Task<IActionResult> AddWashingMachineAsync(CancellationToken token, [FromBody] WashingMachineWrapperRequestDto dto)
    {
        try
        {
            await _dbService.AddWashingMachineAsync(token, dto);
            return Ok(new { message = "Washing machine added successfully." });
        }
        catch (ValidationException ex)
        {
            return BadRequest(new { error = ex.Message });
        }
        catch (ConflictException ex)
        {
            return Conflict(new { error = ex.Message });
        }
        catch (NotFoundException ex)
        {
            return NotFound(new { error = ex.Message });
        }
    }
    
    
}