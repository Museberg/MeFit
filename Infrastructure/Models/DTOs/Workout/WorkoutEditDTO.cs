using System.ComponentModel.DataAnnotations;

namespace Infrastructure.DTOs.Workout
{
    public class WorkoutEditDTO
    {
        public int WorkoutId { get; set; }
        /// <summary>
        /// Has the workout been completed?
        /// </summary>
        /// <example>false</example>
        public bool IsCompleted { get; set; }
        public int ExerciseRepetitions { get; set; }
        public IEnumerable<Models.Domain.Exercise> Exercises { get; set; }
    }
}
