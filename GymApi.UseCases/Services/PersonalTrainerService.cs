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

    public PersonalTrainer AddPersonalTrainer(AddPersonalTrainerRequest personalTrainerDto)
    {
        var personalTrainer = _mapper.Map<PersonalTrainer>(personalTrainerDto);
        _personalTrainerContext.Save(personalTrainer);
        return personalTrainer;
    }

    public async  Task<ICollection<PersonalTrainer>> GetPersonalTrainers()
    {
        return await _personalTrainerContext.FindAll();
    }

    public Task<PersonalTrainer> GetPersonalTrainerById(Guid id)
    {
        return _personalTrainerContext.FindById(id);
    }
    
    public async Task<PersonalTrainer> UpdatePernalById(Guid id)
    {
        var personal = await _personalTrainerContext.FindById(id);
        await _personalTrainerContext.Update(personal);
        return personal;
    }

    public async void DeletePersonalTrainerById(Guid id)
    {
        var personalTrainer = await _personalTrainerContext.FindById(id);
        if (personalTrainer == null) throw new Exception("Personal is null");

        _personalTrainerContext.Delete(personalTrainer);
    }
}