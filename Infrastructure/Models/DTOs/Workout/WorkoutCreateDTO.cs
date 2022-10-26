using System.ComponentModel.DataAnnotations;

namespace Infrastructure.DTOs.Workout
{
    public class WorkoutCreateDTO
    {
        /// <summary>
        /// Has the workout been completed?
        /// </summary>
        /// <example>false</example>
        public string Name { get; set; }
    }
}
