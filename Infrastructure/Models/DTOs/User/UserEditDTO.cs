namespace Infrastructure.DTOs.User
{
    public class UserEditDTO
    {
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
        public string Email { get; set; }
        public Models.Domain.Profile Profile { get; set; }
    }
}