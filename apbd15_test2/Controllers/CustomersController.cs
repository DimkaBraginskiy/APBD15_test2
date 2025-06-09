using apbd15_test2.Exceptions;
using apbd15_test2.Services;
using Microsoft.AspNetCore.Mvc;

namespace apbd15_test2.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CustomersController : ControllerBase
{
    private readonly IDbService _dbService;
    
    public CustomersController(IDbService dbService)
    {
        _dbService = dbService;
    }

    [HttpGet("{id}/purchases")]
    public async Task<IActionResult> GetCustomerPurchasesByIdAsync(CancellationToken token, int id)
    {
        try
        {
            var result = await _dbService.GetCustomerPurchasesByIdAsync(token, id);
            return new OkObjectResult(result);
        }
        catch (NotFoundException)
        {
            return NotFound(new { message = $"Customer with id {id} not found." });
        }
    }
    
    
}