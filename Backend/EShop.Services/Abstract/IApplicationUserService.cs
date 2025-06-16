using System;
using EShop.Shared.Dtos.AuthDtos;
using EShop.Shared.Dtos.ResponseDtos;

namespace EShop.Services.Abstract
{
    public interface IApplicationUserService
    {
        Task<ResponseDto<ApplicationUserDto>> GetByIdAsync(string applicationUserId);
        Task<ResponseDto<NoContent>> UpdateAsync(ApplicationUserUpdateDto applicationUserUpdateDto);
        Task<ResponseDto<IEnumerable<ApplicationUserDto>>> GetAllAsync(string? roleName = null);
        Task<ResponseDto<NoContent>> UpdateRolesForUserAsync(UpdateRolesDto updateRolesDto);
        Task<ResponseDto<NoContent>> AddToRoleAsync(AddRemoveRoleDto addRemoveRoleDto);
        Task<ResponseDto<NoContent>> RemoveFromRoleAsync(AddRemoveRoleDto addRemoveRoleDto);
    }
}
