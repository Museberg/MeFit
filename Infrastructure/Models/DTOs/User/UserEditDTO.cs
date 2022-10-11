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
        /// Contributor status.
        /// </summary>
        /// <exampl>true</exampl>
        public bool IsContributer { get; set; }
        /// <summary>
        /// Admin status.
        /// </summary>
        /// <example>false</example>
        public bool IsAdmin { get; set; }
    }
}
