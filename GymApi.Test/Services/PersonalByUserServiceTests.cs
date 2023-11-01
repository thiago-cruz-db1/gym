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

public class PersonalByUserServiceTests
{
	[Fact]
    public async Task AddPersonalByUser_WithValidRequest_ShouldAddPersonalByUser()
    {
        // Arrange
        var personalByUserRepositorySqlMock = new Mock<IPersonalByUserRepositorySql>();
        var mapperMock = new Mock<IMapper>();
        var validatorPersonalByUserMock = new Mock<IValidatorPersonalByUser>();

        var service = new PersonalByUserService(mapperMock.Object, personalByUserRepositorySqlMock.Object, validatorPersonalByUserMock.Object);
        var createPersonalByUserRequest = new CreatePersonalByUserRequest();
        var personalByUser = new PersonalByUser();

        validatorPersonalByUserMock.Setup(validator => validator.IsDuplicatePersonalOnSameTimeToClient(personalByUser)).Returns(false);
        validatorPersonalByUserMock.Setup(validator => validator.IsDuplicateClientOnSameTimeToPersonal(personalByUser)).Returns(false);
        validatorPersonalByUserMock.Setup(validator => validator.IsPersonalOpenToNewClient(personalByUser)).Returns(true);

        mapperMock.Setup(mapper => mapper.Map<PersonalByUser>(createPersonalByUserRequest)).Returns(personalByUser);

        personalByUserRepositorySqlMock.Setup(repo => repo.Save(personalByUser));
        personalByUserRepositorySqlMock.Setup(repo => repo.SaveChange());

        // Act
        var result = await service.AddPersonalByUser(createPersonalByUserRequest);

        // Assert
        Assert.Same(personalByUser, result);
    }

    [Fact]
    public async Task AddPersonalByUser_WithDuplicatePersonal_ShouldThrowException()
    {
        // Arrange
        var personalByUserRepositorySqlMock = new Mock<IPersonalByUserRepositorySql>();
        var mapperMock = new Mock<IMapper>();
        var validatorPersonalByUserMock = new Mock<IValidatorPersonalByUser>();

        var service = new PersonalByUserService(mapperMock.Object, personalByUserRepositorySqlMock.Object, validatorPersonalByUserMock.Object);
        var createPersonalByUserRequest = new CreatePersonalByUserRequest();
        var personalByUser = new PersonalByUser();

        validatorPersonalByUserMock.Setup(validator => validator.IsDuplicatePersonalOnSameTimeToClient(personalByUser)).Returns(true);

        // Act and Assert
        await Assert.ThrowsAsync<Exception>(() => service.AddPersonalByUser(createPersonalByUserRequest));
    }

    [Fact]
    public async Task UpdatePersonalByUserById_WithValidIdAndRequest_ShouldUpdatePersonalByUser()
    {
        // Arrange
        var personalByUserRepositorySqlMock = new Mock<IPersonalByUserRepositorySql>();
        var mapperMock = new Mock<IMapper>();
        var validatorPersonalByUserMock = new Mock<IValidatorPersonalByUser>();

        var service = new PersonalByUserService(mapperMock.Object, personalByUserRepositorySqlMock.Object, validatorPersonalByUserMock.Object);
        var personalByUserId = Guid.NewGuid();
        var updatePersonalByUserRequest = new UpdatePersonalByUserRequest();
        var existingPersonalByUser = new PersonalByUser();

        personalByUserRepositorySqlMock.Setup(repo => repo.FindById(personalByUserId)).ReturnsAsync(existingPersonalByUser);
        mapperMock.Setup(mapper => mapper.Map(updatePersonalByUserRequest, existingPersonalByUser));
        validatorPersonalByUserMock.Setup(validator => validator.IsDuplicatePersonalOnSameTimeToClient(existingPersonalByUser)).Returns(false);
        validatorPersonalByUserMock.Setup(validator => validator.IsDuplicateClientOnSameTimeToPersonal(existingPersonalByUser)).Returns(false);
        validatorPersonalByUserMock.Setup(validator => validator.IsPersonalOpenToNewClient(existingPersonalByUser)).Returns(true);

        personalByUserRepositorySqlMock.Setup(repo => repo.Update(existingPersonalByUser));
        personalByUserRepositorySqlMock.Setup(repo => repo.SaveChange());

        // Act
        var result = await service.UpdatePersonalByUserById(personalByUserId, updatePersonalByUserRequest);

        // Assert
        Assert.Same(existingPersonalByUser, result);
    }

