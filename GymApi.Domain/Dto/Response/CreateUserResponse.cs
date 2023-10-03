using System.ComponentModel.DataAnnotations;

namespace GymApi.Domain.Dto.Response;

public class CreateUserResponse
{
    public string Email { get; set; }
    public string UserName { get; set; }
    public DateTime DateBirth { get; set; }
    public string Address { get; set; }
    public string PhoneNumber { get; set; }
    public Guid PlanId { get; set; }
}
