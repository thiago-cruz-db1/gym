using AutoMapper;
using GymApi.Domain;
using GymApi.Domain.Dto.Response;
using GymApi.UseCases.Dto.Request;

namespace GymApi.UseCases.Profiles
{
    public class PlanProfile : Profile
    {
        public PlanProfile()
        {
            CreateMap<CreatePlanCommand, Plan>()
                .ForMember(dest => dest.DayOfWeeks, opt => opt.MapFrom(src => string.Join(", ", src.DayOfWeeks)));
            CreateMap<UpdatePlanCommand, Plan>()
                .ForMember(dest => dest.DayOfWeeks, opt => opt.MapFrom(src => string.Join(", ", src.DayOfWeeks)));
            CreateMap<GetPlanResponse, Plan>();
        }
    }
}
