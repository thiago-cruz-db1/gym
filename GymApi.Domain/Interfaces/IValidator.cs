using ValidationResult = FluentValidation.Results.ValidationResult;

namespace GymApi.Domain;

public interface IValidator<T>
{
	ValidationResult Validate(T dto);
}