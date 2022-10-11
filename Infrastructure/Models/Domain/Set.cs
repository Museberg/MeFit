using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infrastructure.Models.Domain;

public class Set
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int SetId { get; set; }

    public int ExerciseRepetitions { get; set; }
    
    // Relations
    public Exercise Exercise { get; set; }
}