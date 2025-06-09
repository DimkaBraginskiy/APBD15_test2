

namespace apbd15_test2.DTOs.Response;

public class PurchaseResponseDto
{
    public DateTime Date { get; set; }
    public int? Rating { get; set; }
    public decimal Price { get; set; }
    
    public WashingMachineResponseDto WashingMachine { get; set; } = null!;
    public WashingProgramResponseDto WashingProgram { get; set; } = null!;
}