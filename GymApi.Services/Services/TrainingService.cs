using AutoMapper;
using GymApi.Data.Data.Interfaces;
using GymApi.Domain;
using GymApi.Domain.Dto.Request;

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
    
    public async Task<Training> UpdateTraining(Guid id)
    {
        var training = await _contextTraining.FindById(id);
        await _contextTraining.Update(training);
        return training;
    }

    public async Task DeleteTrainingById(Guid id)
    {
        var training = await _contextTraining.FindById(id);
        _contextTraining.Delete(training);
    }
}