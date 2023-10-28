using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using GymApi.Domain;
using GymApi.UseCases.Services;
using Microsoft.IdentityModel.Tokens;
using Xunit;

namespace GymApi.Test.Services;

public class GenerateTokenServiceTests
{
	[Fact]
    public void Create_ShouldGenerateTokenWithClaims()
    {
        // Arrange
        var service = new GenerateTokenService();
        var user = new User
        {
            UserName = "testuser",
            Id = "12345",
            DateBirth = new DateTime(1990, 1, 1),
            Email = "test@example.com"
        };

        // Act
        var token = service.Create(user);

        // Assert
        var handler = new JwtSecurityTokenHandler();
        var securityToken = handler.ReadToken(token) as JwtSecurityToken;

        Assert.NotNull(securityToken);
        Assert.Equal("testuser", securityToken.Claims.FirstOrDefault(claim => claim.Type == "username")?.Value);
        Assert.Equal("12345", securityToken.Claims.FirstOrDefault(claim => claim.Type == "id")?.Value);
        Assert.Equal("1/1/1990 12:00:00 AM", securityToken.Claims.FirstOrDefault(claim => claim.Type == ClaimTypes.DateOfBirth)?.Value);
        Assert.Equal("test@example.com", securityToken.Claims.FirstOrDefault(claim => claim.Type == ClaimTypes.Email)?.Value);
        Assert.NotNull(securityToken.Claims.FirstOrDefault(claim => claim.Type == "loginTimeStamp"));
    }

    [Fact]
    public void Create_ShouldGenerateTokenWithValidSignature()
    {
        // Arrange
        var service = new GenerateTokenService();
        var user = new User
        {
            UserName = "testuser",
            Id = "12345",
            DateBirth = new DateTime(1990, 1, 1),
            Email = "test@example.com"
        };

        // Act
        var token = service.Create(user);

        // Assert
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("ahldhakhskajgbskabksjbas5461674651"));
        var tokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = key
        };

        var handler = new JwtSecurityTokenHandler();
        var principal = handler.ValidateToken(token, tokenValidationParameters, out _);

        Assert.NotNull(principal);
    }
}