namespace Infrastructure.Models.DTOs.User
{
    public class UserReadDTO
    {
        /// <summary>
        /// Primary key if user.
        /// </summary>
        /// <example>2</example>
        public string UserId { get; set; }
        /// <summary>
        /// User key at Keycloak database.
        /// </summary>
        /// <example>6e5fb16a-cbb2-4c01-a223-7e4035a91757</example>
        public Guid KeycloakId { get; set; }
        public string Email { get; set; }
        /// <summary>
        /// Firsname of user.
        /// </summary>
        /// <example>Sven</example>
        public string FirstName { get; set; }
        /// <summary>
        /// Lastname of user.
        /// </summary>
        /// <example>Larson</example>
        public string LastName { get; set; }
        /// <summary>
        /// Prfofile associated with user
        /// </summary>
        /// <example></example>
        public Models.Domain.Profile Profile { get; set; }
        public ICollection<Models.Domain.Workout> workoutsContributed { get; set; }
        public ICollection<Models.Domain.Exercise> exercisesContributed { get; set; }
        public ICollection<Models.Domain.Program> programsContributed { get; set; }
        public ICollection<Models.Domain.Goal> userGoals { get; set; }
    }
}