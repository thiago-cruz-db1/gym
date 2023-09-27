using AutoMapper;
using GymApi.Domain.Dto.Request;

namespace GymApi.Domain.Profiles;

public class TrainingUserProfile : Profile
{
    public TrainingUserProfile()
    {
        CreateMap<CreateTrainingByUserRequest, TrainingUser>();
    }
}