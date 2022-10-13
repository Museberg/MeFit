namespace Infrastructure.Models.DTOs.Exercises.ExerciseEditDTO
{
    public class TimedExerciseEditDTO : ExerciseEditDTO
    {
        /// <summary>
        /// Time to perform exercise in seconds.
        /// </summary>
        /// <example>60</example>
        public double Seconds { get; set; }
    }
}
