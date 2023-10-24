using AutoMapper;
using GymApi.Domain;
using GymApi.UseCases.Dto.Request;

namespace GymApi.UseCases.Profiles;

public class ExerciseProfile : Profile
{
    public ExerciseProfile()
    {
        CreateMap<CreateExerciseRequest, Exercise>();
        CreateMap<UpdateExerciseRequest, Exercise>();
    }
}