using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace apbd15_test2.Models;

[Table("Purchase_History")]
[PrimaryKey(nameof(AvailableProgramId), nameof(CustomerId))]
public class PurchaseHistory
{
    [ForeignKey(nameof(AvailableProgram))]
    public int AvailableProgramId { get; set; }
    public AvailableProgram AvailableProgram { get; set; } = null!;
    
    [ForeignKey(nameof(Customer))]
    public int CustomerId { get; set; }
    public Customer Customer { get; set; } = null!;
    
    public DateTime PurchaseDate { get; set; }
    
    public int? Rating { get; set; }
}