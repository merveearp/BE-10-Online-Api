using EShop.Services.Abstract;
using EShop.Shared.ControllerBases;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EShop.API.Controllers
{
    [Route("api/roles")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class ApplicationRolesController : CustomControllerBase
    {
        private readonly IApplicationRoleService _applicationRoleManager;

        public ApplicationRolesController(IApplicationRoleService applicationRoleManager)
        {
            _applicationRoleManager = applicationRoleManager;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var response = await _applicationRoleManager.GetAllAsync();
            return CreateResult(response);
        }
    }
}
