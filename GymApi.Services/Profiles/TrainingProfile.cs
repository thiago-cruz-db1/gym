using AutoMapper;
using GymApi.Domain;
using GymApi.UseCases.Dto.Request;

namespace GymApi.UseCases.Profiles;

public class TrainingProfile : Profile
{
    public TrainingProfile()
    {
        CreateMap<CreateTrainingRequest, Training>();
        CreateMap<UpdateTrainingRequest, Training>();
    }
}