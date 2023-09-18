using Microsoft.AspNetCore.Identity;

namespace GymUserApi.Model.Dto.Request;

public class CreateDetailsUserRequest
{
    public CreateLoginUserRequest CreateLogin { get; set; }

}
