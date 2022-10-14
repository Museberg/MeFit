using System.ComponentModel.DataAnnotations;
using Infrastructure.Models.Domain;

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
        /// Has the workout been completed?
        /// </summary>
        /// <example>false</example>
        public bool IsCompleted { get; set; }
        public int ExerciseRepetitions { get; set; }
        public IEnumerable<Exercise> Exercises { get; set; }
        public IEnumerable<Models.Domain.Program> Programs { get; set; }
        public Models.Domain.User Contributor { get; set; }
    }
}