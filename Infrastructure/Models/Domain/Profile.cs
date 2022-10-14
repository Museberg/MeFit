using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infrastructure.Models.Domain;

public class Profile
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int ProfileId { get; set; }
    public double Weight { get; set; }
    public double Height { get; set; }
    [MaxLength(100)]
    public string? MedicalConditions { get; set; }
    [MaxLength(100)]
    public string? Disabilities { get; set; }
    
    // Relations
    public IEnumerable<Goal> Goals { get; set; }
    public User User { get; set; }
    public int UserId { get; set; }
}