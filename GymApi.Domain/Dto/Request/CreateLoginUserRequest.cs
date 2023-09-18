using System.ComponentModel.DataAnnotations;

namespace GymApi.Domain.Dto.Request;

public class CreateLoginUserRequest
{
    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; }
    
    [Compare("Password")]
    public string PasswordConfirmation { get; set; }
    
    public DateTime? DetailCompleted { get; set; }
}
