namespace Infrastructure.DTOs.User
{
    public class UserReadDTO
    {
        /// <summary>
        /// Primary key if user.
        /// </summary>
        /// <example>6e5fb16a-cbb2-4c01-a223-7e4035a91757</example>
        public int UserId { get; set; }
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
    }
}