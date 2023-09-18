using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;

namespace GymUserApi.Model;

public class CreateLoginUserRequest
{
    [Required]
    public string Email { get; set; }
    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; }
    [Compare("Password")]
    public string PasswordConfirmation { get; set; }
    
    public DateTime? DetailCompleted { get; set; }
}
