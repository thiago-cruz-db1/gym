using AutoMapper;
using GymApi.Domain.Dto.Request;
using GymApi.Domain.Dto.Response;

namespace GymApi.Domain.Profiles;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<CreateUserRequest, User>();
        CreateMap<CreateUserResponse, User>().ReverseMap();
        CreateMap<UpdateUserRequest, User>();
    }   
}