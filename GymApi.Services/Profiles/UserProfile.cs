using AutoMapper;
using GymApi.Domain;
using GymApi.Domain.Dto.Response;
using GymApi.UseCases.Dto.Request;

namespace GymApi.UseCases.Profiles;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<CreateUserRequest, User>();
        CreateMap<CreateUserResponse, User>();
        CreateMap<UpdateUserRequest, User>();
    }
}