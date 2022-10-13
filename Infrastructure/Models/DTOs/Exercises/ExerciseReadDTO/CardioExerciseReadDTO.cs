namespace Infrastructure.Models.DTOs.Exercises.ExerciseReadDTO
{
    public class CardioExerciseReadDTO : ExerciseReadDTO
    {
        /// <summary>
        /// Distance in km
        /// </summary>
        /// <example>10</example>
        public double DistanceInKm { get; set; }
    }
}
