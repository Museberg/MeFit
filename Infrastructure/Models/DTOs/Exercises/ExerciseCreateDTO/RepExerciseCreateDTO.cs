namespace Infrastructure.Models.DTOs.Exercises.ExerciseCreateDTO
{
    public class RepExerciseCreateDTO : ExerciseCreateDTO
    {
        /// <summary>
        /// Repetitions of exercise
        /// </summary>
        /// <example>15</example>
        public int Repetitions { get; set; }
    }
}
