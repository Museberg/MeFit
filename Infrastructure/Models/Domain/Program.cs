using System.ComponentModel.DataAnnotations;

namespace Infrastructure.Models.Domain;

public class Program
{
    [Key] 
    public Guid ProgramId { get; set; }

    public string Name { get; set; }
    public string Category { get; set; }
    
    // Relations
    public IEnumerable<Workout> Workouts { get; set; }
}