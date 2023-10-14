using FluentValidation;
using FluentValidation.Results;

namespace GymApi.Domain.FluentValidator;

public class FluentValidatorWrapper<T> : IValidator<T>
{
	private readonly AbstractValidator<T> _validator;

	public FluentValidatorWrapper(AbstractValidator<T> validator)
	{
		_validator = validator ?? throw new ArgumentNullException(nameof(validator));
	}

	public ValidationResult Validate(T dto)
	{
		return _validator.Validate(dto);
	}
}