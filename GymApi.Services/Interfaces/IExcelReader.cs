using GymApi.Domain;

namespace GymApi.UseCases.Interfaces;

public interface IExcelReader
{
	Task<IEnumerable<Exercise>> ReadExercises(Stream fileStream);
}