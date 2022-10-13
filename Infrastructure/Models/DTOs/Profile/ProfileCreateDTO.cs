using System.ComponentModel.DataAnnotations;

namespace Infrastructure.DTOs.Profile
{
    public class ProfileCreateDTO
    {
        /// <summary>
        /// Primary key for user in Keycloak
        /// </summary>
        [Key]
        public int ProfileId { get; set; }
        /// <summary>
        /// Weight of user in [kg]
        /// </summary>
        /// <example>70</example>
        public double Weight { get; set; }
        /// <summary>
        /// Height of user in [m]
        /// </summary>
        /// <example>1.80</example>
        public double Height { get; set; }
        /// <summary>
        /// Medical conditions that user is experiencing
        /// </summary>
        /// <example>Pulled muscle</example>
        public string MedicalConditions { get; set; }
        /// <summary>
        /// Disabilities assositated with user
        /// </summary>
        /// <example>Spinal cord injury</example>
        public string Disabilities { get; set; }
        public Models.Domain.User User { get; set; }
    }
}