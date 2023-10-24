using AutoMapper;
using GymApi.Domain;
using GymApi.UseCases.Dto.Request;

namespace GymApi.UseCases.Profiles;

public class TrainingUserProfile : Profile
{
    public TrainingUserProfile()
    {
        CreateMap<CreateTrainingByUserRequest, TrainingUser>()
            .ForMember(dest => dest.TrainingObservations, opt => opt.MapFrom(src => string.Join(", ", src.TrainingObservation)));
        CreateMap<UpdateTrainingByUserRequest, TrainingUser>()
            .ForMember(dest => dest.TrainingObservations, opt => opt.MapFrom(src => string.Join(", ", src.TrainingObservation)));

    }
}