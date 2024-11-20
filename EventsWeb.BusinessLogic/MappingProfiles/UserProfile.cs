using AutoMapper;
using EventsWeb.BusinessLogic.Models.Users;

namespace EventsWeb.BusinessLogic.MappingProfiles
{
    public class UserProfile : Profile, IMappingProfile
    {
        public UserProfile() 
        {
            CreateMap<User, UserCreateResponseDto>();
            CreateMap<UserCreateDto, User>();
            CreateMap<UserLoginDto, User>();
        }
    }
}
