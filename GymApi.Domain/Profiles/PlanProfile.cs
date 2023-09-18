using AutoMapper;
using GymApi.Domain.Dto.Request;
using GymApi.Domain.Dto.Response;

namespace GymApi.Domain.Profiles
{
    public class PlanProfile : Profile
    {
        public PlanProfile()
        {
            CreateMap<AddPlanRequest, Plan>();
            CreateMap<GetPlanResponse, Plan>();
        }
    }
}
