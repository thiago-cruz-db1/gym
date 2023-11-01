using System.Collections;
using AutoMapper;
using GymApi.Data.Data.Interfaces;
using GymApi.Data.Data.Validator.Interfaces;
using GymApi.Data.Data.Validator.Validators;
using GymApi.Domain;
using GymApi.UseCases.Dto.Request;
using GymApi.UseCases.Services;
using Moq;
using Xunit;

namespace GymApi.Test.Services;

public class TrainingServiceTests
{
	[Fact]
	public async Task AddTraining_WithValidRequest_ShouldAddTraining()
	{
	    // Arrange
	    var trainingRepositorySqlMock = new Mock<ITrainingRepositorySql>();
	    var mapperMock = new Mock<IMapper>();
	    var validatorTrainingMock = new Mock<IValidatorTraining>();

	    var service = new TrainingService(trainingRepositorySqlMock.Object, mapperMock.Object, validatorTrainingMock.Object);
	    var createTrainingRequest = MockCreateRequest();
	    var training = MockTraining();

	    mapperMock.Setup(mapper => mapper.Map<Training>(createTrainingRequest)).Returns(training);
	    trainingRepositorySqlMock.Setup(repo => repo.Save(training));
	    trainingRepositorySqlMock.Setup(repo => repo.SaveChange());

	    // Act
	    var result = await service.AddTraining(createTrainingRequest);

	    // Assert
	    Assert.Same(training, result);
	}

	[Fact]
	public async Task AddTraining_WithInvalidExerciseIds_ShouldThrowException()
	{
	    // Arrange
	    var trainingRepositorySqlMock = new Mock<ITrainingRepositorySql>();
	    var mapperMock = new Mock<IMapper>();
	    var validatorTrainingMock = new Mock<IValidatorTraining>();

	    var service = new TrainingService(trainingRepositorySqlMock.Object, mapperMock.Object, validatorTrainingMock.Object);
	    ICollection<Guid> ids = new[] { Guid.NewGuid() };
	    var createTrainingRequest = MockCreateRequest();

	    validatorTrainingMock.Setup(validator => validator.ValidationIfExerciseExist(ids)).Returns(false);

	    // Act and Assert
	    await Assert.ThrowsAsync<Exception>(() => service.AddTraining(createTrainingRequest));
	}

	[Fact]
	public async Task UpdateTraining_WithValidRequestAndExistingTraining_ShouldUpdateTraining()
	{
	    // Arrange
	    var trainingRepositorySqlMock = new Mock<ITrainingRepositorySql>();
	    var mapperMock = new Mock<IMapper>();
	    var validatorTrainingMock = new Mock<IValidatorTraining>();

	    var service = new TrainingService(trainingRepositorySqlMock.Object, mapperMock.Object, validatorTrainingMock.Object);
	    var updateTrainingRequest = new UpdateTrainingRequest();

	    var trainingId = Guid.NewGuid();
	    var existingTraining = MockTraining();

	    trainingRepositorySqlMock.Setup(repo => repo.FindById(trainingId)).ReturnsAsync(existingTraining);
	    mapperMock.Setup(mapper => mapper.Map(updateTrainingRequest, existingTraining)).Returns(existingTraining);
	    trainingRepositorySqlMock.Setup(repo => repo.Update(existingTraining));
	    trainingRepositorySqlMock.Setup(repo => repo.SaveChange());

	    // Act
	    var result = await service.UpdateTraining(trainingId, updateTrainingRequest);

	    // Assert
	    Assert.Same(existingTraining, result);
	}

