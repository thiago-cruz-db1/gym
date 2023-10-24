using AutoMapper;
using GymApi.Domain;
using GymApi.UseCases.Dto.Request;

namespace GymApi.UseCases.Profiles;

public class PersonalByUserProfile : Profile
{
    public PersonalByUserProfile()
    {
        CreateMap<CreatePersonalByUserRequest, PersonalByUser>();
        CreateMap<UpdatePersonalByUserRequest, PersonalByUser>();
    }
}