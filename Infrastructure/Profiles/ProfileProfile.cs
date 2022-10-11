using Infrastructure.DTOs.Profile;
using Profile = Infrastructure.Models.Domain.Profile;
using Infrastructure.Models.Domain;

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