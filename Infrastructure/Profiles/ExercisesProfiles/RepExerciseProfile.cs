using Infrastructure.Models.Domain.Exercises;
using Infrastructure.Models.DTOs.Exercises.ExerciseCreateDTO;
using Infrastructure.Models.DTOs.Exercises.ExerciseEditDTO;
using Infrastructure.Models.DTOs.Exercises.ExerciseReadDTO;

namespace Infrastructure.Profiles.ExercisesProfiles
{
    public class RepExerciseProfile : AutoMapper.Profile
    {
        public RepExerciseProfile()
        {
            CreateMap<RepExercise, RepExerciseReadDTO>();
            CreateMap<RepExerciseCreateDTO, RepExercise>();
            CreateMap<RepExerciseEditDTO, RepExercise>();
        }
    }
}
