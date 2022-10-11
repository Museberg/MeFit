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
                // Extracting Name of from associated user.
                .ForMember(dest => dest.Program, opt => opt
                    .MapFrom(src => src.Program));
            CreateMap<GoalCreateDTO, Goal>();
            CreateMap<GoalEditDTO, Goal>();
        }
    }
}