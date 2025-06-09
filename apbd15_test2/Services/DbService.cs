using System.ComponentModel.DataAnnotations;
using apbd15_test2.Data;
using apbd15_test2.DTOs.Request;
using apbd15_test2.DTOs.Response;
using apbd15_test2.Exceptions;
using apbd15_test2.Models;
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
        var customer = await _dbContext.Customers
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
            }).FirstOrDefaultAsync(token);               

        if (customer == null)
        {
            throw new NotFoundException($"Customer with id {id} not found.");
        }
                

        return customer;
    }
    
    public async Task AddWashingMachineAsync(CancellationToken token, WashingMachineWrapperRequestDto dto)
    {
        var wm = dto.WashingMachine;

        if (wm.MaxWeight < 8)
            throw new ValidationException("Maximum capacity must not to be less than 8!");

        if (await _dbContext.WashingMachines.AnyAsync(w => w.SerialNumber == wm.SerialNumber, token))
            throw new ConflictException($"Washing machine with serial number {wm.SerialNumber} already exists.");

        if (dto.AvailablePrograms.Any(p => p.Price > 25))
            throw new ValidationException("Price has exceeded the maximum of 25!");

        var programNames = dto.AvailablePrograms.Select(p => p.ProgramName).ToList();

        var existingPrograms = await _dbContext.Programs
            .Where(p => programNames.Contains(p.Name))
            .ToListAsync(token);

        if (existingPrograms.Count != programNames.Count)
        {
            var missing = programNames.Except(existingPrograms.Select(p => p.Name)).ToList();
            throw new NotFoundException($"Programs not found: {string.Join(", ", missing)}");
        }

        var newMachine = new WashingMachine
        {
            MaxWeight = wm.MaxWeight,
            SerialNumber = wm.SerialNumber
        };

        _dbContext.WashingMachines.Add(newMachine);
        await _dbContext.SaveChangesAsync(token);

        var availablePrograms = dto.AvailablePrograms.Select(p => new AvailableProgram
        {
            WashingMachineId = newMachine.WashingMachineId,
            ProgramId = existingPrograms.First(e => e.Name == p.ProgramName).ProgramId,
            Price = p.Price
        }).ToList();

        _dbContext.AvailablePrograms.AddRange(availablePrograms);
        await _dbContext.SaveChangesAsync(token);
    }
}