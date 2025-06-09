namespace apbd15_test2.DTOs.Request;

public class WashingMachineWrapperRequestDto
{
    public WashingMachineRequestDto WashingMachine { get; set; }
    public List<AvailableProgramRequestDto> AvailablePrograms { get; set; } = new List<AvailableProgramRequestDto>();  
}