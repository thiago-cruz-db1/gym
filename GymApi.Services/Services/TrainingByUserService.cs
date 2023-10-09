using AutoMapper;
using GymApi.Data.Data.Interfaces;
using GymApi.Domain;
using GymApi.Domain.Dto.Request;

namespace GymApi.UseCases.Services;

public class TrainingByUserService
{
    private readonly IMapper _mapper;
    private readonly ITrainingByUserRepositorySql _contextTrainingByUser;

    public TrainingByUserService(ITrainingByUserRepositorySql contextTrainingByUser,IMapper mapper)
    {
        _contextTrainingByUser = contextTrainingByUser;
        _mapper = mapper;
    }
    public async Task<TrainingUser> AddTrainingUser(CreateTrainingByUserRequest trainingUserDto)
    {
	    var validDay = await _contextTrainingByUser.CorrectDayOfTraining(trainingUserDto.UserId);
	    if (validDay)
	    {
		    var training = _mapper.Map<TrainingUser>(trainingUserDto);
		    await _contextTrainingByUser.Save(training);
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
        _mapper.Map(updateTrainingDto, trainingByUser);
        await _contextTrainingByUser.Update(trainingByUser);
        return trainingByUser;
    }

    public async Task DeleteTrainingUserById(Guid id)
    {
        var training = await _contextTrainingByUser.FindById(id);
        _contextTrainingByUser.Delete(training);
    }
}