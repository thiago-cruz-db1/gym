using AutoMapper;
using GymApi.Data.Data.Interfaces;
using GymApi.Domain;
using GymApi.Domain.Enum;
using GymApi.UseCases.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace GymApi.UseCases.Services;

public class TicketGateService : ITicketGate
{
    private readonly ICreateUserRepositorySql _createUserRepository;
    private readonly IPlanRepositorySql _planRepository;
    
    private List<string> ValidUsers { get; set; } = new();

    public TicketGateService(ICreateUserRepositorySql createUserService, IPlanRepositorySql planRepository)
    {
        _createUserRepository = createUserService;
        _planRepository = planRepository;
    }

    public List<string> UpdateTicketGate()
    {
        Console.WriteLine("on service job");
        var users = _createUserRepository.GetUsers();
        var idList = users.Select(e => e.Id).ToList();
        ValidUsers.AddRange(idList);
        return ValidUsers;
    }

    public bool VerifyIfValid(string id)
    {
        throw new NotImplementedException();
    }
}