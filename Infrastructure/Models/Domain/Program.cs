using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infrastructure.Models.Domain;

public class Program
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int ProgramId { get; set; }

    public string Name { get; set; }
    public string Category { get; set; }
    
    // Relations
    public IEnumerable<Workout> Workouts { get; set; }
}