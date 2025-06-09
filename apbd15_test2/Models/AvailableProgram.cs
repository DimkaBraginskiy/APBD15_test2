using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace apbd15_test2.Models;

[Table("Available_Program")]
public class AvailableProgram
{
    public int AvailableProgramId { get; set; }
    
    [ForeignKey(nameof(WashingMachine))]
    public int WashingMachineId { get; set; }
    public WashingMachine WashingMachine { get; set; } = null!;
    
    [ForeignKey(nameof(WashingProgram))]
    public int ProgramId { get; set; }
    public WashingProgram WashingProgram { get; set; } = null!;   
    
    [Column(TypeName = "numeric")]
    [Precision(10,2)]
    public decimal Price { get; set; }
    
    public ICollection<PurchaseHistory> PurchaseHistories { get; set; } = new List<PurchaseHistory>();
}