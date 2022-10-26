using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infrastructure.Models.Domain;

public class Workout
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int WorkoutId { get; set; }

    [MaxLength(30)]
    public string Name { get; set; }

    // Relations
    public ICollection<Exercise> Exercises { get; set; }
    public ICollection<Program> Programs { get; set; }
    public User Contributor { get; set; }
}