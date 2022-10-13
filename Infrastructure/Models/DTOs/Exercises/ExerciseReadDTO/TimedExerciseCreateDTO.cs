namespace Infrastructure.Models.DTOs.Exercises.ExerciseReadDTO
{
    public class TimedExerciseReadDTO : ExerciseReadDTO
    {
        /// <summary>
        /// Time to perform exercise in seconds.
        /// </summary>
        /// <example>60</example>
        public double Seconds { get; set; }
    }
}
