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
    public ICollection<Workout> Workouts { get; set; }
    public Goal Goal { get; set; }
    public User Contributor { get; set; }
}
