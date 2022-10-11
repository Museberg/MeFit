using Infrastructure.DTOs.User;
using Infrastructure.Models.Domain;
using Profile = AutoMapper.Profile;

namespace Infrastructure.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserReadDTO>();
            CreateMap<UserCreateDTO, User>();
            CreateMap<UserEditDTO, User>();
        }
    }
}
