﻿namespace GymApi.Domain.Dto.Request;

public class UpdateExerciseTrainingRequest
{
    public Guid? ExerciseId { get; set; }
    public Guid? TrainingId { get; set; }
}