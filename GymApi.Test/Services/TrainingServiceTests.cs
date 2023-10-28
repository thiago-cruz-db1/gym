using System.Collections;
using AutoMapper;
using GymApi.Data.Data.Interfaces;
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
	    var validatorTrainingMock = new Mock<TrainingValidator>();

	    var service = new TrainingService(trainingRepositorySqlMock.Object, mapperMock.Object, validatorTrainingMock.Object);
	    var createTrainingRequest = new CreateTrainingRequest();
	    var training = new Training();

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
	    var validatorTrainingMock = new Mock<TrainingValidator>();

	    var service = new TrainingService(trainingRepositorySqlMock.Object, mapperMock.Object, validatorTrainingMock.Object);
	    ICollection<Guid> ids = new[] { Guid.NewGuid() };
	    var createTrainingRequest = new CreateTrainingRequest();

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
	    var validatorTrainingMock = new Mock<TrainingValidator>();

	    var service = new TrainingService(trainingRepositorySqlMock.Object, mapperMock.Object, validatorTrainingMock.Object);
	    var updateTrainingRequest = new UpdateTrainingRequest();

	    var trainingId = Guid.NewGuid();
	    var existingTraining = new Training();

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
	    var validatorTrainingMock = new Mock<TrainingValidator>();

	    var service = new TrainingService(trainingRepositorySqlMock.Object, mapperMock.Object, validatorTrainingMock.Object);
	    var updateTrainingRequest = new UpdateTrainingRequest();
	    var trainingId = Guid.NewGuid();

	    trainingRepositorySqlMock.Setup(repo => repo.FindById(trainingId)).ReturnsAsync((Training)null);

	    // Act and Assert
	    await Assert.ThrowsAsync<ApplicationException>(() => service.UpdateTraining(trainingId, updateTrainingRequest));
	}

	[Fact]
	public async Task UpdateTraining_WithInvalidExerciseIds_ShouldThrowException()
	{
	    // Arrange
	    var trainingRepositorySqlMock = new Mock<ITrainingRepositorySql>();
	    var mapperMock = new Mock<IMapper>();
	    var validatorTrainingMock = new Mock<TrainingValidator>();

	    var service = new TrainingService(trainingRepositorySqlMock.Object, mapperMock.Object, validatorTrainingMock.Object);
	    var updateTrainingRequest = new UpdateTrainingRequest();
	    ICollection<Guid> ids = new[] { Guid.NewGuid() };
	    var trainingId = Guid.NewGuid();
	    var existingTraining = new Training();

	    trainingRepositorySqlMock.Setup(repo => repo.FindById(trainingId)).ReturnsAsync(existingTraining);
	    validatorTrainingMock.Setup(validator => validator.ValidationIfExerciseExist(ids)).Returns(false);

	    // Act and Assert
	    await Assert.ThrowsAsync<Exception>(() => service.UpdateTraining(trainingId, updateTrainingRequest));
	}

	[Fact]
	public async Task GetTraining_WithExistingTrainings_ShouldReturnListOfTrainings()
	{
	    // Arrange
	    var trainingRepositorySqlMock = new Mock<ITrainingRepositorySql>();
	    var mapperMock = new Mock<IMapper>();
	    var validatorTrainingMock = new Mock<TrainingValidator>();

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
	    var validatorTrainingMock = new Mock<TrainingValidator>();

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
	    var validatorTrainingMock = new Mock<TrainingValidator>();

	    var service = new TrainingService(trainingRepositorySqlMock.Object, mapperMock.Object, validatorTrainingMock.Object);
	    var trainingId = Guid.NewGuid();
	    var existingTraining = new Training();

	    trainingRepositorySqlMock.Setup(repo => repo.FindById(trainingId)).ReturnsAsync(existingTraining);
	    trainingRepositorySqlMock.Setup(repo => repo.Delete(existingTraining));
	    trainingRepositorySqlMock.Setup(repo => repo.SaveChange());

	    // Act
	    await service.DeleteTrainingById(trainingId);

	    // Assert
	    trainingRepositorySqlMock.Verify(repo => repo.Delete(existingTraining), Times.Once);
	}

	[Fact]
	public async Task DeleteTrainingById_WithInvalidTrainingId_ShouldThrowException()
	{
	    // Arrange
	    var trainingRepositorySqlMock = new Mock<ITrainingRepositorySql>();
	    var mapperMock = new Mock<IMapper>();
	    var validatorTrainingMock = new Mock<TrainingValidator>();

	    var service = new TrainingService(trainingRepositorySqlMock.Object, mapperMock.Object, validatorTrainingMock.Object);
	    var trainingId = Guid.NewGuid();

	    trainingRepositorySqlMock.Setup(repo => repo.FindById(trainingId)).ReturnsAsync((Training)null);

	    // Act and Assert
	    await Assert.ThrowsAsync<ApplicationException>(() => service.DeleteTrainingById(trainingId));
	}

}