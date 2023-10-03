using GymApi.Domain;
using GymApi.Domain.Dto.Request;
using GymApi.UseCases;
using GymApi.UseCases.Services;
using Microsoft.AspNetCore.Mvc;

namespace GymUserApi.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class CreateUserController : ControllerBase
    {
        private readonly CreateUserService _createUserService;
        
        public CreateUserController(CreateUserService serviceService, GenerateTokenService generateTokenService)
        {
            _createUserService = serviceService;
        }
    
        [HttpPost]
        public async Task<IActionResult> CreateLogin(CreateUserRequest createDto)
        {
            var user = await _createUserService.Create(createDto);

            return Ok(user);
        }
        
        [HttpGet]
        public IActionResult GetUser()
        {
            try
            {
                var users = _createUserService.GetUsers();
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
