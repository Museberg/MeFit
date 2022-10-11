using AutoMapper;
using Infrastructure.DTOs.Program;


namespace Infrastructure.Profiles
{
    public class ProgramProfile : Profile
    {
        public ProgramProfile()
        {
            CreateMap<Models.Domain.Program, ProgramReadDTO>()
                // Extracting Name of from assosiated user.
                .ForMember(dest => dest.Workouts, opt => opt
                    .MapFrom(src => src.Workouts.Select(m => m.Type).ToArray()));
            CreateMap<ProgramCreateDTO, Models.Domain.Program>();
            CreateMap<ProgramEditDTO, Models.Domain.Program>();
        }
    }
}