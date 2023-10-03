using AutoMapper;
using GymApi.Data.Data.Interfaces;
using GymApi.Domain;
using GymApi.Domain.Dto.Request;

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
    public async Task<TicketGateUser> AddTicketGateUser(CreateTicketGateUsers createTicketGateDto)
    {
        var ticketGate = _mapper.Map<TicketGateUser>(createTicketGateDto);
        await _ticketGateUserRepositorySql.Save(ticketGate);
        return ticketGate;
    }

    public async Task<ICollection<TicketGateUser>> GetTicketGateUser()
    {
        return await _ticketGateUserRepositorySql.FindAll();
    }

    public async Task<TicketGateUser> GetTicketGateUserById(Guid id)
    {
        return await _ticketGateUserRepositorySql.FindById(id);
    }
    
    public async Task<TicketGateUser> UpdateTicketGateUserById(Guid id)
    {
        var ticketGate = await _ticketGateUserRepositorySql.FindById(id);
        await _ticketGateUserRepositorySql.Update(ticketGate);
        return ticketGate;
    }

    public async Task DeleteTicketGateUserById(Guid id)
    {
        var ticketGate = await _ticketGateUserRepositorySql.FindById(id);
        _ticketGateUserRepositorySql.Delete(ticketGate);
    }
}