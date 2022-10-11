using System.ComponentModel.DataAnnotations;

namespace Infrastructure.DTOs.Workout
{
    public class WorkoutReadDTO
    {
        /// <summary>
        /// Primary key of workout
        /// </summary>
        /// <example></example>
        [Key]
        public int WorkoutId { get; set; }
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
        /// <summary>
        /// Number of sets of exercise.
        /// </summary>
        /// <example></example>
        public int Set { get; set; }
    }
}