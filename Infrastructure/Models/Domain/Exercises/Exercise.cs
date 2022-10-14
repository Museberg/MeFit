using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Infrastructure.Models.Domain.Exercises;

namespace Infrastructure.Models.Domain;

public class Exercise
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int ExerciseId { get; set; }

    [MaxLength(100)]
    public string Name { get; set; }
    [MaxLength(2048)]
    public string Description { get; set; }
    public ICollection<MuscleEnum> MuscleGroups { get; set; }
    [Url]
    public string ImageLink { get; set; }
    [Url]
    public string VideoLink { get; set; }
    public IEnumerable<Workout> Workouts { get; set; }
    
    // Different exercise types
    public ExerciseTypeEnum Type { get; set; }
    public double DistanceInKm { get; set; } // Used for cardio exercises
    public int Repetitions { get; set; } // Used for muscle workouts
    public double Seconds { get; set; } // Used for timed exercises, think planking and such
    
}