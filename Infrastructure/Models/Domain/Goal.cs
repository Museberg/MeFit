using System.ComponentModel.DataAnnotations;

namespace Infrastructure.Models.Domain;

public class Goal
{
    [Key]
    public Guid GoalId { get; set; }

    public DateOnly StartingDate { get; set; }
    public DateOnly EndDate { get; set; }
    public bool IsAchieved { get; set; }
    
    // Relations
    public IEnumerable<Program> Programs { get; set; }

}