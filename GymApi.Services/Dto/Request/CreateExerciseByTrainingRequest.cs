namespace GymApi.UseCases.Dto.Request;

public class CreateExerciseByTrainingRequest
{
    public Guid ExerciseId { get; set; }
    public Guid TrainingId { get; set; }
}