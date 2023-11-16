using AutoMapper;
using GymApi.Data.Data.Interfaces;
using GymApi.Data.Data.Validator;
using GymApi.Data.Data.Validator.Interfaces;
using GymApi.UseCases.Dto.Request;
using GymApi.UseCases.Notification;
using MediatR;

namespace GymApi.UseCases.Services.PlanHandler;

public class UpdatePlanCommandHandler : AbstractPlanValidator, IRequestHandler<UpdatePlanCommand, string>
{
	private readonly IMapper _mapper;
	private readonly IPlanRepositorySql _contextPlan;
	private readonly IMediator _mediator;

	public UpdatePlanCommandHandler(IMapper mapper, IPlanRepositorySql contextPlan, IValidatorPlan validatorPlan, IMediator mediator) : base(validatorPlan)
	{
		_mapper = mapper;
		_mediator = mediator;
		_contextPlan = contextPlan;
	}

	public async Task<string> Handle(UpdatePlanCommand request, CancellationToken cancellationToken)
	{
		var duplicateName = await IsValidPlanName(request.Category);
		if (duplicateName) throw new Exception("plan with this name already exist");
		try
		{
			var plan = await _contextPlan.FindById(request.Id);
			if (plan == null) throw new ApplicationException("plan not found");
			var pl = _mapper.Map(request, plan);
			pl.Validate();
			await _contextPlan.Update(plan);
			await _contextPlan.SaveChange();

			return await Task.FromResult("Plan atualizado com sucesso");
		}
		catch (Exception ex)
		{
			await _mediator.Publish(new ErrorNotification { Exception = ex.Message, StackTracer = ex.StackTrace, Class = "Plan" });
			return await Task.FromResult("Ocorreu um erro no momento da criação");
		}
	}
}