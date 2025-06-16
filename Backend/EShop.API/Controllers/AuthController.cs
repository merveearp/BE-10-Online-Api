using System.Security.AccessControl;
using EShop.Services.Abstract;
using EShop.Shared.ControllerBases;
using EShop.Shared.Dtos.AuthDtos;
using Microsoft.AspNetCore.Mvc;

namespace EShop.API.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : CustomControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto loginDto)
        {
            var response = await _authService.LoginAsync(loginDto);
            return CreateResult(response);
        }


        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterDto registerDto)
        {
            var response = await _authService.RegisterAsync(registerDto);
            return CreateResult(response);
        }

        [HttpPost("confirm")]
        public async Task<IActionResult> ConfirmAccount([FromQuery] ConfirmAccountDto confirmAccountDto)
        {
            var response = await _authService.ConfirmAccountAsync(confirmAccountDto);
            return CreateResult(response);
        }

        [HttpPut("confirm")]
        public async Task<IActionResult> ConfirmEmail([FromQuery] string email)
        {
            var response = await _authService.ConfirmEmailAsync(email);
            return CreateResult(response);
        }

        [HttpPost("password")]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordDto forgotPasswordDto)
        {
            var response = await _authService.ForgotPasswordAsync(forgotPasswordDto);
            return CreateResult(response);
        }

        [HttpPost("reset")]
        public async Task<IActionResult> ResetPassword(ResetPasswordDto resetPasswordDto)
        {
            var response = await _authService.ResetPasswordAsync(resetPasswordDto);
            return CreateResult(response);
        }

        [HttpPut("password")]
        public async Task<IActionResult> ChangePassword(ChangePasswordDto changePasswordDto)
        {
            changePasswordDto.ApplicationUserId = GetUserId();
            var response = await _authService.ChangePasswordAsync(changePasswordDto);
            return CreateResult(response);
        }

    }
}
