using Infrastructure.DTOs.Goal;
using Infrastructure.Models.Domain;
using System.Globalization;

namespace Infrastructure.Profiles
{ 
    public class GoalProfile : AutoMapper.Profile
    {
        public GoalProfile()
        {
            var format = "dd/MM/yyyy";   
            
            CreateMap<Goal, GoalReadDTO>()
                .ForMember(dest => dest.StartingDate, opt => opt
                .MapFrom(src => src.StartingDate.ToString()))
                .ForMember(dest => dest.EndDate, opt => opt
                .MapFrom(src => src.EndDate.ToString()));
            CreateMap<GoalCreateDTO, Goal>()
                .ForMember(dest => dest.StartingDate, opt => opt
                .MapFrom(src => DateOnly.ParseExact(src.StartingDate, format)))
                .ForMember(dest => dest.EndDate, opt => opt
                .MapFrom(src => DateOnly.ParseExact(src.EndDate, format)));
            CreateMap<GoalEditDTO, Goal>();
        }
    }
}