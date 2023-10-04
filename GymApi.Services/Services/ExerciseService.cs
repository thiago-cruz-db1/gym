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
    public async Task<Exercise> AddExercise(CreateExerciseRequest exerciseDto)
    {
        var exercise = _mapper.Map<Exercise>(exerciseDto);
        await _contextExercise.Save(exercise);
        return exercise;
    }

    public async Task<ICollection<Exercise>> GetExercise()
    {
        return await _contextExercise.FindAll();
    }

    public async Task<Exercise> GetExerciseById(Guid id)
    {
        return await _contextExercise.FindById(id);
    }
    
    public async Task<Exercise> UpdateExercise(Guid id, UpdateExerciseRequest updateExerciseDto)
    {
        var exercise = await _contextExercise.FindById(id);
        if (exercise == null) throw new ApplicationException("exercise not found");
        _mapper.Map(updateExerciseDto, exercise); 
        await _contextExercise.Update(exercise);
        return exercise;
    }

    public async Task DeleteExerciseById(Guid id)
    {
        var training = await _contextExercise.FindById(id);
        _contextExercise.Delete(training);
    }
}