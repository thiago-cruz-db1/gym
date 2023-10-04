using AutoMapper;
using GymApi.Domain.Dto.Request;

namespace GymApi.Domain.Profiles;

public class ExerciseByTraining : Profile
{
    public ExerciseByTraining()
    {
        CreateMap<CreateExerciseByTrainingRequest, ExerciseByTraining>();  
        CreateMap<UpdateExerciseByTrainingRequest, ExerciseByTraining>();  
    }
}