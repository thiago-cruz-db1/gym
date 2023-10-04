using AutoMapper;
using GymApi.Data.Data;
using GymApi.Data.Data.Interfaces;
using GymApi.Data.Data.MySql;
using GymApi.Domain;
using GymApi.Domain.Dto.Request;

namespace GymApi.UseCases.Services;

public class PersonalTrainerService
{
    private readonly IMapper _mapper;
    private readonly IPersonalTrainerRepositorySql _personalTrainerContext;

    public PersonalTrainerService(IPersonalTrainerRepositorySql personalTrainerContext, IMapper mapper)
    {
        _personalTrainerContext = personalTrainerContext;
        _mapper = mapper;
    }

    public async Task<PersonalTrainer> AddPersonalTrainer(CreatePersonalTrainerRequest personalTrainerDto)
    {
        var personalTrainer = _mapper.Map<PersonalTrainer>(personalTrainerDto);
        await _personalTrainerContext.Save(personalTrainer);
        return personalTrainer;
    }

    public async Task<ICollection<PersonalTrainer>> GetPersonalTrainers()
    {
        return await _personalTrainerContext.FindAll();
    }

    public async Task<PersonalTrainer> GetPersonalTrainerById(Guid id)
    {
        return await _personalTrainerContext.FindById(id);
    }
    
    public async Task<PersonalTrainer> UpdatePersonalById(Guid id, UpdatePersonalRequest updatePersonalDto)
    {
        var personal = await _personalTrainerContext.FindById(id);
        if (personal == null) throw new ApplicationException("personal not found");
        _mapper.Map(updatePersonalDto, personal); 
        await _personalTrainerContext.Update(personal);
        return personal;
    }

    public async Task DeletePersonalTrainerById(Guid id)
    {
        var personalTrainer = await _personalTrainerContext.FindById(id);
        if (personalTrainer == null) throw new Exception("Personal is null");

        _personalTrainerContext.Delete(personalTrainer);
    }
    
    public List<PersonalByUser> GetUsersTraineeByDay(Guid id, DateTime date)
    {
        return _personalTrainerContext.GetUsersTraineeByDay(id, date);
    }
}