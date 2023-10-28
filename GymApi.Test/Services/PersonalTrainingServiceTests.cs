using AutoMapper;
using GymApi.Data.Data.Interfaces;
using GymApi.Domain;
using GymApi.UseCases.Dto.Request;
using GymApi.UseCases.Services;
using Moq;
using Xunit;

namespace GymApi.Test.Services;

public class PersonalTrainingServiceTests
{
	[Fact]
    public async Task AddPersonalTrainer_WithValidRequest_ShouldAddPersonalTrainer()
    {
        // Arrange
        var personalTrainerRepositorySqlMock = new Mock<IPersonalTrainerRepositorySql>();
        var mapperMock = new Mock<IMapper>();

        var service = new PersonalTrainerService(personalTrainerRepositorySqlMock.Object, mapperMock.Object);
        var createPersonalTrainerRequest = new CreatePersonalTrainerRequest();
        var personalTrainer = new PersonalTrainer();

        mapperMock.Setup(mapper => mapper.Map<PersonalTrainer>(createPersonalTrainerRequest)).Returns(personalTrainer);
        personalTrainerRepositorySqlMock.Setup(repo => repo.Save(personalTrainer));
        personalTrainerRepositorySqlMock.Setup(repo => repo.SaveChange());

        // Act
        var result = await service.AddPersonalTrainer(createPersonalTrainerRequest);

        // Assert
        Assert.Same(personalTrainer, result);
    }

    [Fact]
    public async Task UpdatePersonalById_WithValidIdAndRequest_ShouldUpdatePersonal()
    {
        // Arrange
        var personalTrainerRepositorySqlMock = new Mock<IPersonalTrainerRepositorySql>();
        var mapperMock = new Mock<IMapper>();

        var service = new PersonalTrainerService(personalTrainerRepositorySqlMock.Object, mapperMock.Object);
        var personalTrainerId = Guid.NewGuid();
        var updatePersonalRequest = new UpdatePersonalRequest();
        var existingPersonalTrainer = new PersonalTrainer();

        personalTrainerRepositorySqlMock.Setup(repo => repo.FindById(personalTrainerId)).ReturnsAsync(existingPersonalTrainer);
        mapperMock.Setup(mapper => mapper.Map(updatePersonalRequest, existingPersonalTrainer));
        personalTrainerRepositorySqlMock.Setup(repo => repo.Update(existingPersonalTrainer));
        personalTrainerRepositorySqlMock.Setup(repo => repo.SaveChange());

        // Act
        var result = await service.UpdatePersonalById(personalTrainerId, updatePersonalRequest);

        // Assert
        Assert.Same(existingPersonalTrainer, result);
    }

    [Fact]
    public async Task DeletePersonalTrainerById_WithValidId_ShouldDeletePersonalTrainer()
    {
        // Arrange
        var personalTrainerRepositorySqlMock = new Mock<IPersonalTrainerRepositorySql>();
        var mapperMock = new Mock<IMapper>();

        var service = new PersonalTrainerService(personalTrainerRepositorySqlMock.Object, mapperMock.Object);
        var personalTrainerId = Guid.NewGuid();
        var existingPersonalTrainer = new PersonalTrainer();

        personalTrainerRepositorySqlMock.Setup(repo => repo.FindById(personalTrainerId)).ReturnsAsync(existingPersonalTrainer);
        personalTrainerRepositorySqlMock.Setup(repo => repo.SaveChange());

        // Act
        await service.DeletePersonalTrainerById(personalTrainerId);

        // Assert
        personalTrainerRepositorySqlMock.Verify(repo => repo.Delete(existingPersonalTrainer));
    }

    [Fact]
    public async Task AddPersonalTrainer_WithValidationFailure_ShouldThrowException()
    {
        // Arrange
        var personalTrainerRepositorySqlMock = new Mock<IPersonalTrainerRepositorySql>();
        var mapperMock = new Mock<IMapper>();

        var service = new PersonalTrainerService(personalTrainerRepositorySqlMock.Object, mapperMock.Object);
        var createPersonalTrainerRequest = new CreatePersonalTrainerRequest();
        var personalTrainer = new PersonalTrainer();

        mapperMock.Setup(mapper => mapper.Map<PersonalTrainer>(createPersonalTrainerRequest)).Returns(personalTrainer);
        personalTrainerRepositorySqlMock.Setup(repo => repo.Save(personalTrainer));
        personalTrainerRepositorySqlMock.Setup(repo => repo.SaveChange()).Throws(new Exception("Validation failed"));

        // Act and Assert
        await Assert.ThrowsAsync<Exception>(() => service.AddPersonalTrainer(createPersonalTrainerRequest));
    }

    [Fact]
    public async Task UpdatePersonalById_WithInvalidId_ShouldThrowException()
    {
        // Arrange
        var personalTrainerRepositorySqlMock = new Mock<IPersonalTrainerRepositorySql>();
        var mapperMock = new Mock<IMapper>();

        var service = new PersonalTrainerService(personalTrainerRepositorySqlMock.Object, mapperMock.Object);
        var personalTrainerId = Guid.NewGuid();
        var updatePersonalRequest = new UpdatePersonalRequest();

        personalTrainerRepositorySqlMock.Setup(repo => repo.FindById(personalTrainerId)).ReturnsAsync((PersonalTrainer)null);

        // Act and Assert
        await Assert.ThrowsAsync<ApplicationException>(() => service.UpdatePersonalById(personalTrainerId, updatePersonalRequest));
    }

    [Fact]
    public async Task DeletePersonalTrainerById_WithInvalidId_ShouldThrowException()
    {
        // Arrange
        var personalTrainerRepositorySqlMock = new Mock<IPersonalTrainerRepositorySql>();
        var mapperMock = new Mock<IMapper>();

        var service = new PersonalTrainerService(personalTrainerRepositorySqlMock.Object, mapperMock.Object);
        var personalTrainerId = Guid.NewGuid();

        personalTrainerRepositorySqlMock.Setup(repo => repo.FindById(personalTrainerId)).ReturnsAsync((PersonalTrainer)null);

        // Act and Assert
        await Assert.ThrowsAsync<Exception>(() => service.DeletePersonalTrainerById(personalTrainerId));
    }
}