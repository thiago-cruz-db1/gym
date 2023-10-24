using System.ComponentModel.DataAnnotations;

namespace GymApi.UseCases.Dto.Request;


public class LoginUserRequest
{
    [Required]
    public string UserName { get; set; }
    [Required]
    public string Password { get; set; }
}