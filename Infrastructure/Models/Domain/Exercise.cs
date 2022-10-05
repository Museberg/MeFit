using System.ComponentModel.DataAnnotations;

namespace Infrastructure.Models.Domain;

public class Exercise
{
    [Key]
    public Guid Key { get; set; }

    [MaxLength(100)]
    public string Name { get; set; }
    [MaxLength(2048)]
    public string Description { get; set; }
    [MaxLength(100)]
    public string TargetMuscleGroup { get; set; }
    [MaxLength(512)]
    public string ImageLink { get; set; }
    [MaxLength(512)]
    public string VideoLink { get; set; }
}