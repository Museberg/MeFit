using Infrastructure.DTOs.Program;
using Profile = AutoMapper.Profile;
using Program1 = Infrastructure.Models.Domain.Program;

namespace Infrastructure.Profiles
{
    public class ProgramProfile : Profile
    {
        public ProgramProfile()
        {
            CreateMap<Program1, ProgramReadDTO>()
                // Extracting Name of from assosiated user.
                .ForMember(dest => dest.Workouts, opt => opt
                    .MapFrom(src => src.Workouts.Select(m => m.Type).ToArray()));
            CreateMap<ProgramCreateDTO, Program1>();
            CreateMap<ProgramEditDTO, Program1>();
        }
    }
}
