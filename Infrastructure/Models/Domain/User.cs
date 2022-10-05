using System.ComponentModel.DataAnnotations;

namespace Infrastructure.Models.Domain;

public class User
{
    [Key]
    public Guid UserId { get; set; }

    [MaxLength(50)]
    public string FirstName { get; set; }
    [MaxLength(50)]
    public string LastName { get; set; }
    public bool IsContributer { get; set; }
    public bool IsAdmin { get; set; }
    
    // Relations
    public Address Address { get; set; }
    
}