using System.Collections.ObjectModel;
using AutoMapper;
using GymApi.Domain.Dto.Request;
using Microsoft.VisualBasic;

namespace GymApi.Domain.Profiles;

public class TrainingUserProfile : Profile
{
    public TrainingUserProfile()
    {
        CreateMap<CreateTrainingByUserRequest, TrainingUser>()
            .ForMember(dest => dest.TrainingObservations, opt => opt.MapFrom(src => string.Join(", ", src.TrainingObservation)));
    }
}