namespace Infrastructure.Models.DTOs.Program
{
    public class ProgramEditDTO
    {
        /// <summary>
        /// Name of program.
        /// </summary>
        /// <example>Upper body class</example>
        public string Name { get; set; }
        /// <summary>
        /// Program category.
        /// </summary>
        /// <example></example>
        public string Description { get; set; }
        public ICollection<Models.Domain.Workout> Workouts { get; set; }
    }
}