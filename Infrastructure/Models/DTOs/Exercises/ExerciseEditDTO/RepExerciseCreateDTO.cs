namespace Infrastructure.Models.DTOs.Exercises.ExerciseEditDTO
{
    public class RepExerciseEditDTO : ExerciseEditDTO
    {
        /// <summary>
        /// Repetitions of exercise
        /// </summary>
        /// <example>15</example>
        public int Repetitions { get; set; }
    }
}
