using AutoMapper;
using GymApi.Data.Data.Interfaces;
using GymApi.Data.Data.Validator.Validators;
using GymApi.Domain;
using GymApi.UseCases.Dto.Request;
using GymApi.UseCases.Services;
using Moq;
using Xunit;

namespace GymApi.Test.Services;

public class TrainingByUserServiceTests
{
	[Fact]
	public async Task AddTrainingUser_WithValidRequestAndCorrectDay_ShouldAddTrainingUser()
	{
	    // Arrange
	    var trainingByUserRepositorySqlMock = new Mock<ITrainingByUserRepositorySql>();
	    var mapperMock = new Mock<IMapper>();
	    var validatorTrainingByUserMock = new Mock<TrainingByUserValidator>();

	    var service = new TrainingByUserService(trainingByUserRepositorySqlMock.Object, mapperMock.Object, validatorTrainingByUserMock.Object);
	    var createTrainingRequest = new CreateTrainingByUserRequest();
	    var trainingUser = new TrainingUser();

	    validatorTrainingByUserMock.Setup(validator => validator.CorrectDayOfTrainingByUserId(createTrainingRequest.UserId)).ReturnsAsync(true);
	    mapperMock.Setup(mapper => mapper.Map<TrainingUser>(createTrainingRequest)).Returns(trainingUser);
	    trainingByUserRepositorySqlMock.Setup(repo => repo.Save(trainingUser));
	    trainingByUserRepositorySqlMock.Setup(repo => repo.SaveChange());

	    // Act
	    var result = await service.AddTrainingUser(createTrainingRequest);

	    // Assert
	    Assert.Same(trainingUser, result);
	}

	[Fact]
	public async Task AddTrainingUser_WithInvalidDay_ShouldThrowException()
	{
	    // Arrange
	    var trainingByUserRepositorySqlMock = new Mock<ITrainingByUserRepositorySql>();
	    var mapperMock = new Mock<IMapper>();
	    var validatorTrainingByUserMock = new Mock<TrainingByUserValidator>();

	    var service = new TrainingByUserService(trainingByUserRepositorySqlMock.Object, mapperMock.Object, validatorTrainingByUserMock.Object);
	    var createTrainingRequest = new CreateTrainingByUserRequest();

	    validatorTrainingByUserMock.Setup(validator => validator.CorrectDayOfTrainingByUserId(createTrainingRequest.UserId)).ReturnsAsync(false);

	    // Act and Assert
	    await Assert.ThrowsAsync<Exception>(() => service.AddTrainingUser(createTrainingRequest));
	}

	[Fact]
	public async Task UpdateTrainingUser_WithValidRequestAndExistingTraining_ShouldUpdateTrainingUser()
	{
	    // Arrange
	    var trainingByUserRepositorySqlMock = new Mock<ITrainingByUserRepositorySql>();
	    var mapperMock = new Mock<IMapper>();
	    var validatorTrainingByUserMock = new Mock<TrainingByUserValidator>();

	    var service = new TrainingByUserService(trainingByUserRepositorySqlMock.Object, mapperMock.Object, validatorTrainingByUserMock.Object);
	    var updateTrainingRequest = new UpdateTrainingByUserRequest();
	    var trainingUserId = Guid.NewGuid();
	    var existingTrainingUser = new TrainingUser();

	    trainingByUserRepositorySqlMock.Setup(repo => repo.FindById(trainingUserId)).ReturnsAsync(existingTrainingUser);
	    mapperMock.Setup(mapper => mapper.Map(updateTrainingRequest, existingTrainingUser)).Returns(existingTrainingUser);
	    trainingByUserRepositorySqlMock.Setup(repo => repo.Update(existingTrainingUser));
	    trainingByUserRepositorySqlMock.Setup(repo => repo.SaveChange());

	    // Act
	    var result = await service.UpdateTrainingUser(trainingUserId, updateTrainingRequest);

	    // Assert
	    Assert.Same(existingTrainingUser, result);
	}

	[Fact]
	public async Task UpdateTrainingUser_WithInvalidTrainingId_ShouldThrowException()
	{
	    // Arrange
	    var trainingByUserRepositorySqlMock = new Mock<ITrainingByUserRepositorySql>();
	    var mapperMock = new Mock<IMapper>();
	    var validatorTrainingByUserMock = new Mock<TrainingByUserValidator>();

	    var service = new TrainingByUserService(trainingByUserRepositorySqlMock.Object, mapperMock.Object, validatorTrainingByUserMock.Object);
	    var updateTrainingRequest = new UpdateTrainingByUserRequest();
	    var trainingUserId = Guid.NewGuid();

	    trainingByUserRepositorySqlMock.Setup(repo => repo.FindById(trainingUserId)).ReturnsAsync((TrainingUser)null);

	    // Act and Assert
	    await Assert.ThrowsAsync<ApplicationException>(() => service.UpdateTrainingUser(trainingUserId, updateTrainingRequest));
	}

	[Fact]
	public async Task UpdateTrainingUser_WithValidationFailure_ShouldThrowException()
	{
	    // Arrange
	    var trainingByUserRepositorySqlMock = new Mock<ITrainingByUserRepositorySql>();
	    var mapperMock = new Mock<IMapper>();
	    var validatorTrainingByUserMock = new Mock<TrainingByUserValidator>();

	    var service = new TrainingByUserService(trainingByUserRepositorySqlMock.Object, mapperMock.Object, validatorTrainingByUserMock.Object);
	    var updateTrainingRequest = new UpdateTrainingByUserRequest();
	    var trainingUserId = Guid.NewGuid();
	    var existingTrainingUser = new TrainingUser();

	    trainingByUserRepositorySqlMock.Setup(repo => repo.FindById(trainingUserId)).ReturnsAsync(existingTrainingUser);
	    mapperMock.Setup(mapper => mapper.Map(updateTrainingRequest, existingTrainingUser)).Returns(existingTrainingUser);
	    validatorTrainingByUserMock.Setup(validator => validator.CorrectDayOfTrainingByUserId(trainingUserId)).Throws(new Exception("Validation failed"));

	    // Act and Assert
	    await Assert.ThrowsAsync<Exception>(() => service.UpdateTrainingUser(trainingUserId, updateTrainingRequest));
	}

	[Fact]
	public async Task DeleteTrainingUserById_WithInvalidTrainingId_ShouldThrowException()
	{
	    // Arrange
	    var trainingByUserRepositorySqlMock = new Mock<ITrainingByUserRepositorySql>();
	    var mapperMock = new Mock<IMapper>();
	    var validatorTrainingByUserMock = new Mock<TrainingByUserValidator>();

	    var service = new TrainingByUserService(trainingByUserRepositorySqlMock.Object, mapperMock.Object, validatorTrainingByUserMock.Object);
	    var trainingUserId = Guid.NewGuid();

	    trainingByUserRepositorySqlMock.Setup(repo => repo.FindById(trainingUserId)).ReturnsAsync((TrainingUser)null);

	    // Act and Assert
	    await Assert.ThrowsAsync<ApplicationException>(() => service.DeleteTrainingUserById(trainingUserId));
	}
}