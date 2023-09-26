using GymApi.Domain;
using GymApi.Domain.Dto.Request;
using GymApi.UseCases;
using GymApi.UseCases.UserUseCase;
using Microsoft.AspNetCore.Mvc;

namespace GymUserApi.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class CreateUserController : ControllerBase
    {
        private readonly CreateUserService _createUserService;
        
        public CreateUserController(CreateUserService serviceService, GenerateTokenUseCase generateTokenUseCase)
        {
            _createUserService = serviceService;
        }
    
        [HttpPost]
        public async Task<IActionResult> CreateLogin(CreateLoginUserRequest createLoginDto)
        {
            await _createUserService.Create(createLoginDto);

            return Ok("user created");
        }
        
        [HttpGet]
        public async Task<IActionResult> GetUser()
        {
            try
            {
                var users = await _createUserService.GetUsers();
                return Ok(users) ;
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }
        }

        [HttpGet("{userId}")]
        public async Task<IActionResult> GetUser(string userId)
        {
            try
            {
                var user = await _createUserService.GetUserById(userId);
                if (user == null)
                    return NotFound("User not found");
                return Ok(user);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }
        }

        [HttpPut("{userId}")]
        public async Task<IActionResult> UpdateUser(string userId, [FromBody] UpdateUserRequest updateUserDto)
        {
            try
            {
                await _createUserService.Update(userId, updateUserDto);
                return Ok("User updated successfully");
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }
        }

        [HttpDelete("{userId}")]
        public async Task<IActionResult> DeleteUser(string userId)
        {
            try
            {
                await _createUserService.Delete(userId);
                return Ok("User deleted successfully");
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }
        }
    }
}
