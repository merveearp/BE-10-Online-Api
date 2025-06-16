using System;
using EShop.Entity.Concrete;
using EShop.Services.Abstract;
using EShop.Shared.Dtos.AuthDtos;
using EShop.Shared.Dtos.ResponseDtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace EShop.Services.Concrete
{
    public class ApplicationUserManager : IApplicationUserService
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public ApplicationUserManager(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<ResponseDto<ApplicationUserDto>> GetByIdAsync(string applicationUserId)
        {
            try
            {
                var user = await _userManager.FindByIdAsync(applicationUserId);
                // await _userManager.Users.FirstOrDefaultAsync(x => x.Id == applicationUserId);
                if (user == null)
                {
                    return ResponseDto<ApplicationUserDto>.Fail("Kullanıcı bulunamadı", StatusCodes.Status404NotFound);
                }
                var roles = await _userManager.GetRolesAsync(user);
                var userDto = new ApplicationUserDto
                {
                    Id = user.Id,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Email = user.Email,
                    Address = user.Address,
                    City = user.City,
                    DateOfBirth = user.DateOfBirth,
                    Gender = user.Gender,
                    PhoneNumber = user.PhoneNumber,
                    UserName = user.UserName,
                    Roles = [.. roles]
                };
                return ResponseDto<ApplicationUserDto>.Success(userDto, StatusCodes.Status200OK);
            }
            catch (Exception ex)
            {
                return ResponseDto<ApplicationUserDto>.Fail(ex.Message, StatusCodes.Status500InternalServerError);
            }
        }

        public async Task<ResponseDto<NoContent>> UpdateAsync(ApplicationUserUpdateDto applicationUserUpdateDto)
        {
            try
            {
                var user = await _userManager.FindByIdAsync(applicationUserUpdateDto.Id!);
                if (user == null)
                {
                    return ResponseDto<NoContent>.Fail("Kullanıcı bulunamadı", StatusCodes.Status404NotFound);
                }
                user.FirstName = applicationUserUpdateDto.FirstName;
                user.LastName = applicationUserUpdateDto.LastName;
                user.Email = applicationUserUpdateDto.Email;
                user.PhoneNumber = applicationUserUpdateDto.PhoneNumber;
                user.Address = applicationUserUpdateDto.Address;
                user.City = applicationUserUpdateDto.City;

                var result = await _userManager.UpdateAsync(user);
                if (!result.Succeeded)
                {
                    return ResponseDto<NoContent>.Fail(string.Join(",", result.Errors.Select(e => e.Description).ToList()), StatusCodes.Status500InternalServerError);
                }
                return ResponseDto<NoContent>.Success(StatusCodes.Status200OK);
            }
            catch (Exception ex)
            {
                return ResponseDto<NoContent>.Fail(ex.Message, StatusCodes.Status500InternalServerError);
            }
        }

        public async Task<ResponseDto<IEnumerable<ApplicationUserDto>>> GetAllAsync(string? roleName = null)
        {
            try
            {
                var users =
                    roleName is null
                        ? await _userManager.Users.ToListAsync()
                        : await _userManager.GetUsersInRoleAsync(roleName);
                if (users.Count == 0)
                {
                    return ResponseDto<IEnumerable<ApplicationUserDto>>.Fail("Hiç kullanıcı bulunamadı", StatusCodes.Status404NotFound);
                }

                var applicationUserDtos = new List<ApplicationUserDto>();
                foreach (var user in users)
                {
                    var roles = await _userManager.GetRolesAsync(user);
                    applicationUserDtos.Add(new ApplicationUserDto
                    {
                        Id = user.Id,
                        FirstName = user.FirstName,
                        LastName = user.LastName,
                        Email = user.Email,
                        Address = user.Address,
                        City = user.City,
                        DateOfBirth = user.DateOfBirth,
                        Gender = user.Gender,
                        PhoneNumber = user.PhoneNumber,
                        UserName = user.UserName,
                        EmailConfirmed = user.EmailConfirmed,
                        Roles = [.. roles],
                    });
                }
                return ResponseDto<IEnumerable<ApplicationUserDto>>.Success
                    (applicationUserDtos, StatusCodes.Status200OK);
            }
            catch (Exception ex)
            {
                return ResponseDto<IEnumerable<ApplicationUserDto>>.Fail(ex.Message,
                    StatusCodes
                    .Status500InternalServerError);
            }
        }


        public async Task<ResponseDto<NoContent>> UpdateRolesForUserAsync(UpdateRolesDto updateRolesDto)
        {
            try
            {
                var user = await _userManager.FindByIdAsync(updateRolesDto.ApplicationUserId!);
                if (user == null)
                {
                    return ResponseDto<NoContent>.Fail("Kullanıcı bulunamadı", StatusCodes.Status404NotFound);
                }
                var currentRoles = await _userManager.GetRolesAsync(user);
                var result = await _userManager.RemoveFromRolesAsync(user, currentRoles);
                if (!result.Succeeded)
                {
                    return ResponseDto<NoContent>.Fail(string.Join(",", result.Errors.Select(e => e.Description).ToList()), StatusCodes.Status500InternalServerError);
                }

                result = await _userManager.AddToRolesAsync(user, updateRolesDto.Roles!);
                if (!result.Succeeded)
                {
                    return ResponseDto<NoContent>.Fail(string.Join(",", result.Errors.Select(e => e.Description).ToList()), StatusCodes.Status500InternalServerError);
                }

                return ResponseDto<NoContent>.Success(StatusCodes.Status200OK);
            }
            catch (Exception ex)
            {
                return ResponseDto<NoContent>.Fail(ex.Message, StatusCodes.Status500InternalServerError);
            }
        }

        public async Task<ResponseDto<NoContent>> AddToRoleAsync(AddRemoveRoleDto addRemoveRoleDto)
        {
            try
            {
                var user = await _userManager.FindByIdAsync(addRemoveRoleDto.ApplicationUserId!);
                if (user == null)
                {
                    return ResponseDto<NoContent>.Fail("Kullanıcı bulunamadı", StatusCodes.Status404NotFound);
                }
                var result = await _userManager.AddToRoleAsync(user, addRemoveRoleDto.ApplicationRoleName!);
                if (!result.Succeeded)
                {
                    return ResponseDto<NoContent>.Fail(string.Join(",", result.Errors.Select(e => e.Description).ToList()), StatusCodes.Status500InternalServerError);
                }
                return ResponseDto<NoContent>.Success(StatusCodes.Status200OK);
            }
            catch (Exception ex)
            {
                return ResponseDto<NoContent>.Fail(ex.Message, StatusCodes.Status500InternalServerError);
            }
        }
        public async Task<ResponseDto<NoContent>> RemoveFromRoleAsync(AddRemoveRoleDto addRemoveRoleDto)
        {
            try
            {
                var user = await _userManager.FindByIdAsync(addRemoveRoleDto.ApplicationUserId!);
                if (user == null)
                {
                    return ResponseDto<NoContent>.Fail("Kullanıcı bulunamadı", StatusCodes.Status404NotFound);
                }
                var result = await _userManager.RemoveFromRoleAsync(user, addRemoveRoleDto.ApplicationRoleName!);
                if (!result.Succeeded)
                {
                    return ResponseDto<NoContent>.Fail(string.Join(",", result.Errors.Select(e => e.Description).ToList()), StatusCodes.Status500InternalServerError);
                }
                return ResponseDto<NoContent>.Success(StatusCodes.Status200OK);
            }
            catch (Exception ex)
            {
                return ResponseDto<NoContent>.Fail(ex.Message, StatusCodes.Status500InternalServerError);
            }
        }

    }
}
