using AutoMapper;
using GymApi.Data.Data.Interfaces;
using GymApi.Domain;
using GymApi.Domain.Dto.Request;

namespace GymApi.UseCases.Services;

public class ExerciseByTrainingService
{
    private readonly IExerciseByTrainingRepositorySql _contextExerciseByTraining;
    private readonly IMapper _mapper;

    public ExerciseByTrainingService(IExerciseByTrainingRepositorySql contextExerciseByTraining, IMapper mapper)
    {
        _contextExerciseByTraining = contextExerciseByTraining;
        _mapper = mapper;
    }

    public ExerciseTraining AddExerciseTraining(CreateExerciseByTrainingRequest ExerciseTrainingDto)
    {
        var training = _mapper.Map<ExerciseTraining>(ExerciseTrainingDto);
        _contextExerciseByTraining.Save(training);
        return training;
    }

    public async Task<ICollection<ExerciseTraining>> GetExerciseTraining()
    {
        return await _contextExerciseByTraining.FindAll();
    }

    public async Task<ExerciseTraining> GetExerciseTrainingById(Guid id)
    {
        return await _contextExerciseByTraining.FindById(id);
    }
    
    public async Task<ExerciseTraining> UpdateExerciseTraining(Guid id)
    {
        var training = await _contextExerciseByTraining.FindById(id);
        await _contextExerciseByTraining.Update(training);
        return training;
    }

    public async void DeleteExerciseTrainingById(Guid id)
    {
        var training = await _contextExerciseByTraining.FindById(id);
        _contextExerciseByTraining.Delete(training);
    }
}