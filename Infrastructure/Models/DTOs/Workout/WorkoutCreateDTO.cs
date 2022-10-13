using System.ComponentModel.DataAnnotations;

namespace Infrastructure.DTOs.Workout
{
    public class WorkoutCreateDTO
    {
        public Guid WorkoutId { get; set; }
        /// <summary>
        /// Has the workout been completed?
        /// </summary>
        /// <example>false</example>
        public bool IsCompleted { get; set; }
        public int ExerciseRepetitions { get; set; }
        public Models.Domain.Program Program { get; set; }
    }
}
