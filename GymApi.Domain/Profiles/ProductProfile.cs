using AutoMapper;
using GymApi.Domain.Dto.Request;

namespace GymApi.Domain.Profiles;

public class ProductProfile : Profile
{
    public ProductProfile()
    {
        CreateMap<AddPersonalTrainerRequest, PersonalTrainer>();
    }
}