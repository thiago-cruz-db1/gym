using GymApi.Domain;
using GymApi.UseCases.Dto.Request;
using GymApi.UseCases.Services;
using Microsoft.AspNetCore.Identity;
using Moq;
using Xunit;

namespace GymApi.Test.Services;

public class LoginUserServiceTests
{
	[Fact]
    public async Task Login_WithValidCredentials_ShouldReturnToken()
    {
        // Arrange
        var signInManagerMock = new Mock<SignInManager<User>>();
        var generateTokenServiceMock = new Mock<GenerateTokenService>();
        var userManagerMock = new Mock<UserManager<User>>(new Mock<IUserStore<User>>().Object, null, null, null, null, null, null, null, null);
        var loginDto = new LoginUserRequest
        {
            UserName = "testuser",
            Password = "password"
        };

        var user = new User
        {
            UserName = "testuser",
            Id = "12345"
            // Add other user properties as needed
        };

        var roles = new List<string> { "Role1", "Role2" };
        userManagerMock.Setup(userManager => userManager.GetRolesAsync(user)).ReturnsAsync(roles);

        signInManagerMock.Setup(signInManager => signInManager.PasswordSignInAsync(loginDto.UserName, loginDto.Password, false, false))
            .ReturnsAsync(SignInResult.Success);

        generateTokenServiceMock.Setup(generator => generator.Create(user))
            .Returns("test_token");

        signInManagerMock.SetupGet(signInManager => signInManager.UserManager)
            .Returns(userManagerMock.Object);

        var service = new LoginUserService(signInManagerMock.Object, generateTokenServiceMock.Object);

        // Act
        var result = await service.Login(loginDto);

        // Assert
        Assert.Equal("test_token", result);
    }

    [Fact]
    public async Task Login_WithInvalidCredentials_ShouldThrowException()
    {
        // Arrange
        var signInManagerMock = new Mock<SignInManager<User>>();
        var generateTokenServiceMock = new Mock<GenerateTokenService>();
        var loginDto = new LoginUserRequest
        {
            UserName = "testuser",
            Password = "invalid_password"
        };

        signInManagerMock.Setup(signInManager => signInManager.PasswordSignInAsync(loginDto.UserName, loginDto.Password, false, false))
            .ReturnsAsync(SignInResult.Failed);

        var service = new LoginUserService(signInManagerMock.Object, generateTokenServiceMock.Object);

        // Act and Assert
        await Assert.ThrowsAsync<ApplicationException>(() => service.Login(loginDto));
    }

    [Fact]
    public async Task Login_WithNullUser_ShouldReturnUserIsNull()
    {
        // Arrange
        var signInManagerMock = new Mock<SignInManager<User>>();
        var generateTokenServiceMock = new Mock<GenerateTokenService>();
        var loginDto = new LoginUserRequest
        {
            UserName = "testuser",
            Password = "password"
        };

        signInManagerMock.Setup(signInManager => signInManager.PasswordSignInAsync(loginDto.UserName, loginDto.Password, false, false))
            .ReturnsAsync(SignInResult.Success);

        signInManagerMock.SetupGet(signInManager => signInManager.UserManager)
            .Returns(new Mock<UserManager<User>>(new Mock<IUserStore<User>>().Object, null, null, null, null, null, null, null, null).Object);

        var service = new LoginUserService(signInManagerMock.Object, generateTokenServiceMock.Object);

        // Act
        var result = await service.Login(loginDto);

        // Assert
        Assert.Equal("user is null", result);
    }

}