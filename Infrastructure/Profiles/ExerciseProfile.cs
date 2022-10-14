using Infrastructure.Models.Domain;
using Infrastructure.Models.DTOs.Exercises.ExerciseCreateDTO;
using Infrastructure.Models.DTOs.Exercises.ExerciseEditDTO;
using Infrastructure.Models.DTOs.Exercises.ExerciseReadDTO;

namespace Infrastructure.Profiles;

public class ExerciseProfile : AutoMapper.Profile
{
    public ExerciseProfile()
    {
        CreateMap<Exercise, ExerciseReadDTO>();
        CreateMap<ExerciseCreateDTO, Exercise>();
        CreateMap<ExerciseEditDTO, Exercise>();
    }
}