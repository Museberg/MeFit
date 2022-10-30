using Profile = Infrastructure.Models.Domain.Profile;
using Infrastructure.Models.Domain;
using Infrastructure.Models.DTOs.Profile;

namespace Infrastructure.Profiles
{
    public class ProfileProfile : AutoMapper.Profile
    {
        public ProfileProfile()
        {
            CreateMap<Profile, ProfileReadDTO>();
            CreateMap<ProfileCreateDTO, Profile>();
            CreateMap<ProfileEditDTO, Profile>();
        }
    }
}