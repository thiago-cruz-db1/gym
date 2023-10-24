using AutoMapper;
using GymApi.Domain;
using GymApi.UseCases.Dto.Request;

namespace GymApi.UseCases.Profiles;

public class TicketGateUserProfile : Profile
{
    public TicketGateUserProfile()
    {
        CreateMap<CreateTicketGateUsersRequest, TicketGateUser>();
        CreateMap<UpdateTicketGateUsers, TicketGateUser>();
    }
}