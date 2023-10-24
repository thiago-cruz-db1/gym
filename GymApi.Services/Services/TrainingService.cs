using AutoMapper;
using GymApi.Data.Data.Interfaces;
using GymApi.Domain;
using GymApi.UseCases.Dto.Request;

namespace GymApi.UseCases.Services;

public class TrainingService
{
    private readonly IMapper _mapper;
    private readonly ITrainingRepositorySql _contextTraining;

    public TrainingService(ITrainingRepositorySql contextTraining,IMapper mapper)
    {
        _contextTraining = contextTraining;
        _mapper = mapper;
    }
    public async Task<Training> AddTraining(CreateTrainingRequest trainingDto)
    {
        var training = _mapper.Map<Training>(trainingDto);
        await _contextTraining.Save(training);
        await _contextTraining.SaveChange();
        return training;
    }

    public async Task<ICollection<Training>> GetTraining()
    {
        return await _contextTraining.FindAll();
    }

    public async Task<Training> GetTrainingById(Guid id)
    {
        return await _contextTraining.FindById(id);
    }

    public async Task<Training> UpdateTraining(Guid id, UpdateTrainingRequest updateTrainingDto)
    {
        var training = await _contextTraining.FindById(id);
        if (training == null) throw new ApplicationException("training not found");
        _mapper.Map(updateTrainingDto, training);
        await _contextTraining.Update(training);
        await _contextTraining.SaveChange();
        return training;
    }

    public async Task DeleteTrainingById(Guid id)
    {
        var training = await _contextTraining.FindById(id);
        _contextTraining.Delete(training);
        await _contextTraining.SaveChange();
    }

    public bool ValidationIfExerciseExist(ICollection<Guid> ids)
    {
        return _contextTraining.ValidationIfExerciseExist(ids);
    }
}