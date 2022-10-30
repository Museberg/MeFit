using Infrastructure.Models.Domain;
using Infrastructure.Models.DTOs.Exercises;

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