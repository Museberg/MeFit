using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.InteropServices;

namespace Infrastructure.Models.Domain;

public class Address
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int AddressId { get; set; }

    
    [MaxLength(100)]
    public string? AddressLine1 { get; set; }
    [MaxLength(100)]
    public string? AddressLine2 { get; set; }
    [MaxLength(100)]
    public string? AddressLine3 { get; set; }

    [MaxLength(20)]
    public string? PostalCode { get; set; }
    [MaxLength(100)]
    public string? City { get; set; }
    [MaxLength(50)]
    public string? Country { get; set; }
}