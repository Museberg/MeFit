using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infrastructure.Models.Domain
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }
        public Guid KeycloakId { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        [MaxLength(50)]
        public string FirstName { get; set; }
        [MaxLength(50)]
        public string LastName { get; set; }
        public Profile Profile { get; set; }
        public ICollection<Workout> workoutsContributed { get; set; }
        public ICollection<Exercise> exercisesContributed { get; set; }
        public ICollection<Program> programsContributed { get; set; }
        public ICollection<Goal> userGoals { get; set; }
    }
}