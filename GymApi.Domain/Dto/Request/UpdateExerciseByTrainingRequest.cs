﻿namespace GymApi.Domain.Dto.Request;

public class UpdateExerciseByTrainingRequest
{
    public Guid? ExerciseId { get; set; }
    public Guid? TrainingId { get; set; }
}