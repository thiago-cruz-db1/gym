using AutoMapper;
using GymApi.Data.Data.Interfaces;
using GymApi.Data.Data.Validator.Interfaces;
using GymApi.Data.Data.Validator.Validators;
using GymApi.Domain;
using GymApi.Domain.Enum;
using GymApi.UseCases.Dto.Request;
using GymApi.UseCases.Services;
using Moq;
using Xunit;

namespace GymApi.Test.Services;

public class PlanServiceTests
{
	[Fact]
    public async Task ShouldAddPlan()
    {
	    // Arrange
	    var planRepositorySqlMock = new Mock<IPlanRepositorySql>();
	    var mapperMock = new Mock<IMapper>();
	    var validatorPlanMock = new Mock<IValidatorPlan>();

	    var service = new PlanService(planRepositorySqlMock.Object, mapperMock.Object, validatorPlanMock.Object);
	    var createPlanRequest = MockCreateRequest();
	    var plan = MockPlan();

	    // Set up the validator mock to return false when IsValidPlanName is called
	    validatorPlanMock.Setup(validator => validator.IsValidPlanName(createPlanRequest.Category)).ReturnsAsync(false);

	    // Set up the planRepositorySqlMock to return the plan when Save is called
	    planRepositorySqlMock.Setup(repo => repo.Save(It.IsAny<Plan>()));

	    // Set up the planRepositorySqlMock to do nothing when SaveChange is called
	    planRepositorySqlMock.Setup(repo => repo.SaveChange()).Verifiable();

	    // Act
	    var result = await service.AddPlan(createPlanRequest);

	    // Assert
	    Assert.Same(plan, result);
	    planRepositorySqlMock.Verify(repo => repo.Save(It.IsAny<Plan>()), Times.Once);
	    planRepositorySqlMock.Verify(repo => repo.SaveChange(), Times.Once);
    }

    [Fact]
    public async Task ShouldUpdatePlan()
    {
        // Arrange
        var planRepositorySqlMock = new Mock<IPlanRepositorySql>();
        var mapperMock = new Mock<IMapper>();
        var validatorPlanMock = new Mock<IValidatorPlan>();

        var service = new PlanService(planRepositorySqlMock.Object, mapperMock.Object, validatorPlanMock.Object);
        var planId = Guid.NewGuid();
        var updatePlanRequest = MockUpdateRequest();
        var existingPlan = MockPlan();

        planRepositorySqlMock.Setup(repo => repo.FindById(planId)).ReturnsAsync(existingPlan);
        mapperMock.Setup(mapper => mapper.Map(updatePlanRequest, existingPlan));
        validatorPlanMock.Setup(validator => validator.IsValidPlanName(updatePlanRequest.Category)).ReturnsAsync(false);
        planRepositorySqlMock.Setup(repo => repo.Update(existingPlan));
        planRepositorySqlMock.Setup(repo => repo.SaveChange());

        // Act
        var result = await service.UpdatePlanById(planId, updatePlanRequest);

        // Assert
        Assert.Same(existingPlan, result);
    }

    [Fact]
    public async Task ShouldDeletePlan()
    {
        // Arrange
        var planRepositorySqlMock = new Mock<IPlanRepositorySql>();
        var mapperMock = new Mock<IMapper>();
        var validatorPlanMock = new Mock<IValidatorPlan>();

        var service = new PlanService(planRepositorySqlMock.Object, mapperMock.Object, validatorPlanMock.Object);
        var planId = Guid.NewGuid();
        var existingPlan = MockPlan();

        planRepositorySqlMock.Setup(repo => repo.FindById(planId)).ReturnsAsync(existingPlan);
        planRepositorySqlMock.Setup(repo => repo.SaveChange());

        // Act
        await service.DeletePlanById(planId);

        // Assert
        planRepositorySqlMock.Verify(repo => repo.Delete(existingPlan));
    }

