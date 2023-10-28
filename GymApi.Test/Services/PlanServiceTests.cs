using AutoMapper;
using GymApi.Data.Data.Interfaces;
using GymApi.Data.Data.Validator.Validators;
using GymApi.Domain;
using GymApi.UseCases.Dto.Request;
using GymApi.UseCases.Services;
using Moq;
using Xunit;

namespace GymApi.Test.Services;

public class PlanServiceTests
{
	    [Fact]
    public async Task AddPlan_WithValidRequest_ShouldAddPlan()
    {
        // Arrange
        var planRepositorySqlMock = new Mock<IPlanRepositorySql>();
        var mapperMock = new Mock<IMapper>();
        var validatorPlanMock = new Mock<PlanValidator>();

        var service = new PlanService(planRepositorySqlMock.Object, mapperMock.Object, validatorPlanMock.Object);
        var createPlanRequest = new CreatePlanRequest();
        var plan = new Plan();

        validatorPlanMock.Setup(validator => validator.IsValidPlanName(createPlanRequest.Category)).ReturnsAsync(false);
        mapperMock.Setup(mapper => mapper.Map<Plan>(createPlanRequest)).Returns(plan);
        planRepositorySqlMock.Setup(repo => repo.Save(plan));
        planRepositorySqlMock.Setup(repo => repo.SaveChange());

        // Act
        var result = await service.AddPlan(createPlanRequest);

        // Assert
        Assert.Same(plan, result);
    }

    [Fact]
    public async Task UpdatePlanById_WithValidIdAndRequest_ShouldUpdatePlan()
    {
        // Arrange
        var planRepositorySqlMock = new Mock<IPlanRepositorySql>();
        var mapperMock = new Mock<IMapper>();
        var validatorPlanMock = new Mock<PlanValidator>();

        var service = new PlanService(planRepositorySqlMock.Object, mapperMock.Object, validatorPlanMock.Object);
        var planId = Guid.NewGuid();
        var updatePlanRequest = new UpdatePlanRequest();
        var existingPlan = new Plan();

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
    public async Task DeletePlanById_WithValidId_ShouldDeletePlan()
    {
        // Arrange
        var planRepositorySqlMock = new Mock<IPlanRepositorySql>();
        var mapperMock = new Mock<IMapper>();
        var validatorPlanMock = new Mock<PlanValidator>();

        var service = new PlanService(planRepositorySqlMock.Object, mapperMock.Object, validatorPlanMock.Object);
        var planId = Guid.NewGuid();
        var existingPlan = new Plan();

        planRepositorySqlMock.Setup(repo => repo.FindById(planId)).ReturnsAsync(existingPlan);
        planRepositorySqlMock.Setup(repo => repo.SaveChange());

        // Act
        await service.DeletePlanById(planId);

        // Assert
        planRepositorySqlMock.Verify(repo => repo.Delete(existingPlan));
    }

    [Fact]
    public async Task AddPlan_WithDuplicateName_ShouldThrowException()
    {
        // Arrange
        var planRepositorySqlMock = new Mock<IPlanRepositorySql>();
        var mapperMock = new Mock<IMapper>();
        var validatorPlanMock = new Mock<PlanValidator>();

        var service = new PlanService(planRepositorySqlMock.Object, mapperMock.Object, validatorPlanMock.Object);
        var createPlanRequest = new CreatePlanRequest();

        validatorPlanMock.Setup(validator => validator.IsValidPlanName(createPlanRequest.Category)).ReturnsAsync(true);

        // Act and Assert
        await Assert.ThrowsAsync<Exception>(() => service.AddPlan(createPlanRequest));
    }

    [Fact]
    public async Task UpdatePlanById_WithInvalidId_ShouldThrowException()
    {
        // Arrange
        var planRepositorySqlMock = new Mock<IPlanRepositorySql>();
        var mapperMock = new Mock<IMapper>();
        var validatorPlanMock = new Mock<PlanValidator>();

        var service = new PlanService(planRepositorySqlMock.Object, mapperMock.Object, validatorPlanMock.Object);
        var planId = Guid.NewGuid();
        var updatePlanRequest = new UpdatePlanRequest();

        planRepositorySqlMock.Setup(repo => repo.FindById(planId))!.ReturnsAsync((Plan)null!);

        // Act and Assert
        await Assert.ThrowsAsync<ApplicationException>(() => service.UpdatePlanById(planId, updatePlanRequest));
    }

    [Fact]
	public async Task UpdatePlanById_WithValidationFailure_ShouldThrowException()
	{
	    // Arrange
	    var planRepositorySqlMock = new Mock<IPlanRepositorySql>();
	    var mapperMock = new Mock<IMapper>();
	    var validatorPlanMock = new Mock<PlanValidator>();

	    var service = new PlanService(planRepositorySqlMock.Object, mapperMock.Object, validatorPlanMock.Object);
	    var planId = Guid.NewGuid();
	    var updatePlanRequest = new UpdatePlanRequest();
	    var existingPlan = new Plan();

	    planRepositorySqlMock.Setup(repo => repo.FindById(planId)).ReturnsAsync(existingPlan);
	    validatorPlanMock.Setup(validator => validator.IsValidPlanName(updatePlanRequest.Category)).ReturnsAsync(true);

	    // Act and Assert
	    await Assert.ThrowsAsync<Exception>(() => service.UpdatePlanById(planId, updatePlanRequest));
	}

	[Fact]
	public async Task DeletePlanById_WithInvalidId_ShouldThrowException()
	{
	    // Arrange
	    var planRepositorySqlMock = new Mock<IPlanRepositorySql>();
	    var mapperMock = new Mock<IMapper>();
	    var validatorPlanMock = new Mock<PlanValidator>();

	    var service = new PlanService(planRepositorySqlMock.Object, mapperMock.Object, validatorPlanMock.Object);
	    var planId = Guid.NewGuid();

	    planRepositorySqlMock.Setup(repo => repo.FindById(planId)).ReturnsAsync((Plan)null);

	    // Act and Assert
	    await Assert.ThrowsAsync<ApplicationException>(() => service.DeletePlanById(planId));
	}

	[Fact]
	public async Task AddPlan_WithValidationFailure_ShouldThrowException()
	{
	    // Arrange
	    var planRepositorySqlMock = new Mock<IPlanRepositorySql>();
	    var mapperMock = new Mock<IMapper>();
	    var validatorPlanMock = new Mock<PlanValidator>();

	    var service = new PlanService(planRepositorySqlMock.Object, mapperMock.Object, validatorPlanMock.Object);
	    var createPlanRequest = new CreatePlanRequest();

	    validatorPlanMock.Setup(validator => validator.IsValidPlanName(createPlanRequest.Category)).Throws(new Exception("plan with this name already exist"));

	    // Act and Assert
	    await Assert.ThrowsAsync<Exception>(() => service.AddPlan(createPlanRequest));
	}
}