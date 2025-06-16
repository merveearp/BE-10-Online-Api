using System;
using EShop.Shared.Dtos.AuthDtos;
using EShop.Shared.Dtos.ResponseDtos;

namespace EShop.Services.Abstract;

public interface IApplicationRoleService
{
    Task<ResponseDto<IEnumerable<ApplicationRoleDto>>> GetAllAsync();
    
}
