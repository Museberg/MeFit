using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infrastructure.Models.Domain;

public abstract class Exercise
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int ExerciseId { get; set; }

    [MaxLength(100)]
    public string Name { get; set; }
    [MaxLength(2048)]
    public string Description { get; set; }
    public MuscleEnum MuscleGroups { get; set; }
    [Url]
    public string ImageLink { get; set; }
    [Url]
    public string VideoLink { get; set; }
    public Workout Workout { get; set; }
}