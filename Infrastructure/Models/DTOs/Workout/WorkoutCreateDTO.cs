using System.ComponentModel.DataAnnotations;

namespace Infrastructure.DTOs.Workout
{
    public class WorkoutCreateDTO
    {
        /// <summary>
        /// Has the workout been completed?
        /// </summary>
        /// <example>false</example>
        public bool IsCompleted { get; set; }
        public int ExerciseRepetitions { get; set; }
        public int UserId { get; set; }
    }
}
