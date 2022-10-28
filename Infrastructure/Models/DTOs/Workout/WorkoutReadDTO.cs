using System.ComponentModel.DataAnnotations;
using Infrastructure.Models.Domain;

namespace Infrastructure.DTOs.Workout
{
    public class WorkoutReadDTO
    {
        /// <summary>
        /// Primary key of workout
        /// <example></example>
        [Key]
        public int WorkoutId { get; set; }
        /// <summary>
        /// Has the workout been completed?
        /// </summary>
        /// <example>false</example>
        /// 
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<Exercise> Exercises { get; set; }
        public ICollection<Models.Domain.Program> Programs { get; set; }
    }
}