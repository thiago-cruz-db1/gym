using AutoMapper;
using GymApi.Data.Data.Interfaces;
using GymApi.Data.Data.Validator;
using GymApi.Data.Data.Validator.Interfaces;
using GymApi.Domain;
using GymApi.UseCases.Dto.Request;

namespace GymApi.UseCases.Services;

public class TrainingByUserService : AbstractTrainingByUserValidator
{
    private readonly IMapper _mapper;
    private readonly ITrainingByUserRepositorySql _contextTrainingByUser;

    public TrainingByUserService(ITrainingByUserRepositorySql contextTrainingByUser,IMapper mapper, IValidatorTrainingByUser validatorTrainingByUser) :base(validatorTrainingByUser)
    {
        _contextTrainingByUser = contextTrainingByUser;
        _mapper = mapper;
    }
    public async Task<TrainingUser> AddTrainingUser(CreateTrainingByUserRequest trainingUserDto)
    {
	    var validDay = await CorrectDayOfTrainingByUserId(trainingUserDto.UserId);
	    if (validDay)
	    {
		    var training = _mapper.Map<TrainingUser>(trainingUserDto);
		    training.Validate();
		    await _contextTrainingByUser.Save(training);
		    await _contextTrainingByUser.SaveChange();
		    return training;
	    }
	    throw new Exception("day is not able to be a trainee for this user");
    }

    public async Task<ICollection<TrainingUser>> GetTrainingUser()
    {
        return await _contextTrainingByUser.FindAll();
    }

    public async Task<TrainingUser> GetTrainingUserById(Guid id)
    {
        return await _contextTrainingByUser.FindById(id);
    }

    public async Task<TrainingUser> UpdateTrainingUser(Guid id, UpdateTrainingByUserRequest updateTrainingDto)
    {
        var trainingByUser = await _contextTrainingByUser.FindById(id);
        if (trainingByUser == null) throw new ApplicationException("trainingByUser not found");
        var tr =_mapper.Map(updateTrainingDto, trainingByUser);
        tr.Validate();
        await _contextTrainingByUser.Update(trainingByUser);
        await _contextTrainingByUser.SaveChange();
        return trainingByUser;
    }

    public async Task DeleteTrainingUserById(Guid id)
    {
        var training = await _contextTrainingByUser.FindById(id);
        _contextTrainingByUser.Delete(training);
        await _contextTrainingByUser.SaveChange();
    }
}