using Infrastructure.Models.Domain;
using Infrastructure.Models.DTOs.User;

namespace Infrastructure.Profiles
{
    public class UserProfile : AutoMapper.Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserReadDTO>();
            CreateMap<UserCreateDTO, User>();
            CreateMap<UserEditDTO, User>();
        }
    }
}
