using Infrastructure.Models.Domain;
using System.ComponentModel.DataAnnotations;
using Infrastructure.Models.Domain.Exercises;

namespace Infrastructure.Models.DTOs.Exercises.ExerciseCreateDTO
{
    public class ExerciseCreateDTO
    {
        /// <summary>
        /// Name of exercise.
        /// </summary>
        /// <example>Pull-ups</example>
        [MaxLength(100)]
        public string Name { get; set; }
        /// <summary>
        /// Description of exercise.
        /// </summary>
        /// <example>
        /// A pull-up is an upper-body strength exercise. 
        /// The pull-up is a closed-chain movement where the body is suspended by the hands, 
        /// gripping a bar or other implement at a distance typically wider than shoulder-width, and pulled up.
        /// </example>
        [MaxLength(2048)]
        public string Description { get; set; }
        /// <summary>
        /// The target muscle group of the exercise.
        /// </summary>
        /// <example>Biceps and upper back</example>
        public IEnumerable<MuscleEnum> MuscleGroups { get; set; }
        /// <summary>
        /// Link to exercise image.
        /// </summary>
        /// <example>Insert URL</example>
        [Url]
        public string ImageLink { get; set; }
        /// <summary>
        /// Link to exercise video.
        /// </summary>
        /// <example>Insert Url</example>
        [Url]
        public string VideoLink { get; set; }
        
        // Different exercise types
        public ExerciseTypeEnum Type { get; set; }
        public double? DistanceInKm { get; set; } // Used for cardio exercises
        public int? Repetitions { get; set; } // Used for muscle workouts
        public double? Seconds { get; set; } // Used for timed exercises, think planking and such
        
        
    }
}