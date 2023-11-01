using AutoMapper;
using GymApi.Data.Data.Interfaces;
using GymApi.Data.Data.Validator.Interfaces;
using GymApi.Domain;
using GymApi.UseCases.Dto.Request;
using GymApi.UseCases.Interfaces;
using GymApi.UseCases.Services;
using Microsoft.AspNetCore.Http;
using Moq;
using Xunit;

namespace GymApi.Test.Services;

public class ExerciseServiceTests
{
	[Fact]
	public async Task AddExercise_WithValidRequest_ShouldAddExercise()
	{
		// Arrange
		var exerciseRepositorySqlMock = new Mock<IExerciseRepositorySql>();
		var mapperMock = new Mock<IMapper>();
		var validatorExerciseMock = new Mock<IValidatorExercise>();
		var excelReaderMock = new Mock<IExcelReader>();

		var service = new ExerciseService(exerciseRepositorySqlMock.Object, mapperMock.Object, excelReaderMock.Object, validatorExerciseMock.Object);
		var createExerciseRequest = MockCreateRequest();
		var exercise = MockExercise();

		mapperMock.Setup(mapper => mapper.Map<Exercise>(createExerciseRequest)).Returns(exercise);
		validatorExerciseMock.Setup(validator => validator.DuplicateExercise(exercise)).Returns(false);

		exerciseRepositorySqlMock.Setup(repo => repo.Save(exercise));
		exerciseRepositorySqlMock.Setup(repo => repo.SaveChange());

		// Act
		var result = await service.AddExercise(createExerciseRequest);

		// Assert
		Assert.Same(exercise, result);
	}

	[Fact]
	public async Task AddExercise_WithDuplicateExercise_ShouldThrowException()
	{
		// Arrange
		var exerciseRepositorySqlMock = new Mock<IExerciseRepositorySql>();
		var mapperMock = new Mock<IMapper>();
		var validatorExerciseMock = new Mock<IValidatorExercise>();
		var excelReaderMock = new Mock<IExcelReader>();

		var service = new ExerciseService(exerciseRepositorySqlMock.Object, mapperMock.Object, excelReaderMock.Object, validatorExerciseMock.Object);
		var createExerciseRequest = new CreateExerciseRequest();
		var exercise = new Exercise();

		mapperMock.Setup(mapper => mapper.Map<Exercise>(createExerciseRequest)).Returns(exercise);
		validatorExerciseMock.Setup(validator => validator.DuplicateExercise(exercise)).Returns(true);

		// Act and Assert
		await Assert.ThrowsAsync<Exception>(() => service.AddExercise(createExerciseRequest));
	}

	[Fact]
	public async Task GetExercise_ShouldReturnCollectionOfExercises()
	{
		// Arrange
		var exerciseRepositorySqlMock = new Mock<IExerciseRepositorySql>();
		var mapperMock = new Mock<IMapper>();
		var validatorExerciseMock = new Mock<IValidatorExercise>();
		var excelReaderMock = new Mock<IExcelReader>();

		var service = new ExerciseService(exerciseRepositorySqlMock.Object, mapperMock.Object, excelReaderMock.Object, validatorExerciseMock.Object);
		var expectedExercises = new List<Exercise>();

		exerciseRepositorySqlMock.Setup(repo => repo.FindAll()).ReturnsAsync(expectedExercises);

		// Act
		var result = await service.GetExercise();

		// Assert
		Assert.Same(expectedExercises, result);
	}

	[Fact]
	public async Task GetExerciseById_WithValidId_ShouldReturnExercise()
	{
		// Arrange
		var exerciseRepositorySqlMock = new Mock<IExerciseRepositorySql>();
		var mapperMock = new Mock<IMapper>();
		var validatorExerciseMock = new Mock<IValidatorExercise>();
		var excelReaderMock = new Mock<IExcelReader>();

		var service = new ExerciseService(exerciseRepositorySqlMock.Object, mapperMock.Object, excelReaderMock.Object, validatorExerciseMock.Object);
		var exerciseId = Guid.NewGuid();
		var expectedExercise = MockExercise();

		exerciseRepositorySqlMock.Setup(repo => repo.FindById(exerciseId)).ReturnsAsync(expectedExercise);

		// Act
		var result = await service.GetExerciseById(exerciseId);

		// Assert
		Assert.Same(expectedExercise, result);
	}

	[Fact]
	public async Task UpdateExercise_WithValidIdAndRequest_ShouldUpdateExercise()
	{
		// Arrange
		var exerciseRepositorySqlMock = new Mock<IExerciseRepositorySql>();
		var mapperMock = new Mock<IMapper>();
		var validatorExerciseMock = new Mock<IValidatorExercise>();
		var excelReaderMock = new Mock<IExcelReader>();

		var service = new ExerciseService(exerciseRepositorySqlMock.Object, mapperMock.Object, excelReaderMock.Object, validatorExerciseMock.Object);
		var exerciseId = Guid.Parse("08dbc5a3-7bbc-4e90-83de-c4c4207c922c");
		var updateExerciseRequest = MockUpdateRequest();
		var existingExercise = MockExercise();

		exerciseRepositorySqlMock.Setup(repo => repo.FindById(exerciseId)).ReturnsAsync(existingExercise);
		mapperMock.Setup(mapper => mapper.Map(updateExerciseRequest, existingExercise));

		exerciseRepositorySqlMock.Setup(repo => repo.Update(existingExercise));
		exerciseRepositorySqlMock.Setup(repo => repo.SaveChange());

		// Act
		var result = await service.UpdateExercise(exerciseId, updateExerciseRequest);

		// Assert
		Assert.Same(existingExercise, result);
	}

