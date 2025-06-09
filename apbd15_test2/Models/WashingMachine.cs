using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace apbd15_test2.Models;
[Table("Washing_Machine")]
public class WashingMachine
{
    [Key]
    public int WashingMachineId { get; set; }
    [Column(TypeName = "numeric")]
    [Precision(10,2)]
    public decimal MaxWeight { get; set; }
    [MaxLength(100)]
    public string SerialNumber { get; set; } = null!;

    public ICollection<AvailableProgram> AvailablePrograms = new List<AvailableProgram>();
}