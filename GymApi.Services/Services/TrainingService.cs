using AutoMapper;
using GymApi.Data.Data.Interfaces;
using GymApi.Data.Data.Validator;
using GymApi.Data.Data.Validator.Interfaces;
using GymApi.Domain;
using GymApi.UseCases.Dto.Request;

namespace GymApi.UseCases.Services;

public class TrainingService : AbstractTrainingValidator
{
    private readonly IMapper _mapper;
    private readonly ITrainingRepositorySql _contextTraining;

    public TrainingService(ITrainingRepositorySql contextTraining,IMapper mapper, IValidatorTraining validatorTraining) :base(validatorTraining)
    {
        _contextTraining = contextTraining;
        _mapper = mapper;
    }
    public async Task<Training> AddTraining(CreateTrainingRequest trainingDto)
    {
        var training = _mapper.Map<Training>(trainingDto);
        training.Validate();
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
        var tr = _mapper.Map(updateTrainingDto, training);
		tr.Validate();
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

    public bool ValidationExerciseExist(ICollection<Guid> ids)
    {
        return ValidationIfExerciseExist(ids);
    }
}