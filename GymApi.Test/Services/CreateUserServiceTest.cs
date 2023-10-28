using AutoMapper;
using GymApi.Data.Data.Interfaces;
using GymApi.Domain;
using GymApi.Domain.Dto.Response;
using GymApi.UseCases.Dto.Request;
using GymApi.UseCases.Services;
using Microsoft.AspNetCore.Identity;
using Moq;
using Xunit;

namespace GymApi.Test.Services;

public class CreateUserServiceTests
{
	[Fact]
	public async Task CreateAsync_WithValidRequest_ShouldCreateUser()
	{
		// Arrange
		var createUserRepositorySqlMock = new Mock<ICreateUserRepositorySql>();
		var mapperMock = new Mock<IMapper>();

		var service = new CreateUserService(mapperMock.Object, createUserRepositorySqlMock.Object);
		var createUserRequest = new CreateUserRequest();
		var createdUser = new User();
		var createUserResponse = new CreateUserResponse();

		mapperMock.Setup(mapper => mapper.Map<User>(createUserRequest)).Returns(createdUser);
		createUserRepositorySqlMock.Setup(repo => repo.Create(createdUser, createUserRequest.Password));

		mapperMock.Setup(mapper => mapper.Map<CreateUserResponse>(createdUser)).Returns(createUserResponse);

		// Act
		var result = await service.Create(createUserRequest);

		// Assert
		Assert.Same(createUserResponse, result);
	}

	[Fact]
	public void GetUsers_ShouldReturnListOfUsers()
	{
		// Arrange
		var createUserRepositorySqlMock = new Mock<ICreateUserRepositorySql>();
		var mapperMock = new Mock<IMapper>();

		var service = new CreateUserService(mapperMock.Object, createUserRepositorySqlMock.Object);
		var expectedUsers = new List<User>();

		createUserRepositorySqlMock.Setup(repo => repo.GetUsers()).Returns(expectedUsers);

		// Act
		var result = service.GetUsers();

		// Assert
		Assert.Same(expectedUsers, result);
	}

	[Fact]
	public async Task GetUserById_WithValidUserId_ShouldReturnUser()
	{
		// Arrange
		var createUserRepositorySqlMock = new Mock<ICreateUserRepositorySql>();
		var mapperMock = new Mock<IMapper>();

		var service = new CreateUserService(mapperMock.Object, createUserRepositorySqlMock.Object);
		var userId = "123";
		var expectedUser = new User();

		createUserRepositorySqlMock.Setup(repo => repo.GetUserById(userId)).ReturnsAsync(expectedUser);

		// Act
		var result = await service.GetUserById(userId);

		// Assert
		Assert.Same(expectedUser, result);
	}

	[Fact]
	public async Task Update_WithValidUserIdAndRequest_ShouldUpdateUser()
	{
		// Arrange
		var createUserRepositorySqlMock = new Mock<ICreateUserRepositorySql>();
		var mapperMock = new Mock<IMapper>();
		var identityResult = IdentityResult.Success;

		var service = new CreateUserService(mapperMock.Object, createUserRepositorySqlMock.Object);
		var userId = "123";
		var updateUserRequest = new UpdateUserRequest();
		var existingUser = new User();

		createUserRepositorySqlMock.Setup(repo => repo.GetUserById(userId)).ReturnsAsync(existingUser);
		mapperMock.Setup(mapper => mapper.Map(updateUserRequest, existingUser));
		createUserRepositorySqlMock.Setup(repo => repo.Update(existingUser)).ReturnsAsync(identityResult);

		// Act
		await service.Update(userId, updateUserRequest);

		// Assert
		createUserRepositorySqlMock.Verify(repo => repo.Update(existingUser), Times.Once);
	}

	[Fact]
	public async Task Delete_WithValidUserId_ShouldDeleteUser()
	{
		// Arrange
		var createUserRepositorySqlMock = new Mock<ICreateUserRepositorySql>();
		var mapperMock = new Mock<IMapper>();
		var identityResult = IdentityResult.Success;

		var service = new CreateUserService(mapperMock.Object, createUserRepositorySqlMock.Object);
		var userId = "123";
		var existingUser = new User();

		createUserRepositorySqlMock.Setup(repo => repo.GetUserById(userId)).ReturnsAsync(existingUser);
		createUserRepositorySqlMock.Setup(repo => repo.Delete(existingUser)).ReturnsAsync(identityResult);

		// Act
		await service.Delete(userId);

		// Assert
		createUserRepositorySqlMock.Verify(repo => repo.Delete(existingUser), Times.Once);
	}

	[Fact]
	public async Task IncreaseWorkOut_WithValidUserId_ShouldIncreaseWorkout()
	{
		// Arrange
		var createUserRepositorySqlMock = new Mock<ICreateUserRepositorySql>();
		var mapperMock = new Mock<IMapper>();
		var userId = "123";

		var service = new CreateUserService(mapperMock.Object, createUserRepositorySqlMock.Object);

		// Act
		await service.IncreaseWorkOut(userId);

		// Assert
		createUserRepositorySqlMock.Verify(repo => repo.IncreaseWorkOut(userId), Times.Once);
	}

	[Fact]
	public void GetPersonalTraineeByDay_WithValidIdAndDate_ShouldReturnList()
	{
		// Arrange
		var createUserRepositorySqlMock = new Mock<ICreateUserRepositorySql>();
		var mapperMock = new Mock<IMapper>();
		var userId = Guid.NewGuid();
		var date = DateTime.Now;
		var expectedPersonalTrainees = new List<PersonalByUser>();

		createUserRepositorySqlMock.Setup(repo => repo.GetPersonalTraineeByDay(userId, date)).Returns(expectedPersonalTrainees);

		var service = new CreateUserService(mapperMock.Object, createUserRepositorySqlMock.Object);

		// Act
		var result = service.GetPersonalTraineeByDay(userId, date);

		// Assert
		Assert.Same(expectedPersonalTrainees, result);
	}
}