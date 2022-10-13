
using Infrastructure.DTOs.Workout;
using Infrastructure.Models.Domain;
using Profile = AutoMapper.Profile;

namespace Infrastructure.Profiles
{
    public class WorkoutProfile : Profile
    {
        public WorkoutProfile()
        {
            CreateMap<Workout, WorkoutReadDTO>();
            CreateMap<WorkoutCreateDTO, Workout>();
            CreateMap<WorkoutEditDTO, Workout>();
        }
    }
}
