using System;
using EShop.Entity.Concrete;
using EShop.Services.Abstract;
using EShop.Shared.Dtos.AuthDtos;
using EShop.Shared.Dtos.ResponseDtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace EShop.Services.Concrete;

public class ApplicationRoleManager : IApplicationRoleService
{
    private readonly RoleManager<ApplicationRole> _roleManager;

    public ApplicationRoleManager(RoleManager<ApplicationRole> roleManager)
    {
        _roleManager = roleManager;
    }

    public async Task<ResponseDto<IEnumerable<ApplicationRoleDto>>> GetAllAsync()
    {
        try
        {
            var roles = await _roleManager.Roles.ToListAsync();
            if (roles.Count == 0)
            {
                return ResponseDto<IEnumerable<ApplicationRoleDto>>.Fail("Hiç rol bulunamadı", StatusCodes.Status404NotFound);
            }
            var roleDtos = roles.Select(x => new ApplicationRoleDto
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description
            }).ToList();
            return ResponseDto<IEnumerable<ApplicationRoleDto>>.Success(roleDtos, StatusCodes.Status200OK);
        }
        catch (Exception ex)
        {
            return ResponseDto<IEnumerable<ApplicationRoleDto>>.Fail(ex.Message, StatusCodes.Status500InternalServerError);
        }
    }
}
