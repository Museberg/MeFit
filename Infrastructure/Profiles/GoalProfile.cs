﻿using Infrastructure.Models.Domain;
using System.Globalization;
using Infrastructure.Models.DTOs.Goal;

namespace Infrastructure.Profiles
{ 
    public class GoalProfile : AutoMapper.Profile
    {
        public GoalProfile()
        {
            var format = "dd/mm/yyyy";   
            
            CreateMap<Goal, GoalReadDTO>()
                .ForMember(dest => dest.StartingDate, opt => opt
                .MapFrom(src => src.StartingDate.ToString()))
                .ForMember(dest => dest.EndDate, opt => opt
                .MapFrom(src => src.EndDate.ToString()));
            CreateMap<GoalCreateDTO, Goal>()
                .ForMember(dest => dest.StartingDate, opt => opt
                    .MapFrom(src => DateOnly.ParseExact(src.StartingDate, format)))
                .ForMember(dest => dest.EndDate, opt => opt
                    .MapFrom(src => DateOnly.ParseExact(src.EndDate, format)))
                .ForMember(dest => dest.Profile, opt => opt
                    .MapFrom(src => new Profile{ProfileId = src.ProfileId}))
                .ForMember(dest => dest.Program, opt => opt
                    .MapFrom(src => new Models.Domain.Program{ProgramId = src.ProgramId}))
                .ForMember(dest => dest.CompletedWorkouts, opt => opt
                    .MapFrom(src => new List<CompletedWorkout>()))
                .ForMember(dest => dest.Program, opt => opt
                    .MapFrom(src => new Models.Domain.Program()));
            CreateMap<GoalEditDTO, Goal>();
        }
    }
}