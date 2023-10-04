namespace GymApi.Domain.Dto.Request;

public class UpdateTrainingByUserRequest
{
    public Guid? UserId { get; set; }
    public Guid? TrainingId { get; set; }
    public ICollection<string>? TrainingObservation { get; set; }
}