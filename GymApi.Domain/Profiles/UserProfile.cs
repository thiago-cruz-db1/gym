using AutoMapper;
using GymApi.Domain.Dto.Request;

namespace GymApi.Domain.Profiles;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<CreateLoginUserRequest, User>();
    }   
}