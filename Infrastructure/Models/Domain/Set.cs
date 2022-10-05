using System.ComponentModel.DataAnnotations;

namespace Infrastructure.Models.Domain;

public class Set
{
    [Key]
    public Guid SetId { get; set; }

    public int ExerciseRepetitions { get; set; }
    
    // Relations
    public Exercise Exercise { get; set; }
}