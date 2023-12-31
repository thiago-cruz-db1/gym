﻿using AutoMapper;
using GymApi.Data.Data.Interfaces;
using GymApi.Domain;
using GymApi.UseCases.Dto.Request;

namespace GymApi.UseCases.Services;

public class ExerciseByTrainingService
{
    private readonly IExerciseByTrainingRepositorySql _contextExerciseByTraining;
    private readonly IMapper _mapper;

    public ExerciseByTrainingService(IExerciseByTrainingRepositorySql contextExerciseByTraining, IMapper mapper)
    {
        _contextExerciseByTraining = contextExerciseByTraining;
        _mapper = mapper;
    }

    public async Task<ExerciseTraining> AddExerciseTraining(CreateExerciseByTrainingRequest ExerciseTrainingDto)
    {
        var training = _mapper.Map<ExerciseTraining>(ExerciseTrainingDto);
        await _contextExerciseByTraining.Save(training);
        await _contextExerciseByTraining.SaveChange();
        return training;
    }

    public async Task<ICollection<ExerciseTraining>> GetExerciseTraining()
    {
        return await _contextExerciseByTraining.FindAll();
    }

    public async Task<ExerciseTraining> GetExerciseTrainingById(Guid id)
    {
        return await _contextExerciseByTraining.FindById(id);
    }

    public async Task<ExerciseTraining> UpdateExerciseTraining(Guid id, UpdateExerciseTrainingRequest updateExerciseTrainingDto)
    {
        var training = await _contextExerciseByTraining.FindById(id);
        if (training == null) throw new ApplicationException("training not found");
        _mapper.Map(updateExerciseTrainingDto, training);
        await _contextExerciseByTraining.Update(training);
        await _contextExerciseByTraining.SaveChange();

        return training;
    }

    public async Task DeleteExerciseTrainingById(Guid id)
    {
        var training = await _contextExerciseByTraining.FindById(id);
        await _contextExerciseByTraining.SaveChange();
        _contextExerciseByTraining.Delete(training);
    }
}