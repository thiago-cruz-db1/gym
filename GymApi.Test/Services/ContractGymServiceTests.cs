using AutoMapper;
using GymApi.Data.Data.Interfaces;
using GymApi.Domain;
using GymApi.UseCases.Dto.Request;
using GymApi.UseCases.Services;
using Moq;
using Xunit;

namespace GymApi.Test.Services;

public class ContractGymServiceTests
{
	[Fact]
	public async Task GetAsync_ShouldReturnListOfContracts()
	{
		// Arrange
		var contractRepositoryNoSqlMock = new Mock<IContractRepositoryNoSql>();
		var mapperMock = new Mock<IMapper>();

		var service = new ContractGymService(contractRepositoryNoSqlMock.Object, mapperMock.Object);
		var expectedContracts = new List<Contract>();

		contractRepositoryNoSqlMock.Setup(repo => repo.FindAll()).ReturnsAsync(expectedContracts);

		// Act
		var result = await service.GetAsync();

		// Assert
		Assert.Same(expectedContracts, result);
	}

	[Fact]
	public async Task GetAsync_WithValidId_ShouldReturnContract()
	{
		// Arrange
		var contractRepositoryNoSqlMock = new Mock<IContractRepositoryNoSql>();
		var mapperMock = new Mock<IMapper>();

		var service = new ContractGymService(contractRepositoryNoSqlMock.Object, mapperMock.Object);
		var expectedContract = new Contract();
		string contractId = "123";

		contractRepositoryNoSqlMock.Setup(repo => repo.FindById(contractId)).ReturnsAsync(expectedContract);

		// Act
		var result = await service.GetAsync(contractId);

		// Assert
		Assert.Same(expectedContract, result);
	}

	[Fact]
	public async Task CreateAsync_WithValidContractRequest_ShouldCreateContract()
	{
		// Arrange
		var contractRepositoryNoSqlMock = new Mock<IContractRepositoryNoSql>();
		var mapperMock = new Mock<IMapper>();

		var service = new ContractGymService(contractRepositoryNoSqlMock.Object, mapperMock.Object);
		var newContractRequest = new CreateContractRequest();
		var expectedContract = new Contract();

		mapperMock.Setup(mapper => mapper.Map<Contract>(newContractRequest)).Returns(expectedContract);

		// Act
		await service.CreateAsync(newContractRequest);

		// Assert
		contractRepositoryNoSqlMock.Verify(repo => repo.Save(expectedContract), Times.Once);
	}

	[Fact]
	public async Task UpdateAsync_WithValidIdAndRequest_ShouldUpdateContract()
	{
		// Arrange
		var contractRepositoryNoSqlMock = new Mock<IContractRepositoryNoSql>();
		var mapperMock = new Mock<IMapper>();

		var service = new ContractGymService(contractRepositoryNoSqlMock.Object, mapperMock.Object);
		string contractId = "123";
		var updatedContractRequest = new UpdateContractRequest();
		var updatedContract = new Contract();

		mapperMock.Setup(mapper => mapper.Map<Contract>(updatedContractRequest)).Returns(updatedContract);

		// Act
		await service.UpdateAsync(contractId, updatedContractRequest);

		// Assert
		contractRepositoryNoSqlMock.Verify(repo => repo.Update(contractId, updatedContract), Times.Once);
	}

	[Fact]
	public async Task RemoveAsync_WithValidId_ShouldRemoveContract()
	{
		// Arrange
		var contractRepositoryNoSqlMock = new Mock<IContractRepositoryNoSql>();
		var mapperMock = new Mock<IMapper>();

		var service = new ContractGymService(contractRepositoryNoSqlMock.Object, mapperMock.Object);
		string contractId = "123";
		var expectedContract = new Contract();

		contractRepositoryNoSqlMock.Setup(repo => repo.FindById(contractId)).ReturnsAsync(expectedContract);

		// Act
		await service.RemoveAsync(contractId);

		// Assert
		contractRepositoryNoSqlMock.Verify(repo => repo.Delete(contractId, expectedContract), Times.Once);
	}
}