	[Fact]
	public async Task UpdateExercise_WithDuplicateExercise_ShouldThrowException()
	{
		// Arrange
		var exerciseRepositorySqlMock = new Mock<IExerciseRepositorySql>();
		var mapperMock = new Mock<IMapper>();
		var validatorExerciseMock = new Mock<IValidatorExercise>();
		var excelReaderMock = new Mock<IExcelReader>();

		var service = new ExerciseService(exerciseRepositorySqlMock.Object, mapperMock.Object, excelReaderMock.Object, validatorExerciseMock.Object);
		var exerciseId = Guid.Parse("08dbc5a3-7bbc-4e90-83de-c4c4207c922c");
		var updateExerciseRequest = MockUpdateRequest();
		var existingExercise = MockExercise();

		exerciseRepositorySqlMock.Setup(repo => repo.FindById(exerciseId)).ReturnsAsync(existingExercise);
		mapperMock.Setup(mapper => mapper.Map(updateExerciseRequest, existingExercise));
		var duplicate = validatorExerciseMock.Setup(validator => validator.DuplicateExercise(existingExercise)).Returns(true);

		// Act and Assert
		await Assert.ThrowsAsync<Exception>(() => service.UpdateExercise(exerciseId, updateExerciseRequest));
	}

	[Fact]
	public async Task DeleteExerciseById_ShouldDeleteExercise()
	{
		// Arrange
		var exerciseRepositorySqlMock = new Mock<IExerciseRepositorySql>();
		var mapperMock = new Mock<IMapper>();
		var validatorExerciseMock = new Mock<IValidatorExercise>();
		var excelReaderMock = new Mock<IExcelReader>();

		var service = new ExerciseService(exerciseRepositorySqlMock.Object, mapperMock.Object, excelReaderMock.Object, validatorExerciseMock.Object);
		var exerciseId = Guid.Parse("08dbc5a3-7bbc-4e90-83de-c4c4207c922c");
		var existingExercise = MockExercise();

		exerciseRepositorySqlMock.Setup(repo => repo.FindById(exerciseId)).ReturnsAsync(existingExercise);
		exerciseRepositorySqlMock.Setup(repo => repo.SaveChange());

		// Act
		await service.DeleteExerciseById(exerciseId);

		// Assert
		exerciseRepositorySqlMock.Verify(repo => repo.Delete(existingExercise));
	}

	[Fact]
	public async Task UploadTableOfExercise_WithValidFile_ShouldUploadAndReturnTrue()
	{
		// Arrange
		var exerciseRepositorySqlMock = new Mock<IExerciseRepositorySql>();
		var mapperMock = new Mock<IMapper>();
		var validatorExerciseMock = new Mock<IValidatorExercise>();
		var excelReaderMock = new Mock<IExcelReader>();

		var service = new ExerciseService(exerciseRepositorySqlMock.Object, mapperMock.Object, excelReaderMock.Object, validatorExerciseMock.Object);
		var file = new Mock<IFormFile>();

		excelReaderMock.Setup(reader => reader.ReadExercises(It.IsAny<Stream>())).ReturnsAsync(new List<Exercise>());

		// Act
		var result = await service.UploadTableOfExercise(file.Object);

		// Assert
		Assert.True(result);
	}

	[Fact]
	public async Task UploadTableOfExercise_WithInvalidFile_ShouldThrowException()
	{
		// Arrange
		var exerciseRepositorySqlMock = new Mock<IExerciseRepositorySql>();
		var mapperMock = new Mock<IMapper>();
		var validatorExerciseMock = new Mock<IValidatorExercise>();
		var excelReaderMock = new Mock<IExcelReader>();

		var service = new ExerciseService(exerciseRepositorySqlMock.Object, mapperMock.Object, excelReaderMock.Object, validatorExerciseMock.Object);
		var file = new Mock<IFormFile>();

		excelReaderMock.Setup(reader => reader.ReadExercises(It.IsAny<Stream>())).Throws<Exception>();

		// Act and Assert
		await Assert.ThrowsAsync<ArgumentNullException>(() => service.UploadTableOfExercise(file.Object));
	}

	private CreateExerciseRequest MockCreateRequest()
	{
		return new CreateExerciseRequest
		{
			Machine = "supino",
			Pause = 30,
			Set = 4,
			Repetition = 15,
			Technique = "nenhuma",
		};
	}

	private UpdateExerciseRequest MockUpdateRequest()
	{
		return new UpdateExerciseRequest
		{
			Machine = "supino",
			Pause = 30,
			Set = 4,
			Repetition = 15,
			Technique = "nenhuma",
		};
	}

	private Exercise MockExercise()
	{
		return new Exercise
		{
			Id = Guid.Parse("08dbc5a3-7bbc-4e90-83de-c4c4207c922c"),
			Machine = "supino",
			Pause = 30,
			Set = 4,
			Repetition = 15,
			Technique = "nenhuma",
			ExerciseTrainings = null
		};
	}
}