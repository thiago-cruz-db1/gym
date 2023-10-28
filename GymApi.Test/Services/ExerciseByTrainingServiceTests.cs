using AutoMapper;
using GymApi.Data.Data.Interfaces;
using GymApi.Domain;
using GymApi.UseCases.Dto.Request;
using GymApi.UseCases.Services;
using Moq;
using Xunit;

namespace GymApi.Test.Services;

public class ExerciseByTrainingServiceTests
{
	[Fact]
	public async Task AddExerciseTraining_WithValidRequest_ShouldAddTraining()
	{
		// Arrange
		var exerciseByTrainingRepositorySqlMock = new Mock<IExerciseByTrainingRepositorySql>();
		var mapperMock = new Mock<IMapper>();

		var service = new ExerciseByTrainingService(exerciseByTrainingRepositorySqlMock.Object, mapperMock.Object);
		var createExerciseByTrainingRequest = new CreateExerciseByTrainingRequest();
		var exerciseTraining = new ExerciseTraining();

		mapperMock.Setup(mapper => mapper.Map<ExerciseTraining>(createExerciseByTrainingRequest)).Returns(exerciseTraining);
		exerciseByTrainingRepositorySqlMock.Setup(repo => repo.Save(exerciseTraining));
		exerciseByTrainingRepositorySqlMock.Setup(repo => repo.SaveChange());

		// Act
		var result = await service.AddExerciseTraining(createExerciseByTrainingRequest);

		// Assert
		Assert.Same(exerciseTraining, result);
	}

	[Fact]
	public async Task GetExerciseTraining_ShouldReturnCollectionOfTrainings()
	{
		// Arrange
		var exerciseByTrainingRepositorySqlMock = new Mock<IExerciseByTrainingRepositorySql>();
		var mapperMock = new Mock<IMapper>();

		var service = new ExerciseByTrainingService(exerciseByTrainingRepositorySqlMock.Object, mapperMock.Object);
		var expectedTrainings = new List<ExerciseTraining>();

		exerciseByTrainingRepositorySqlMock.Setup(repo => repo.FindAll()).ReturnsAsync(expectedTrainings);

		// Act
		var result = await service.GetExerciseTraining();

		// Assert
		Assert.Same(expectedTrainings, result);
	}

	[Fact]
	public async Task GetExerciseTrainingById_WithValidId_ShouldReturnTraining()
	{
		// Arrange
		var exerciseByTrainingRepositorySqlMock = new Mock<IExerciseByTrainingRepositorySql>();
		var mapperMock = new Mock<IMapper>();

		var service = new ExerciseByTrainingService(exerciseByTrainingRepositorySqlMock.Object, mapperMock.Object);
		var trainingId = Guid.NewGuid();
		var expectedTraining = new ExerciseTraining();

		exerciseByTrainingRepositorySqlMock.Setup(repo => repo.FindById(trainingId)).ReturnsAsync(expectedTraining);

		// Act
		var result = await service.GetExerciseTrainingById(trainingId);

		// Assert
		Assert.Same(expectedTraining, result);
	}

	[Fact]
	public async Task UpdateExerciseTraining_WithValidIdAndRequest_ShouldUpdateTraining()
	{
		// Arrange
		var exerciseByTrainingRepositorySqlMock = new Mock<IExerciseByTrainingRepositorySql>();
		var mapperMock = new Mock<IMapper>();

		var service = new ExerciseByTrainingService(exerciseByTrainingRepositorySqlMock.Object, mapperMock.Object);
		var trainingId = Guid.NewGuid();
		var updateExerciseTrainingRequest = new UpdateExerciseTrainingRequest();
		var existingTraining = new ExerciseTraining();

		exerciseByTrainingRepositorySqlMock.Setup(repo => repo.FindById(trainingId)).ReturnsAsync(existingTraining);
		mapperMock.Setup(mapper => mapper.Map(updateExerciseTrainingRequest, existingTraining));
		exerciseByTrainingRepositorySqlMock.Setup(repo => repo.Update(existingTraining));
		exerciseByTrainingRepositorySqlMock.Setup(repo => repo.SaveChange());

		// Act
		var result = await service.UpdateExerciseTraining(trainingId, updateExerciseTrainingRequest);

		// Assert
		Assert.Same(existingTraining, result);
	}

	[Fact]
	public async Task DeleteExerciseTrainingById_WithValidId_ShouldDeleteTraining()
	{
		// Arrange
		var exerciseByTrainingRepositorySqlMock = new Mock<IExerciseByTrainingRepositorySql>();
		var mapperMock = new Mock<IMapper>();

		var service = new ExerciseByTrainingService(exerciseByTrainingRepositorySqlMock.Object, mapperMock.Object);
		var trainingId = Guid.NewGuid();
		var existingTraining = new ExerciseTraining();

		exerciseByTrainingRepositorySqlMock.Setup(repo => repo.FindById(trainingId)).ReturnsAsync(existingTraining);
		exerciseByTrainingRepositorySqlMock.Setup(repo => repo.SaveChange());

		// Act
		await service.DeleteExerciseTrainingById(trainingId);

		// Assert
		exerciseByTrainingRepositorySqlMock.Verify(repo => repo.Delete(existingTraining));
	}
}