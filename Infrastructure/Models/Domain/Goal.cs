using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infrastructure.Models.Domain;

public class Goal
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int GoalId { get; set; }

    public DateOnly StartingDate { get; set; }
    public DateOnly EndDate { get; set; }
    public bool IsAchieved { get; set; }
    
    // Relations
    [Key, ForeignKey("ProgramId")]
    public Program Program { get; set; }
    [Key, ForeignKey("ProfileId")]
    public Profile Profile { get; set; }
}