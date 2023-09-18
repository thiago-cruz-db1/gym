using GymApi.Domain.Dto.Request;
using GymApi.UseCases;
using Microsoft.AspNetCore.Mvc;
using CreateUserUseCase = GymApi.UseCases.CreateUserUseCase;

namespace GymUserApi.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class CreateUserController : ControllerBase
    {
        private readonly CreateUserUseCase _createUserUseCase;


        public CreateUserController(CreateUserUseCase useCaseUseCase, GenerateTokenUseCase generateTokenUseCase)
        {
            _createUserUseCase = useCaseUseCase;

        }
    
        [HttpPost]
        public async Task<IActionResult> CreateLogin(CreateLoginUserRequest createLoginDto)
        {
            await _createUserUseCase.Create(createLoginDto);

            return Ok("user created");
        }
    }
}
