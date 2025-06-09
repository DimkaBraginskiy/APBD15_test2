using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace apbd15_test2.Models;

[Table("Available_Program")]
public class AvailableProgram
{
    [Key]
    public int AvailableProgramId { get; set; }

    [ForeignKey(nameof(WashingMachine))]
    public int WashingMachineId { get; set; }
    public WashingMachine WashingMachine { get; set; }

    [ForeignKey(nameof(WashingProgram))]
    public int ProgramId { get; set; }
    public WashingProgram WashingProgram { get; set; }

    [Column(TypeName = "numeric")]
    [Precision(10,2)]
    public decimal Price { get; set; }
    
    public ICollection<PurchaseHistory> PurchaseHistories = new List<PurchaseHistory>();
    
}