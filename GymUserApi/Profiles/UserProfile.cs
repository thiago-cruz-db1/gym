using AutoMapper;
using GymUserApi.Model;

namespace GymUserApi.Profiles;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<CreateLoginUserRequest, User>();
    }   
}