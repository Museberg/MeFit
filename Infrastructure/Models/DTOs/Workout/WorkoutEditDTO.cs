using System.ComponentModel.DataAnnotations;

namespace Infrastructure.DTOs.Workout
{
    public class WorkoutEditDTO
    {
        public Guid WorkoutId { get; set; }
        /// <summary>
        /// Type of workout
        /// </summary>
        /// <example>Pull-ups</example>
        [MaxLength(50)]
        public string Type { get; set; }
        /// <summary>
        /// Has the workout been completed?
        /// </summary>
        /// <example>false</example>
        public bool IsCompleted { get; set; }
    }
}
