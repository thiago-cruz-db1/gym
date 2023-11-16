using MediatR;

namespace GymApi.UseCases.Dto.Request;

public class DeletePlanCommand : IRequest<string>
{
	public Guid Id { get; set; }
}