    [Fact]
    public async Task ShouldThrowExceptionIfDuplicateName()
    {
        // Arrange
        var planRepositorySqlMock = new Mock<IPlanRepositorySql>();
        var mapperMock = new Mock<IMapper>();
        var validatorPlanMock = new Mock<IValidatorPlan>();

        var service = new PlanService(planRepositorySqlMock.Object, mapperMock.Object, validatorPlanMock.Object);
        var createPlanRequest = MockCreateRequest();

        validatorPlanMock.Setup(validator => validator.IsValidPlanName(createPlanRequest.Category)).ReturnsAsync(true);

        // Act and Assert
        await Assert.ThrowsAsync<Exception>(() => service.AddPlan(createPlanRequest));
    }

    [Fact]
    public async Task ShouldThrowExceptionIfInvalidId()
    {
        // Arrange
        var planRepositorySqlMock = new Mock<IPlanRepositorySql>();
        var mapperMock = new Mock<IMapper>();
        var validatorPlanMock = new Mock<IValidatorPlan>();

        var service = new PlanService(planRepositorySqlMock.Object, mapperMock.Object, validatorPlanMock.Object);
        var planId = Guid.NewGuid();
        var updatePlanRequest = MockUpdateRequest();

        planRepositorySqlMock.Setup(repo => repo.FindById(planId))!.ReturnsAsync((Plan)null!);

        // Act and Assert
        await Assert.ThrowsAsync<ApplicationException>(() => service.UpdatePlanById(planId, updatePlanRequest));
    }

    [Fact]
	public async Task ShouldThrowExceptionIfNotValidEntity()
	{
	    // Arrange
	    var planRepositorySqlMock = new Mock<IPlanRepositorySql>();
	    var mapperMock = new Mock<IMapper>();
	    var validatorPlanMock = new Mock<IValidatorPlan>();

	    var service = new PlanService(planRepositorySqlMock.Object, mapperMock.Object, validatorPlanMock.Object);
	    var planId = Guid.NewGuid();
	    var updatePlanRequest = MockUpdateRequest();
	    var existingPlan = new Plan();

	    planRepositorySqlMock.Setup(repo => repo.FindById(planId)).ReturnsAsync(existingPlan);
	    validatorPlanMock.Setup(validator => validator.IsValidPlanName(updatePlanRequest.Category)).ReturnsAsync(true);

	    // Act and Assert
	    await Assert.ThrowsAsync<Exception>(() => service.UpdatePlanById(planId, updatePlanRequest));
	}

	[Fact]
	public async Task ShouldThrowExceptionIfInvalidIdIsPassToDelete()
	{
	    // Arrange
	    var planRepositorySqlMock = new Mock<IPlanRepositorySql>();
	    var mapperMock = new Mock<IMapper>();
	    var validatorPlanMock = new Mock<IValidatorPlan>();

	    var service = new PlanService(planRepositorySqlMock.Object, mapperMock.Object, validatorPlanMock.Object);
	    var planId = Guid.NewGuid();

	    planRepositorySqlMock.Setup(repo => repo.FindById(planId)).ReturnsAsync((Plan)null);

	    // Act and Assert
	    await Assert.ThrowsAsync<ApplicationException>(() => service.DeletePlanById(planId));
	}

	private CreatePlanRequest MockCreateRequest()
	{
		return new CreatePlanRequest
		{
			Amount = 80,
			Category = "academia230",
			TotalMonths = 5,
			DayOfWeeks = new DayOfWeekEnum[] { DayOfWeekEnum.Monday, DayOfWeekEnum.Tuesday, DayOfWeekEnum.Wednesday }
		};
	}

	private CreatePlanRequest MockInvalidCreateRequest()
	{
		return new CreatePlanRequest
		{
			Amount = 80,
			Category = "",
			TotalMonths = 5,
			DayOfWeeks = new List<DayOfWeekEnum>()
		};
	}

	private UpdatePlanRequest MockUpdateRequest()
	{
		return new UpdatePlanRequest
		{
			Amount = 80,
			Category = "academia23",
			TotalMonths = 5,
			DayOfWeeks = new List<DayOfWeekEnum>()
		};
	}

	private Plan MockPlan()
	{
		return new Plan
		{
			Id = Guid.Parse("08dbc5a3-7bbc-4e90-83de-c4c4207c922c"),
			Amount = 50,
			Category = "academia23",
			TotalMonths = 5,
			DayOfWeeks = "Monday,Tuesday,Wednesday",
			Users = null,
			IsActive = true
		};
	}
}