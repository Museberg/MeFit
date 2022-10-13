using Infrastructure.DTOs.Goal;
using Infrastructure.Models.Domain;

namespace Infrastructure.Profiles
{ 
    public class GoalProfile : AutoMapper.Profile
    {
        public GoalProfile()
        {
            CreateMap<Goal, GoalReadDTO>();
            CreateMap<GoalCreateDTO, Goal>();
            CreateMap<GoalEditDTO, Goal>();
        }
    }
}