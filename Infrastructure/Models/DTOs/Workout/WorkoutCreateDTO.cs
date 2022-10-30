namespace Infrastructure.Models.DTOs.Workout
{
    public class WorkoutCreateDTO
    {
        /// <summary>
        /// Has the workout been completed?
        /// </summary>
        /// <example>false</example>
        public string Name { get; set; }
        public string Description { get; set; }
    }
}