using apbd15_test2.Models;
using Microsoft.EntityFrameworkCore;

namespace apbd15_test2.Data;

public class DatabaseContext : DbContext
{
    public DbSet<Customer> Customers { get; set; }
    public DbSet<AvailableProgram> AvailablePrograms { get; set; }
    public DbSet<WashingProgram> Programs { get; set; }
    public DbSet<PurchaseHistory> PurchaseHistories { get; set; }
    public DbSet<WashingMachine> WashingMachines { get; set; }
    
    protected DatabaseContext()
    {
    }
    
    public DatabaseContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        
        modelBuilder.Entity<WashingMachine>().HasData(
            new WashingMachine { WashingMachineId = 1, MaxWeight = 8.5m, SerialNumber = "SN123456" },
            new WashingMachine { WashingMachineId = 2, MaxWeight = 7.0m, SerialNumber = "SN654321" }
        );

        
        modelBuilder.Entity<WashingProgram>().HasData(
            new WashingProgram { ProgramId = 1, Name = "Quick Wash", DurationMinutes = 30, TemperatureCelsius = 40 },
            new WashingProgram { ProgramId = 2, Name = "Eco Wash", DurationMinutes = 60, TemperatureCelsius = 30 },
            new WashingProgram { ProgramId = 3, Name = "Heavy Duty", DurationMinutes = 90, TemperatureCelsius = 60 }
        );

        
        modelBuilder.Entity<Customer>().HasData(
            new Customer { CustomerId = 1, FirstName = "Alice", LastName = "Johnson", PhoneNumber = "123456789" },
            new Customer { CustomerId = 2, FirstName = "Bob", LastName = "Smith", PhoneNumber = "987654321" }
        );

        
        modelBuilder.Entity<AvailableProgram>().HasData(
            new AvailableProgram { AvailableProgramId = 1, WashingMachineId = 1, ProgramId = 1, Price = 4.99m },
            new AvailableProgram { AvailableProgramId = 2, WashingMachineId = 1, ProgramId = 2, Price = 3.99m },
            new AvailableProgram { AvailableProgramId = 3, WashingMachineId = 2, ProgramId = 3, Price = 5.49m }
        );

        
        modelBuilder.Entity<PurchaseHistory>().HasData(
            new PurchaseHistory { AvailableProgramId = 1, CustomerId = 1, PurchaseDate = DateTime.Parse("2024-06-01"), Rating = 5 },
            new PurchaseHistory { AvailableProgramId = 2, CustomerId = 2, PurchaseDate = DateTime.Parse("2024-06-05"), Rating = 4 }
        );
    }

}