using AutoMapper;
using GymApi.Data.Data;
using GymApi.Domain;
using GymApi.Domain.Dto.Request;

namespace GymApi.UseCases.Services;

public class PersonalTrainerService
{
    private readonly GymDbContext _context;
    private readonly IMapper _mapper;

    public PersonalTrainerService(GymDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public PersonalTrainer AddPersonalTrainer(AddPersonalTrainerRequest personalTrainerDto)
    {
        var personalTrainer = _mapper.Map<PersonalTrainer>(personalTrainerDto);
        _context.PersonalTrainers.Add(personalTrainer);
        _context.SaveChanges();
        return personalTrainer;
    }

    public List<PersonalTrainer> GetPersonalTrainers()
    {
        return _context.PersonalTrainers.ToList();
    }

    public PersonalTrainer GetPersonalTrainerById(Guid id)
    {
        return _context.PersonalTrainers.FirstOrDefault(pt => pt.Id == id);
    }

    public PersonalTrainer DeletePersonalTrainerById(Guid id)
    {
        var personalTrainer = _context.PersonalTrainers.FirstOrDefault(pt => pt.Id == id);
        if (personalTrainer == null) return null;

        _context.Remove(personalTrainer);
        _context.SaveChanges();
        return personalTrainer;
    }
}