    [Fact]
    public async Task UpdatePersonalByUserById_WithDuplicatePersonal_ShouldThrowException()
    {
        // Arrange
        var personalByUserRepositorySqlMock = new Mock<IPersonalByUserRepositorySql>();
        var mapperMock = new Mock<IMapper>();
        var validatorPersonalByUserMock = new Mock<IValidatorPersonalByUser>();

        var service = new PersonalByUserService(mapperMock.Object, personalByUserRepositorySqlMock.Object, validatorPersonalByUserMock.Object);
        var personalByUserId = Guid.NewGuid();
        var updatePersonalByUserRequest = new UpdatePersonalByUserRequest();
        var existingPersonalByUser = new PersonalByUser();

        personalByUserRepositorySqlMock.Setup(repo => repo.FindById(personalByUserId)).ReturnsAsync(existingPersonalByUser);
        validatorPersonalByUserMock.Setup(validator => validator.IsDuplicatePersonalOnSameTimeToClient(existingPersonalByUser)).Returns(true);

        // Act and Assert
        await Assert.ThrowsAsync<Exception>(() => service.UpdatePersonalByUserById(personalByUserId, updatePersonalByUserRequest));
    }

    [Fact]
    public async Task DeletePersonalByUserById_ShouldDeletePersonalByUser()
    {
        // Arrange
        var personalByUserRepositorySqlMock = new Mock<IPersonalByUserRepositorySql>();
        var mapperMock = new Mock<IMapper>();
        var validatorPersonalByUserMock = new Mock<IValidatorPersonalByUser>();

        var service = new PersonalByUserService(mapperMock.Object, personalByUserRepositorySqlMock.Object, validatorPersonalByUserMock.Object);
        var personalByUserId = Guid.NewGuid();
        var existingPersonalByUser = new PersonalByUser();

        personalByUserRepositorySqlMock.Setup(repo => repo.FindById(personalByUserId)).ReturnsAsync(existingPersonalByUser);
        personalByUserRepositorySqlMock.Setup(repo => repo.SaveChange());

        // Act
        await service.DeletePersonalByUserById(personalByUserId);

        // Assert
        personalByUserRepositorySqlMock.Verify(repo => repo.Delete(existingPersonalByUser));
    }

    [Fact]
	public async Task AddPersonalByUser_WithDuplicateClient_ShouldThrowException()
	{
	    // Arrange
	    var personalByUserRepositorySqlMock = new Mock<IPersonalByUserRepositorySql>();
	    var mapperMock = new Mock<IMapper>();
	    var validatorPersonalByUserMock = new Mock<IValidatorPersonalByUser>();

	    var service = new PersonalByUserService(mapperMock.Object, personalByUserRepositorySqlMock.Object, validatorPersonalByUserMock.Object);
	    var createPersonalByUserRequest = new CreatePersonalByUserRequest();
	    var personalByUser = new PersonalByUser();

	    validatorPersonalByUserMock.Setup(validator => validator.IsDuplicatePersonalOnSameTimeToClient(personalByUser)).Returns(false);
	    validatorPersonalByUserMock.Setup(validator => validator.IsDuplicateClientOnSameTimeToPersonal(personalByUser)).Returns(true);

	    // Act and Assert
	    await Assert.ThrowsAsync<Exception>(() => service.AddPersonalByUser(createPersonalByUserRequest));
	}

	[Fact]
	public async Task AddPersonalByUser_WithUnavailablePersonal_ShouldThrowException()
	{
	    // Arrange
	    var personalByUserRepositorySqlMock = new Mock<IPersonalByUserRepositorySql>();
	    var mapperMock = new Mock<IMapper>();
	    var validatorPersonalByUserMock = new Mock<IValidatorPersonalByUser>();

	    var service = new PersonalByUserService(mapperMock.Object, personalByUserRepositorySqlMock.Object, validatorPersonalByUserMock.Object);
	    var createPersonalByUserRequest = new CreatePersonalByUserRequest();
	    var personalByUser = new PersonalByUser();

	    validatorPersonalByUserMock.Setup(validator => validator.IsDuplicatePersonalOnSameTimeToClient(personalByUser)).Returns(false);
	    validatorPersonalByUserMock.Setup(validator => validator.IsDuplicateClientOnSameTimeToPersonal(personalByUser)).Returns(false);
	    validatorPersonalByUserMock.Setup(validator => validator.IsPersonalOpenToNewClient(personalByUser)).Returns(false);

	    // Act and Assert
	    await Assert.ThrowsAsync<Exception>(() => service.AddPersonalByUser(createPersonalByUserRequest));
	}

	[Fact]
	public async Task UpdatePersonalByUserById_WithInvalidId_ShouldThrowException()
	{
	    // Arrange
	    var personalByUserRepositorySqlMock = new Mock<IPersonalByUserRepositorySql>();
	    var mapperMock = new Mock<IMapper>();
	    var validatorPersonalByUserMock = new Mock<IValidatorPersonalByUser>();

	    var service = new PersonalByUserService(mapperMock.Object, personalByUserRepositorySqlMock.Object, validatorPersonalByUserMock.Object);
	    var personalByUserId = Guid.NewGuid();
	    var updatePersonalByUserRequest = new UpdatePersonalByUserRequest();

	    personalByUserRepositorySqlMock.Setup(repo => repo.FindById(personalByUserId))!.ReturnsAsync((PersonalByUser)null!);

	    // Act and Assert
	    await Assert.ThrowsAsync<ApplicationException>(() => service.UpdatePersonalByUserById(personalByUserId, updatePersonalByUserRequest));
	}
}