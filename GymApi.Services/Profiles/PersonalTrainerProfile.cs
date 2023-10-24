using AutoMapper;
using GymApi.Domain;
using GymApi.UseCases.Dto.Request;

namespace GymApi.UseCases.Profiles;

public class PersonalTrainerProfile : Profile
{
    public PersonalTrainerProfile()
    {
        CreateMap<CreatePersonalTrainerRequest, PersonalTrainer>();
        CreateMap<UpdatePersonalTrainerRequest, PersonalTrainer>();
    }
}