using EShop.Services.Abstract;
using EShop.Shared.ControllerBases;
using EShop.Shared.Dtos.AuthDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EShop.API.Controllers
{
    [Authorize]
    [Route("api/users")]
    [ApiController]
    public class ApplicationUsersController : CustomControllerBase
    {
        private readonly IApplicationUserService _applicationUserManager;

        public ApplicationUsersController(IApplicationUserService applicationUserManager)
        {
            _applicationUserManager = applicationUserManager;
        }

        [HttpGet("me")]
        public async Task<IActionResult> GetMyProfile()
        {
            var response = await _applicationUserManager.GetByIdAsync(GetUserId());
            return CreateResult(response);
        }


        [HttpPut("me")]
        public async Task<IActionResult> UpdateMyProfile([FromBody] ApplicationUserUpdateDto applicationUserUpdateDto)
        {
            applicationUserUpdateDto.Id = GetUserId();
            var response = await _applicationUserManager.UpdateAsync(applicationUserUpdateDto);
            return CreateResult(response);
        }

        [HttpGet("{applicationUserId}")]
        public async Task<IActionResult> GetById(string applicationUserId)
        {
            var response = await _applicationUserManager.GetByIdAsync(applicationUserId);
            return CreateResult(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] string? roleName = null)
        {
            var response = await _applicationUserManager.GetAllAsync(roleName);
            return CreateResult(response);
        }

        [HttpPut("assign-role")]
        public async Task<IActionResult> UpdateRolesForUser(UpdateRolesDto updateRolesDto)
        {
            var response = await _applicationUserManager.UpdateRolesForUserAsync(updateRolesDto);
            return CreateResult(response);
        }

        [HttpPut("addtorole")]
        public async Task<IActionResult> AddToRoleAsync(AddRemoveRoleDto addRemoveRoleDto)
        {
            var response = await _applicationUserManager.AddToRoleAsync(addRemoveRoleDto);
            return CreateResult(response);
        }

        [HttpPut("removefromrole")]
        public async Task<IActionResult> RemoveFromRoleAsync(AddRemoveRoleDto addRemoveRoleDto)
        {
            var response = await _applicationUserManager.RemoveFromRoleAsync(addRemoveRoleDto);
            return CreateResult(response);
        }
    }
}
