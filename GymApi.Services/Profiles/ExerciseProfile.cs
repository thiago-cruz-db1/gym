using AutoMapper;
using GymApi.Domain;
using GymApi.UseCases.Dto.Request;

namespace GymApi.UseCases.Profiles;

public class ExerciseProfile : Profile
{
    public ExerciseProfile()
    {
        CreateMap<CreateExerciseRequest, Exercise>().ReverseMap();
        CreateMap<UpdateExerciseRequest, Exercise>().ReverseMap();
    }
}