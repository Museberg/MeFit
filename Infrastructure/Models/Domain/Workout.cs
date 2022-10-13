using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infrastructure.Models.Domain;

public class Workout
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int WorkoutId { get; set; }

    [MaxLength(50)]
    public bool IsCompleted { get; set; }
    public int ExerciseRepetitions { get; set; }

    // Relations
    [Key, ForeignKey("ExerciseId")]
    public Exercise Exercise { get; set; }
    public Program Program { get; set; }
}