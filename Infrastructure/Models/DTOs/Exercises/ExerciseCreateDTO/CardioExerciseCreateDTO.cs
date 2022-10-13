namespace Infrastructure.Models.DTOs.Exercises.ExerciseCreateDTO
{
    public class CardioExerciseCreateDTO : ExerciseCreateDTO
    {
        /// <summary>
        /// Distance in km
        /// </summary>
        /// <example>10</example>
        public double DistanceInKm { get; set; }
    }
}
