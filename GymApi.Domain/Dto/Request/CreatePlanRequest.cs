namespace GymApi.Domain.Dto.Request
{
    public class CreatePlanRequest
    {
        public double Amount { get; set; }
        public string Category { get; set; }
        public int TotalMonths { get; set; } 
    }
}
