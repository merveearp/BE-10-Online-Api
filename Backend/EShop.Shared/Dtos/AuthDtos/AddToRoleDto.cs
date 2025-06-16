using System;

namespace EShop.Shared.Dtos.AuthDtos;

public class AddRemoveRoleDto
{
    public string? ApplicationUserId { get; set; }
    public string? ApplicationRoleName { get; set; }
}
