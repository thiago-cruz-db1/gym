using AutoMapper;
using GymApi.Data.Data.Interfaces;
using GymApi.Data.Data.Validator;
using GymApi.Data.Data.Validator.Interfaces;
using GymApi.UseCases.Dto.Request;
using GymApi.UseCases.Notification;
using MediatR;

namespace GymApi.UseCases.Services.PlanHandler;

public class AddPlanCommandHandler : AbstractPlanValidator, IRequestHandler<CreatePlanCommand, string>
{
	private readonly IMapper _mapper;
	private readonly IPlanRepositorySql _contextPlan;
	private readonly IPlanRepositoryCache _cacheRepository;
	private readonly IMediator _mediator;
	public AddPlanCommandHandler(
		IMapper mapper,
		IPlanRepositorySql contextPlan,
		IPlanRepositoryCache cacheRepository,
		IValidatorPlan validatorPlan,
		IMediator mediator
		) : base(validatorPlan)
	{
		_mapper = mapper;
		_contextPlan = contextPlan;
		_cacheRepository = cacheRepository;
		_mediator = mediator;
	}
	public async Task<string> Handle(CreatePlanCommand request, CancellationToken cancellationToken)
	{
		var SET_COLLECTION = "PLANS";
		var duplicateName = await IsValidPlanName(request.Category);
		if (duplicateName) throw new Exception("plan with this name already exist");
		try
		{
			var plan = _mapper.Map<Domain.Plan>(request);
			plan.Validate();
			await _contextPlan.Save(plan);
			await _contextPlan.SaveChange();
			await _cacheRepository.AddToCollection(SET_COLLECTION, plan);

			return await Task.FromResult("Plan criado com sucesso");
		}
		catch (Exception ex)
		{
			await _mediator.Publish(new ErrorNotification { Exception = ex.Message, StackTracer = ex.StackTrace, Class = "AddPlanCommandHandler"}, cancellationToken);
			throw new Exception("Ocorreu um erro no momento da criação", ex);
		}
	}
}