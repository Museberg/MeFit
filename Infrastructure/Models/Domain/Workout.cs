using System.ComponentModel.DataAnnotations;

namespace Infrastructure.Models.Domain;

public class Workout
{
    [Key]
    public Guid WorkoutId { get; set; }

    [MaxLength(50)]
    public string Type { get; set; }
    public bool IsCompleted { get; set; }
    
    // Relations
    public Set Set { get; set; }
}