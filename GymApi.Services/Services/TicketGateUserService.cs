using AutoMapper;
using GymApi.Data.Data.Interfaces;
using GymApi.Domain;
using GymApi.Domain.Dto.Request;
using GymApi.Domain.Enum;

namespace GymApi.UseCases.Services;

public class TicketGateUserService 
{
    private readonly IMapper _mapper;
    private readonly ITicketGateUserRepositorySql _ticketGateUserRepositorySql;

    public TicketGateUserService(IMapper mapper, ITicketGateUserRepositorySql ticketGateUserRepositorySql)
    {
        _mapper = mapper;
        _ticketGateUserRepositorySql = ticketGateUserRepositorySql;
    }
    public async Task<bool> AddTicketGateUser(CreateTicketGateUsersRequest createTicketGateDto)
    {
        var ableToPass = await _ticketGateUserRepositorySql.AbleToPass(createTicketGateDto.UserId, createTicketGateDto.day);
        if (!ableToPass) return false;
        var ticketGate = _mapper.Map<TicketGateUser>(createTicketGateDto);
        await _ticketGateUserRepositorySql.Save(ticketGate);
        return true;
    }

    public async Task<ICollection<TicketGateUser>> GetTicketGateUser()
    {
        return await _ticketGateUserRepositorySql.FindAll();
    }

    public async Task<TicketGateUser> GetTicketGateUserById(Guid id)
    {
        return await _ticketGateUserRepositorySql.FindById(id);
    }
    
    public async Task<TicketGateUser> UpdateTicketGateUserById(Guid id, UpdateTicketGateUsers updateticketGateDto)
    {
        var ticketGate = await _ticketGateUserRepositorySql.FindById(id);
        if (ticketGate == null) throw new ApplicationException("ticketGate not found");
        _mapper.Map(updateticketGateDto, ticketGate); 
        await _ticketGateUserRepositorySql.Update(ticketGate);
        return ticketGate;
    }

    public async Task DeleteTicketGateUserById(Guid id)
    {
        var ticketGate = await _ticketGateUserRepositorySql.FindById(id);
        _ticketGateUserRepositorySql.Delete(ticketGate);
    }
}