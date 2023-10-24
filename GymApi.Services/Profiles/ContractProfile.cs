using AutoMapper;
using GymApi.Domain;
using GymApi.UseCases.Dto.Request;

namespace GymApi.UseCases.Profiles;

public class ContractProfile : Profile
{
	public ContractProfile()
	{
		CreateMap<CreateContractRequest, Contract>();
	}
}