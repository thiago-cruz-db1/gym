using AutoMapper;
using GymApi.Domain.Dto.Request;

namespace GymApi.Domain.Profiles;

public class TicketGateUserProfile : Profile
{
    public TicketGateUserProfile()
    {
        CreateMap<CreateTicketGateUsersRequest, TicketGateUser>();
        CreateMap<UpdateTicketGateUsers, TicketGateUser>();
    }
}