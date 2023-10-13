using ExcelDataReader;
using GymApi.Domain;
using GymApi.UseCases.Interfaces;

namespace GymApi.UseCases.Services;

public class ExcelDataReaderService : IExcelReader
{
	public async Task<IEnumerable<Exercise>> ReadExercises(Stream fileStream)
	{
		var exercises = new List<Exercise>();

		using var reader = ExcelReaderFactory.CreateReader(fileStream);
		try
		{
			do
			{
				var isHeaderSkip = false;
				while (reader.Read())
				{
					if (!isHeaderSkip)
					{
						isHeaderSkip = true;
						continue;
					}

					var exercise = new Exercise
					{
						Machine = reader.GetValue(0).ToString()!,
						Pause = Convert.ToInt32(reader.GetValue(1)),
						Set = Convert.ToInt32(reader.GetValue(2)),
						Repetition = Convert.ToInt32(reader.GetValue(3)),
						Technique = reader.GetValue(4).ToString()!
					};

					exercises.Add(exercise);
				}
			} while (reader.NextResult());
		}
		catch (Exception e)
		{
			throw new Exception("Error on format of excel data.");
		}

		return exercises;
	}
}