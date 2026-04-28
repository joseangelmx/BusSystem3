using BusSystem.ApplicationServices.Shared.DTO.Users;
using BusSystem.Core.Users;
using Microsoft.AspNetCore.Identity;

namespace BusSystem.ApplicationServices.Users;

public class UserAppService : IUserAppService
{
    private readonly UserManager<ApplicationUser> _userManager;

    public UserAppService(UserManager<ApplicationUser> userManager)
    {
        _userManager = userManager;
    }

    public async Task<UserDTO> GetUserByIdAsync(string id)
    {
        try
        {
            var user = await _userManager.FindByIdAsync(id);

            if (user == null) return null;

            var roleName = (await _userManager.GetRolesAsync(user)).FirstOrDefault();

            return new UserDTO
            {
                Id = user.Id,
                UserName = user.UserName,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                FirstName = user.FirstName,
                LastName = user.LastName,
                DateOfBirth = user.DateOfBirth,
                Gender = user.Gender,
                Role = roleName
            };
        }
        catch (Exception ex)
        {
            throw new Exception($"GetByIdAsync Error: {ex.Message}");
        }

    }

    public async Task<List<UserDTO>> GetUsersAsync()
    {
        try
        {
            var users = _userManager.Users.ToList();

            var result = new List<UserDTO>();

            foreach (var user in users)
            {
                var roleName = (await _userManager.GetRolesAsync(user)).FirstOrDefault();

                result.Add(new UserDTO
                {
                    Id = user.Id,
                    UserName = user.UserName,
                    Email = user.Email,
                    PhoneNumber = user.PhoneNumber,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    DateOfBirth = user.DateOfBirth,
                    Gender = user.Gender,
                    Role = roleName
                });
            }

            return result;
        }
        catch (Exception ex)
        {
            throw new Exception($"GetAllAsync Error: {ex.Message}");
        }

    }

    public async Task<IdentityResult> CreateUserAsync(NewUserDto dto)
    {
        var user = new ApplicationUser
        {
            UserName = dto.Email,
            Email = dto.Email,
            FirstName = dto.FirstName,
            LastName = dto.LastName,
            DateOfBirth = dto.DateOfBirth,
            Gender = dto.Gender
        };

        var result = await _userManager.CreateAsync(user, dto.Password);

        if (result.Succeeded)
        {
            await _userManager.AddToRoleAsync(user, "User");
        }

        return result;
    }
    
    public async Task<IdentityResult> UpdateUserAsync(string id, EditUserDTO dto)
    {
        var user = await _userManager.FindByIdAsync(id);

        if (user == null)
            return IdentityResult.Failed(new IdentityError
            {
                Description = "Usuario no encontrado"
            });
        
        user.PhoneNumber = dto.PhoneNumber;
        user.FirstName = dto.FirstName;
        user.LastName = dto.LastName;
        user.Gender = dto.Gender;

        return await _userManager.UpdateAsync(user);
    }
}