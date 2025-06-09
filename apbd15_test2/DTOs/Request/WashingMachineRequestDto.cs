namespace apbd15_test2.DTOs.Request;

public class WashingMachineRequestDto
{
    public decimal MaxWeight { get; set; }
    public string SerialNumber { get; set; }
    
    public List<AvailableProgramRequestDto> AvailablePrograms { get; set; } = new List<AvailableProgramRequestDto>();
}