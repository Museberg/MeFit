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
    public string MedicalConditions { get; set; }
    public string Disabilities { get; set; }
    
    // Relations
    public User User { get; set; }
    public IEnumerable<Goal> Goals { get; set; }
}