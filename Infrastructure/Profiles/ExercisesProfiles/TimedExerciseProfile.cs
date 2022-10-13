using Infrastructure.Models.Domain.Exercises;
using Infrastructure.Models.DTOs.Exercises.ExerciseCreateDTO;
using Infrastructure.Models.DTOs.Exercises.ExerciseEditDTO;
using Infrastructure.Models.DTOs.Exercises.ExerciseReadDTO;

namespace Infrastructure.Profiles.ExercisesProfiles
{
    public class TimedExerciseProfile : AutoMapper.Profile
    {
        public TimedExerciseProfile()
        {
            CreateMap<TimedExercise, TimedExerciseReadDTO>();
            CreateMap<TimedExerciseCreateDTO, TimedExercise>();
            CreateMap<TimedExerciseEditDTO, TimedExercise>();
        }
    }
}
