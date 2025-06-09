using apbd15_test2.Data;
using apbd15_test2.DTOs.Response;
using apbd15_test2.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace apbd15_test2.Services;

public class DbService : IDbService
{
    private readonly DatabaseContext _dbContext;
    
    public DbService(DatabaseContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<CustomerResponseDto> GetCustomerPurchasesByIdAsync(CancellationToken token, int id)
    {
        /*var customer = await _dbContext.Customers
            .Where(c => c.CustomerId == id)
            .Select(c => new CustomerResponseDto()
            {
                FirstName = c.FirstName,
                LastName = c.LastName,
                PhoneNumber = c.PhoneNumber,
                Purchases = c.PurchaseHistories
                    .Select(ph => new PurchaseResponseDto()
                    {
                        Date = ph.PurchaseDate,
                        Rating = ph.Rating,
                        Price = ph.AvailableProgram.Price,
                        WashingMachine = new WashingMachineResponseDto()
                        {
                            Serial = ph.AvailableProgram.WashingMachine.SerialNumber,
                            MaxWeight = ph.AvailableProgram.WashingMachine.MaxWeight
                        },
                        WashingProgram = new WashingProgramResponseDto()
                        {
                            Name = ph.AvailableProgram.WashingProgram.Name,
                            Duration = ph.AvailableProgram.WashingProgram.DurationMinutes
                        }
                    }).ToList()
            }).FirstOrDefaultAsync(token);*/

        var customer = await _dbContext.Customers
            .Where(c => c.CustomerId == id)
            .Select(c => new CustomerResponseDto()
            {
                FirstName = c.FirstName,
                LastName = c.LastName,
                PhoneNumber = c.PhoneNumber
            }).FirstOrDefaultAsync(token);

        if (customer == null)
        {
            throw new NotFoundException($"Customer with id {id} not found.");
        }

        return customer;
    }
}