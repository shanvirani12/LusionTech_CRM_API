using LusionTech_CRM_API.DTOs;
using LusionTech_CRM_API.Entities;
using LusionTech_CRM_API.Helpers;
using LusionTech_CRM_API.Services;
using Microsoft.AspNetCore.Mvc;

namespace LusionTech_CRM_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly JwtTokenGenerator _tokenGenerator;

        public AuthController(IAuthService authService, JwtTokenGenerator tokenGenerator)
        {
            _authService = authService;
            _tokenGenerator = tokenGenerator;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDTO loginDTO)
        {
            var user = await _authService.Authenticate(loginDTO.Email, loginDTO.Password);

            if (user == null)
            {
                return Unauthorized("Invalid email or password.");
            }

            var token = _tokenGenerator.GenerateToken(user);

            return Ok(new AuthResponseDTO
            {
                Token = token,
                Email = user.Email,
                Username = user.Username
            });
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterDTO registerDTO)
        {
            var user = new User
            {
                Username = registerDTO.Username,
                Email = registerDTO.Email,
                Password = registerDTO.Password
            };

            user = await _authService.Register(user);

            if (user == null)
            {
                return BadRequest("Email already exists.");
            }

            var token = _tokenGenerator.GenerateToken(user);

            return Ok(new AuthResponseDTO
            {
                Token = token,
                Email = user.Email,
                Username = user.Username
            });
        }
    }
}
