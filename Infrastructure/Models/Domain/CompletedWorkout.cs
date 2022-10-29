using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infrastructure.Models.Domain;

public class CompletedWorkout
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int CompletedWorkoutId { get; set; }
    
    public Workout Workout { get; set; }

    public Goal Goal { get; set; }
    
    
}