using Infrastructure.DTOs.User;
using Infrastructure.Models.Domain;

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
