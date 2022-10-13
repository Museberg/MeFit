namespace Infrastructure.Models.DTOs.Exercises.ExerciseReadDTO
{
    public class RepExerciseReadDTO : ExerciseReadDTO
    {
        /// <summary>
        /// Repetitions of exercise
        /// </summary>
        /// <example>15</example>
        public int Repetitions { get; set; }
    }
}
