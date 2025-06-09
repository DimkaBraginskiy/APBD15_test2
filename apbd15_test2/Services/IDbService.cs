using apbd15_test2.DTOs.Request;
using apbd15_test2.DTOs.Response;

namespace apbd15_test2.Services;

public interface IDbService
{
    public Task<CustomerResponseDto> GetCustomerPurchasesByIdAsync(CancellationToken token, int id);
    public Task AddWashingMachineAsync(CancellationToken token, WashingMachineWrapperRequestDto dto);
}