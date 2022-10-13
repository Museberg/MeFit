using Infrastructure.Models.Domain.Exercises;
using Infrastructure.Models.DTOs.Exercises.ExerciseCreateDTO;
using Infrastructure.Models.DTOs.Exercises.ExerciseEditDTO;
using Infrastructure.Models.DTOs.Exercises.ExerciseReadDTO;

namespace Infrastructure.Profiles.ExercisesProfiles
{
    public class CardioExerciseProfile : AutoMapper.Profile
    {
        public CardioExerciseProfile()
        {
            CreateMap<CardioExercise, CardioExerciseReadDTO>();
            CreateMap<CardioExerciseCreateDTO, CardioExercise>();
            CreateMap<CardioExerciseEditDTO, CardioExercise>();
        }
    }
}
