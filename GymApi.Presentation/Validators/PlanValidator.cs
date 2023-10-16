using System.ComponentModel.DataAnnotations;
using FluentValidation;
using GymApi.Domain.Dto.Request;
using GymApi.Domain.Enum;
using System.Linq;

namespace GymApi.Domain.Validators;

public class PlanValidator : AbstractValidator<CreatePlanRequest>
{

		public PlanValidator()
		{
			RuleFor(plan => plan.Amount)
				.GreaterThan(0).WithMessage("Amount must be greater than 0.");

			RuleFor(plan => plan.Category)
				.NotEmpty().WithMessage("Category is required.")
				.MaximumLength(100).WithMessage("Category must not exceed 100 characters.");

			RuleFor(plan => plan.TotalMonths)
				.GreaterThan(0).WithMessage("TotalMonths must be greater than 0.");

			RuleFor(plan => plan.DayOfWeeks)
				.NotEmpty().WithMessage("DayOfWeeks is required.")
				.Must(BeValidDaysOfWeek).WithMessage("Invalid DaysOfWeek collection.");
		}

		private bool BeValidDaysOfWeek(ICollection<DayOfWeekEnum>? dayOfWeeks)
		{
			if (dayOfWeeks is null || !dayOfWeeks.Any())
				return false;

			var validDays = System.Enum.GetValues(typeof(DayOfWeekEnum)).Cast<DayOfWeekEnum>();

			return dayOfWeeks.All(day => validDays.Contains(day));
		}
}