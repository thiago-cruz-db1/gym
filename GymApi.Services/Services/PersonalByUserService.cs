using AutoMapper;
using GymApi.Data.Data.Interfaces;
using GymApi.Domain;
using GymApi.Domain.Dto.Request;

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
    public async Task<PersonalByUser> AddPersonalByUser(CreatePersonalByUserRequest planDto)
    {
        var personalByUser = _mapper.Map<PersonalByUser>(planDto);
        await _personalByUserRepositorySql.Save(personalByUser);
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
    
    public async Task<PersonalByUser> UpdatePersonalByUserById(Guid id)
    {
        var personalByUser = await _personalByUserRepositorySql.FindById(id);
        await _personalByUserRepositorySql.Update(personalByUser);
        return personalByUser;
    }

    public async Task DeletePersonalByUserById(Guid id)
    {
        var personalByUser = await _personalByUserRepositorySql.FindById(id);
        _personalByUserRepositorySql.Delete(personalByUser);
    }
}