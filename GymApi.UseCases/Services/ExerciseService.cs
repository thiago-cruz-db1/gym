using AutoMapper;
using GymApi.Data.Data.Interfaces;
using GymApi.Domain;
using GymApi.Domain.Dto.Request;

namespace GymApi.UseCases.Services;

public class ExerciseService
{
    private readonly IMapper _mapper;
    private readonly IExerciseRepositorySql _contextExercise;

    public ExerciseService(IExerciseRepositorySql contextExercise,IMapper mapper)
    {
        _contextExercise = contextExercise;
        _mapper = mapper;
    }
    public ExerciseTraining AddExercise(CreateExerciseRequest trainingUserDto)
    {
        var training = _mapper.Map<ExerciseTraining>(trainingUserDto);
        _contextExercise.Save(training);
        return training;
    }

    public async Task<ICollection<ExerciseTraining>> GetExercise()
    {
        return await _contextExercise.FindAll();
    }

    public async Task<ExerciseTraining> GetExerciseById(Guid id)
    {
        return await _contextExercise.FindById(id);
    }
    
    public async Task<ExerciseTraining> UpdateExercise(Guid id)
    {
        var training = await _contextExercise.FindById(id);
        await _contextExercise.Update(training);
        return training;
    }

    public async void DeleteExerciseById(Guid id)
    {
        var training = await _contextExercise.FindById(id);
        _contextExercise.Delete(training);
    }
}