using AutoMapper;
using GymApi.Domain.Dto.Request;

namespace GymApi.Domain.Profiles;

public class ExerciseProfile : Profile
{
    public ExerciseProfile()
    {
        CreateMap<CreateExerciseRequest, Exercise>();   
        CreateMap<UpdateExerciseRequest, Exercise>();   
    }
}