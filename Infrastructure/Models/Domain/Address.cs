using System.ComponentModel.DataAnnotations;

namespace Infrastructure.Models.Domain;

public class Address
{
    [Key] 
    public Guid AddressId { get; set; }

    [MaxLength(100)]
    public string AddressLine1 { get; set; }
    [MaxLength(100)]
    public string AddressLine2 { get; set; }
    [MaxLength(100)]
    public string AddressLine3 { get; set; }

    [MaxLength(20)]
    public string PostalCode { get; set; }
    [MaxLength(100)]
    public string City { get; set; }
    [MaxLength(50)]
    public string Country { get; set; }
}