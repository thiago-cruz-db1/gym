using AutoMapper;
using GymApi.Domain.Dto.Request;

namespace GymApi.Domain.Profiles;

public class PersonalByUserProfile : Profile
{
    public PersonalByUserProfile()
    {
        CreateMap<CreatePersonalByUserRequest, PersonalByUser>();
    }
}