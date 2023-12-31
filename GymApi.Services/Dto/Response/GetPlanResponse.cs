﻿namespace GymApi.Domain.Dto.Response
{
    public class GetPlanResponse
    {
        public Guid Id { get; set; }
        public double Amount { get; set; }
        public string Category { get; set; }
        public int TotalMonths { get; set; }
        public DateTime create_at { get; set; } = DateTime.Now;
    }
}
