using GymApi.Domain.Enum;

namespace GymApi.UseCases.Dto.Request
{
    public class CreatePlanRequest
    {
        public double Amount { get; set; }
        public string Category { get; set; }
        public int TotalMonths { get; set; }
        public ICollection<DayOfWeekEnum> DayOfWeeks { get; set; }
    }
}