	[Fact]
	public async Task UpdateTraining_WithInvalidTrainingId_ShouldThrowException()
	{
	    // Arrange
	    var trainingRepositorySqlMock = new Mock<ITrainingRepositorySql>();
	    var mapperMock = new Mock<IMapper>();
	    var validatorTrainingMock = new Mock<IValidatorTraining>();

	    var service = new TrainingService(trainingRepositorySqlMock.Object, mapperMock.Object, validatorTrainingMock.Object);
	    var updateTrainingRequest = new UpdateTrainingRequest();
	    var trainingId = Guid.Parse("08dbc5a3-7bbc-4e90-83de-c4c4207c922c");

	    trainingRepositorySqlMock.Setup(repo => repo.FindById(trainingId)).ReturnsAsync((Training)null);

	    // Act and Assert
	    await Assert.ThrowsAsync<ApplicationException>(() => service.UpdateTraining(trainingId, updateTrainingRequest));
	}

	[Fact]
	public async Task GetTraining_WithExistingTrainings_ShouldReturnListOfTrainings()
	{
	    // Arrange
	    var trainingRepositorySqlMock = new Mock<ITrainingRepositorySql>();
	    var mapperMock = new Mock<IMapper>();
	    var validatorTrainingMock = new Mock<IValidatorTraining>();

	    var service = new TrainingService(trainingRepositorySqlMock.Object, mapperMock.Object, validatorTrainingMock.Object);
	    var existingTrainings = new List<Training>
	    {
	        new Training(),
	        new Training(),
	        new Training()
	    };

	    trainingRepositorySqlMock.Setup(repo => repo.FindAll()).ReturnsAsync(existingTrainings);

	    // Act
	    var result = await service.GetTraining();

	    // Assert
	    Assert.Equal(existingTrainings, result);
	}

	[Fact]
	public async Task GetTraining_WithNoExistingTrainings_ShouldReturnEmptyList()
	{
	    // Arrange
	    var trainingRepositorySqlMock = new Mock<ITrainingRepositorySql>();
	    var mapperMock = new Mock<IMapper>();
	    var validatorTrainingMock = new Mock<IValidatorTraining>();

	    var service = new TrainingService(trainingRepositorySqlMock.Object, mapperMock.Object, validatorTrainingMock.Object);

	    trainingRepositorySqlMock.Setup(repo => repo.FindAll()).ReturnsAsync(new List<Training>());

	    // Act
	    var result = await service.GetTraining();

	    // Assert
	    Assert.Empty(result);
	}

	[Fact]
	public async Task DeleteTrainingById_WithValidTrainingId_ShouldDeleteTraining()
	{
	    // Arrange
	    var trainingRepositorySqlMock = new Mock<ITrainingRepositorySql>();
	    var mapperMock = new Mock<IMapper>();
	    var validatorTrainingMock = new Mock<IValidatorTraining>();

	    var service = new TrainingService(trainingRepositorySqlMock.Object, mapperMock.Object, validatorTrainingMock.Object);
	    var trainingId = Guid.Parse("08dbc5a3-7bbc-4e90-83de-c4c4207c922c");
	    var existingTraining = MockTraining();

	    trainingRepositorySqlMock.Setup(repo => repo.FindById(trainingId)).ReturnsAsync(existingTraining);
	    trainingRepositorySqlMock.Setup(repo => repo.Delete(existingTraining));
	    trainingRepositorySqlMock.Setup(repo => repo.SaveChange());

	    // Act
	    await service.DeleteTrainingById(trainingId);

	    // Assert
	    trainingRepositorySqlMock.Verify(repo => repo.Delete(existingTraining), Times.Once);
	}

	private CreateTrainingRequest MockCreateRequest()
	{
		return new CreateTrainingRequest
		{
			Name = "A",
			Exercises = new List<Guid>()
		};
	}

	private UpdateTrainingRequest MockUpdateRequest()
	{
		return new UpdateTrainingRequest
		{
			Name = "A",
			Exercises = new List<Guid>()
		};
	}

	private Training MockTraining()
	{
		return new Training
		{
			Id = Guid.Parse("08dbc5a3-7bbc-4e90-83de-c4c4207c922c"),
			Name = "A",
			StartDate = default,
			EndDate = default,
			UserTrainings = null,
			ExerciseTrainings = null
		};
	}
}