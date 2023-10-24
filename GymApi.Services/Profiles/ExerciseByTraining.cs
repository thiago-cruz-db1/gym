using AutoMapper;
using GymApi.UseCases.Dto.Request;

namespace GymApi.UseCases.Profiles;

public class ExerciseByTraining : Profile
{
    public ExerciseByTraining()
    {
        CreateMap<CreateExerciseByTrainingRequest, ExerciseByTraining>();
        CreateMap<UpdateExerciseByTrainingRequest, ExerciseByTraining>();
    }
}