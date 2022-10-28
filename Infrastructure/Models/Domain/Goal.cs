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
    public ICollection<bool> IsAchieved { get; set; }
    public Program Program { get; set; }
    public User User { get; set; }
}