using AutoMapper;
using GymPlanApi.Model.Dto.Request;

namespace GymPlanApi.Model.Profiles
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
