using GymApi.Domain.Enum;

namespace GymApi.Domain.Dto.Request;

public class UpdatePlanRequest
{
    public double? Amount { get; set; }
    public string? Category { get; set; }
    public int? TotalMonths { get; set; } 
    public ICollection<DayOfWeekEnum>? DayOfWeeks { get; set; }
}