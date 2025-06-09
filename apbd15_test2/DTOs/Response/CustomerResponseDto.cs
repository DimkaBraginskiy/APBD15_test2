

namespace apbd15_test2.DTOs.Response;

public class CustomerResponseDto
{
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string? PhoneNumber { get; set; }
    
    //public List<PurchaseResponseDto> Purchases { get; set; } = new List<PurchaseResponseDto>();
}