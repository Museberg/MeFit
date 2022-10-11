
using Infrastructure.DTOs.Workout;
using Infrastructure.Models.Domain;
using Profile = AutoMapper.Profile;

namespace Infrastructure.Profiles
{
    public class WorkoutProfile : Profile
    {
        public WorkoutProfile()
        {
            CreateMap<Workout, WorkoutReadDTO>()
                // Extracting Name of from assosiated user.
                .ForMember(dest => dest.Set, opt => opt
                    .MapFrom(src => src.Set.ExerciseRepetitions));
            CreateMap<WorkoutCreateDTO, Workout>();
            CreateMap<WorkoutEditDTO, Workout>();
        }
    }
}
