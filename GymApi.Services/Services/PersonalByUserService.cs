using AutoMapper;
using GymApi.Data.Data.Interfaces;
using GymApi.Domain;
using GymApi.Domain.Enum;
using GymApi.UseCases.Dto.Request;

namespace GymApi.UseCases.Services;

public class PersonalByUserService
{
    private readonly IMapper _mapper;
    private readonly IPersonalByUserRepositorySql _personalByUserRepositorySql;

    public PersonalByUserService(IMapper mapper, IPersonalByUserRepositorySql personalByUserRepositorySql)
    {
        _mapper = mapper;
        _personalByUserRepositorySql = personalByUserRepositorySql;
    }
    public async Task<PersonalByUser> AddPersonalByUser(CreatePersonalByUserRequest personalByUserDto)
    {
        var personalByUser = _mapper.Map<PersonalByUser>(personalByUserDto);
        var isDuplicatePersonal = _personalByUserRepositorySql.IsDuplicatePersonalOnSameTime(personalByUser);
        if (isDuplicatePersonal) throw new Exception("you cannot have two personal in same time");
        var isDuplicateClient = _personalByUserRepositorySql.IsDuplicateClientOnSameTime(personalByUser);
        if (isDuplicateClient) throw new Exception("Personal is not avalible in this time");
        var isFree = _personalByUserRepositorySql.IsOpenToNewClient(personalByUser);
        if (!isFree) throw new Exception($"Personal does not have any time to traine you, he has only" +
                                         $"{(double)HoursDayPersonal.EightHours - personalByUser.DiffPersonalHours} minutes.");
        await _personalByUserRepositorySql.Save(personalByUser);
        await _personalByUserRepositorySql.SaveChange();
        return personalByUser;
    }

    public async Task<ICollection<PersonalByUser>> GetPersonalByUser()
    {
        return await _personalByUserRepositorySql.FindAll();
    }

    public async Task<PersonalByUser> GetPersonalByUserById(Guid id)
    {
        return await _personalByUserRepositorySql.FindById(id);
    }

    public async Task<PersonalByUser> UpdatePersonalByUserById(Guid id, UpdatePersonalByUserRequest updatePersonalByUserDto)
    {
        var personalByUser = await _personalByUserRepositorySql.FindById(id);
        if (personalByUser == null) throw new ApplicationException("personalByUser not found");
        _mapper.Map(updatePersonalByUserDto, personalByUser);
        await _personalByUserRepositorySql.Update(personalByUser);
        await _personalByUserRepositorySql.SaveChange();
        return personalByUser;
    }

    public async Task DeletePersonalByUserById(Guid id)
    {
        var personalByUser = await _personalByUserRepositorySql.FindById(id);
        _personalByUserRepositorySql.Delete(personalByUser);
        await _personalByUserRepositorySql.SaveChange();
    }
}