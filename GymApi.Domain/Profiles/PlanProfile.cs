using AutoMapper;
using GymApi.Domain.Dto.Request;
using GymApi.Domain.Dto.Response;

namespace GymApi.Domain.Profiles
{
    public class PlanProfile : Profile
    {
        public PlanProfile()
        {
            CreateMap<CreatePlanRequest, Plan>()
                .ForMember(dest => dest.DayOfWeeks, opt => opt.MapFrom(src => string.Join(", ", src.DayOfWeeks)));
            CreateMap<UpdatePlanRequest, Plan>()
                .ForMember(dest => dest.DayOfWeeks, opt => opt.MapFrom(src => string.Join(", ", src.DayOfWeeks)));
            CreateMap<GetPlanResponse, Plan>();
        }
    }
}
