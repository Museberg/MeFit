using Infrastructure.DTOs.Profile;
using Profile = Infrastructure.Models.Domain.Profile;
using Infrastructure.Models.Domain;

namespace Infrastructure.Profiles
{
    public class ProfileProfile : AutoMapper.Profile
    {
        public ProfileProfile()
        {
            CreateMap<Profile, ProfileReadDTO>()
                // Extracting Name of from assosiated user.
                .ForMember(dest => dest.User, opt => opt
                    .MapFrom(src => $"{src.User.FirstName} {src.User.LastName}".Single()));
            CreateMap<ProfileCreateDTO, Profile>();
            CreateMap<ProfileEditDTO, Profile>();
        }
    }
}
    