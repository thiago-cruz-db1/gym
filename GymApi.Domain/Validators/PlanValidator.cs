using System.ComponentModel.DataAnnotations;
using FluentValidation;

namespace GymApi.Domain.Validators;

public class PlanValidator : AbstractValidator<Plan>, IValidator<Plan>
{

		public PlanValidator()
		{
			RuleFor(expense => expense.Amount)
				.GreaterThan(0).WithMessage("Amount must be greater than 0.");

			RuleFor(expense => expense.Category)
				.NotEmpty().WithMessage("Category is required.")
				.MaximumLength(50).WithMessage("Category must not exceed 50 characters.");

			RuleFor(expense => expense.TotalMonths)
				.GreaterThan(0).WithMessage("TotalMonths must be greater than 0.");

			RuleFor(expense => expense.DayOfWeeks)
				.NotEmpty().WithMessage("DayOfWeeks is required.")
				.Must(BeValidDaysOfWeek).WithMessage("Invalid DaysOfWeek format. Use a comma-separated list (e.g., 'Mon,Tue,Wed').");
		}

		private bool BeValidDaysOfWeek(string dayOfWeeks)
		{
			if (string.IsNullOrWhiteSpace(dayOfWeeks))
				return false;

			var validDays = new[] { "1", "2", "3", "4", "5", "6", "7" };

			var days = dayOfWeeks.Split(',');

			return days.All(day => validDays.Contains(day.Trim()));
		}
}