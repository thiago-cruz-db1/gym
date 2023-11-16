
using GymApi.Data.Data.Interfaces;
using GymApi.UseCases.Dto.Request;
using GymApi.UseCases.Notification;
using MediatR;

namespace GymApi.UseCases.Services.PlanHandler;

public class DeletePlanCommandHandler : IRequestHandler<DeletePlanCommand, string>
{
	private readonly IPlanRepositorySql _contextPlan;
	private readonly IMediator _mediator;

	public DeletePlanCommandHandler(IPlanRepositorySql contextPlan, IMediator mediator)
	{
		_contextPlan = contextPlan;
		_mediator = mediator;
	}

	public async Task<string> Handle(DeletePlanCommand request, CancellationToken cancellationToken)
	{
		try
		{
			var plan = await _contextPlan.FindById(request.Id);
			_contextPlan.Delete(plan);
			await _contextPlan.SaveChange();

			return await Task.FromResult("Plan criado com sucesso");
		}
		catch (Exception ex)
		{
			await _mediator.Publish(new ErrorNotification { Exception = ex.Message, StackTracer = ex.StackTrace, Class = "Plan" });
			return await Task.FromResult("Ocorreu um erro no momento da criação");
		}
	}
}