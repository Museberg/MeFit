using Infrastructure.DTOs.Goal;
using Infrastructure.Models.Domain;
using System.Globalization;

namespace Infrastructure.Profiles
{ 
    public class GoalProfile : AutoMapper.Profile
    {
        public GoalProfile()
        {
            var format = "dd/mm/yyyy";

            CreateMap<Goal, GoalReadDTO>();
            CreateMap<GoalCreateDTO, Goal>();
            CreateMap<GoalEditDTO, Goal>();
        }
    }
}