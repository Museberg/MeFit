using AutoMapper;
using Infrastructure.DTOs.Program;


namespace Infrastructure.Profiles
{
    public class ProgramProfile : Profile
    {
        public ProgramProfile()
        {
            CreateMap<Models.Domain.Program, ProgramReadDTO>();
            CreateMap<ProgramCreateDTO, Models.Domain.Program>();
            CreateMap<ProgramEditDTO, Models.Domain.Program>();
        }
    }
}