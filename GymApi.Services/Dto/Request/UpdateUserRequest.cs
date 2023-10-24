namespace GymApi.UseCases.Dto.Request;

public class UpdateUserRequest
{
    public string? Email { get; set; }
    public string? UserName { get; set; }
    public string? Password { get; set; }
    public int? TrainingDays { get; set; }
    public string? PasswordConfirmation { get; set; }
    public DateTime? DateBirth { get; set; }
    public string? Address { get; set; }
    public string? PhoneNumber { get; set; }
}