using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infrastructure.Models.Domain;

public class Workout
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int WorkoutId { get; set; }

    [MaxLength(50)]
    public string Type { get; set; }
    public bool IsCompleted { get; set; }
    
    // Relations
    public Set Set { get; set; }
}