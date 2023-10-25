using System.Text;
using AutoMapper;
using GymApi.Data.Data.Interfaces;
using GymApi.Data.Data.Validator;
using GymApi.Data.Data.Validator.Interfaces;
using GymApi.Domain;
using GymApi.UseCases.Dto.Request;
using GymApi.UseCases.Interfaces;
using Microsoft.AspNetCore.Http;

namespace GymApi.UseCases.Services;

public class ExerciseService : AbstractExerciseValidator
{
    private readonly IMapper _mapper;
    private readonly IExerciseRepositorySql _contextExercise;
    private readonly IExcelReader _excelReader;

    public ExerciseService(IExerciseRepositorySql contextExercise,IMapper mapper, IExcelReader excelReader, IValidatorExercise validatorExercise) :base(validatorExercise)
    {
        _contextExercise = contextExercise;
        _mapper = mapper;
        _excelReader = excelReader;
    }
    public async Task<Exercise> AddExercise(CreateExerciseRequest exerciseDto)
    {
        var exercise = _mapper.Map<Exercise>(exerciseDto);
        if(DuplicateExercise(exercise)) throw new Exception("exercise already exists");
        exercise.Validate();
        await _contextExercise.Save(exercise);
        await _contextExercise.SaveChange();
        return exercise;
    }

    public async Task<ICollection<Exercise>> GetExercise()
    {
        return await _contextExercise.FindAll();
    }

    public async Task<Exercise> GetExerciseById(Guid id)
    {
        return await _contextExercise.FindById(id);
    }

    public async Task<Exercise> UpdateExercise(Guid id, UpdateExerciseRequest updateExerciseDto)
    {
        var exercise = await _contextExercise.FindById(id);
        if (exercise == null) throw new ApplicationException("exercise not found");
        var ex =_mapper.Map(updateExerciseDto, exercise);
        ex.Validate();
        await _contextExercise.Update(exercise);
        await _contextExercise.SaveChange();
        return exercise;
    }

    public async Task DeleteExerciseById(Guid id)
    {
        var training = await _contextExercise.FindById(id);
        _contextExercise.Delete(training);
        await _contextExercise.SaveChange();
    }

    public async Task<bool> UploadTableOfExercise(IFormFile file)
    {
	    Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

	    var upload = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Uploads");
	    if (!Directory.Exists(upload))
	    {
		    Directory.CreateDirectory(upload);
	    }

	    var filePath = Path.Combine(upload, Path.GetFileName(file.FileName));

	    using (var stream = new FileStream(filePath, FileMode.Create))
	    {
		    await file.CopyToAsync(stream);
	    }

	    await using (var stream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
	    {
		    var exercises = await _excelReader.ReadExercises(stream);

		    foreach (var exercise in exercises)
		    {
			    await _contextExercise.Save(exercise);
		    }
	    }
	    await _contextExercise.SaveChange();
	    return true;
    }
}