using AutoMapper;
using GymApi.Domain.Dto.Request;
using GymApi.Domain.Dto.Response;

namespace GymApi.Domain.Profiles;

public class TrainingProfile : Profile
{
    public TrainingProfile()
    {
        CreateMap<CreateTrainingRequest, Training>();
    }
}