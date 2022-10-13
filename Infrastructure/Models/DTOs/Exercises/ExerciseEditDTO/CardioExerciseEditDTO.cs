namespace Infrastructure.Models.DTOs.Exercises.ExerciseEditDTO
{
    public class CardioExerciseEditDTO : ExerciseEditDTO
    {
        /// <summary>
        /// Distance in km
        /// </summary>
        /// <example>10</example>
        public double DistanceInKm { get; set; }
    }
}
