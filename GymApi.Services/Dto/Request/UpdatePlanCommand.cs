using GymApi.Domain.Enum;
using MediatR;

namespace GymApi.UseCases.Dto.Request;

public class UpdatePlanCommand : IRequest<string>
{
	public Guid Id { get; set; }
    public double? Amount { get; set; }
    public string? Category { get; set; }
    public int? TotalMonths { get; set; }
    public ICollection<DayOfWeekEnum>? DayOfWeeks { get; set; }
}