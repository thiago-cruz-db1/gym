using System.ComponentModel.DataAnnotations;

namespace GymApi.Domain.Dto.Request;

public class CreateLoginUserRequest
{
    [Required]
    public string Email { get; set; }
    [Required]
    public string UserName { get; set; }
    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; }
    [Compare("Password")]
    public string PasswordConfirmation { get; set; }
    public DateTime? CreateAt { get; set; } = DateTime.Now;
    [Required]
    public DateTime DateBirth { get; set; }
    [Required]
    public string Address { get; set; }
    [Required]
    public string PhoneNumber { get; set; }

    public Guid PlanId { get; set; }
    public Guid PersonalTrainerId { get; set; }
    public List<Guid> TrainingId { get; set; }
}
