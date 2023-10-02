using AutoMapper;
using GymApi.Domain;
using GymApi.UseCases.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace GymApi.UseCases.Services;

public class TicketGateService : ITicketGate
{
    private readonly CreateUserService _createUserService;
    private List<string> ValidUsers { get; set; } = new();

    public TicketGateService(CreateUserService createUserService)
    {
        _createUserService = createUserService;
    }

    public async Task<List<string>> UpdateTicketGate()
    {
        Console.WriteLine("on service job");
        var users = await _createUserService.GetUsers();
        var idList = users.Select(e => e.Id).ToList();
        ValidUsers.AddRange(idList);
        return ValidUsers;
    }

    public bool VerifyIfValid(string id)
    {
        return ValidUsers.Any(e => e.Contains(id));
    }
}