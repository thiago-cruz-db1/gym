using AutoMapper;
using GymApi.Domain.Dto.Request;
using GymApi.Domain.Dto.Response;

namespace GymApi.Domain.Profiles;

public class PersonalTrainerProfile : Profile
{
    public PersonalTrainerProfile()
    {
        CreateMap<CreatePersonalTrainerRequest, PersonalTrainer>();
        CreateMap<UpdatePersonalTrainerRequest, PersonalTrainer>();
    }
}