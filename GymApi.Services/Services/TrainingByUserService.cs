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
        var training = _mapper.Map<TrainingUser>(trainingUserDto);
        await _contextTrainingByUser.Save(training);
        return training;
    }

    public async Task<ICollection<TrainingUser>> GetTrainingUser()
    {
        return await _contextTrainingByUser.FindAll();
    }

    public async Task<TrainingUser> GetTrainingUserById(Guid id)
    {
        return await _contextTrainingByUser.FindById(id);
    }
    
    public async Task<TrainingUser> UpdateTrainingUser(Guid id)
    {
        var training = await _contextTrainingByUser.FindById(id);
        await _contextTrainingByUser.Update(training);
        return training;
    }

    public async Task DeleteTrainingUserById(Guid id)
    {
        var training = await _contextTrainingByUser.FindById(id);
        _contextTrainingByUser.Delete(training);
    }
}