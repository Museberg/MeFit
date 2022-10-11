using Profile = AutoMapper.Profile;
using Infrastructure.DTOs.Goal;
using Infrastructure.Models.Domain;

namespace Infrastructure.Profiles
{ 
    public class GoalProfile : Profile
    {
        public GoalProfile()
        {
            CreateMap<Goal, GoalReadDTO>()
                // Extracting Name of from assosiated user.
                .ForMember(dest => dest.Programs, opt => opt
                    .MapFrom(src => src.Programs.Select(m => m.Name).ToArray()));
            CreateMap<GoalCreateDTO, Goal>();
            CreateMap<GoalEditDTO, Goal>();
        }
    }
}
