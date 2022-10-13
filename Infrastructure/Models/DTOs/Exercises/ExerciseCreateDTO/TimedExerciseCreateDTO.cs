namespace Infrastructure.Models.DTOs.Exercises.ExerciseCreateDTO
{
    public class TimedExerciseCreateDTO : ExerciseCreateDTO
    {
        /// <summary>
        /// Time to perform exercise in seconds.
        /// </summary>
        /// <example>60</example>
        public double Seconds { get; set; }
    }
}
