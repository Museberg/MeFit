using System.ComponentModel.DataAnnotations;

namespace Infrastructure.DTOs.Program
{
    public class ProgramReadDTO
    {
        /// <summary>
        /// Primary key of program.
        /// </summary>
        /// <example></example>
        [Key]
        public int ProgramId { get; set; }
        /// <summary>
        /// Name of program.
        /// </summary>
        /// <example>Upper body class</example>
        public string Name { get; set; }
        /// <summary>
        /// Program category.
        /// </summary>
        /// <example></example>
        public string Category { get; set; }
        /// <summary>
        /// List of workout types assiated with program
        /// </summary>
        /// <example>[Pull-ups,Push-Ups]</example>
        public ICollection<string> Workouts { get; set; }
    }
}