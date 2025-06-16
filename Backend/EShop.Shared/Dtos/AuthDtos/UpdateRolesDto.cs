using System;
using System.ComponentModel.DataAnnotations;

namespace EShop.Shared.Dtos.AuthDtos;

public class UpdateRolesDto
{
    [Required(ErrorMessage = "Kullanıcı id bilgisi zorunludur!")]
    public string? ApplicationUserId { get; set; }

    [Required(ErrorMessage = "En az bir rol girilmelidir!")]
    public List<string>? Roles { get; set; }
}
