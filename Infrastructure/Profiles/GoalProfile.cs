﻿using Infrastructure.DTOs.Goal;
using Infrastructure.Models.Domain;
using System.Globalization;

namespace Infrastructure.Profiles
{ 
    public class GoalProfile : AutoMapper.Profile
    {
        public GoalProfile()
        {
            CreateMap<Goal, GoalReadDTO>()
                .ForMember(dest => dest.StartingDate, opt => opt
                .MapFrom(src => src.StartingDate.ToString()))
                .ForMember(dest => dest.EndDate, opt => opt
                .MapFrom(src => src.EndDate.ToString()));
            CreateMap<GoalCreateDTO, Goal>()
                .ForMember(dest => dest.StartingDate, opt => opt
                .MapFrom(src => DateOnly.Parse(src.StartingDate, new CultureInfo("en-GB"), DateTimeStyles.None)))
                .ForMember(dest => dest.EndDate, opt => opt
                .MapFrom(src => DateOnly.Parse(src.EndDate, new CultureInfo("en-GB"), DateTimeStyles.None)));
            CreateMap<GoalEditDTO, Goal>();
        }
    }
}