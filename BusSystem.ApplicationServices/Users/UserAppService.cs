using AutoMapper;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;
using BusSystem.ApplicationServices.Shared.DTO.Users;
using BusSystem.ApplicationServices.Users;
using BusSystem.Core.Users;
using BusSystem.DataAccess;
using Microsoft.Extensions.Logging;


namespace Luxottica.ApplicationServices.Users
{
    public class UserAppService : IUserAppService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly BusContext _context;
        private readonly IMapper _mapper;
        private readonly RoleManager<IdentityRole> _roleManager;

        public UserAppService(UserManager<ApplicationUser> userManager, BusContext context, IMapper mapper, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _context = context;
            _mapper = mapper;
            _roleManager = roleManager;
        }


        public async Task<List<UserDTO>> GetUsersAsync()
        {
            try
            {
                List<ApplicationUser> users = await _userManager.Users.ToListAsync();

                List<UserDTO> usersDto = new List<UserDTO>();

                foreach (var user in users)
                {
                    var roleName = (await _userManager.GetRolesAsync(user)).FirstOrDefault(); 

                    var userDto = new UserDTO
                    {
                        Id = user.Id,
                        FirstName = user.FirstName,
                        LastName = user.LastName,
                        DateOfBirth = user.DateOfBirth,
                        Gender =  user.Gender,
                        PhoneNumber = user.PhoneNumber,
                        Email = user.Email,
                        Role = roleName
                    };
                    usersDto.Add(userDto);
                }
                return usersDto;
            }
            catch (Exception ex)
            {
                throw new Exception($"GetUsersAsync unsuccessful. Error: {ex.Message}");
            }
        }

        public async Task<UserDTO> GetUserAsync(string id)
        {
            try
            {
                var user = await _userManager.Users
                    .FirstOrDefaultAsync(x => x.Id == id);

                if (user == null)
                {
                    throw new Exception("User not found");
                }

                var roleName = (await _userManager.GetRolesAsync(user)).FirstOrDefault();

                var userDto = new UserDTO
                {
                    Id = user.Id,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    DateOfBirth = user.DateOfBirth,
                    Gender = user.Gender,
                    PhoneNumber = user.PhoneNumber,
                    Email = user.Email,
                    Role = roleName ?? "NoRole"
                };

                return userDto;
            }
            catch (Exception ex)
            {
                throw new Exception($"GetUserAsync unsuccessful. Error: {ex.Message}");
            }
        }

        public async Task AddUserAsync(NewUserDTO userDto)
        {
                var existingUserByEmail = await _userManager.FindByEmailAsync(userDto.Email);
                if (existingUserByEmail != null)
                    throw new Exception("Email already exists");

                var u = _mapper.Map<ApplicationUser>(userDto);

                u.UserName = userDto.Email; // 🔥 CLAVE

                if (!await _roleManager.RoleExistsAsync(userDto.RoleNameAssignment))
                    throw new Exception("Role does not exist");

                var result = await _userManager.CreateAsync(u, userDto.Password);

                if (!result.Succeeded)
                {
                    var errors = string.Join(", ", result.Errors.Select(e => e.Description));
                    throw new Exception(errors);
                }

                await _userManager.AddToRoleAsync(u, userDto.RoleNameAssignment);
            }
        

        public async Task EditUserAsync(string id, EditUserDTO userDto)
        {
            try
            {
                var user = await _userManager.FindByIdAsync(id);
                var roleName = (await _userManager.GetRolesAsync(user)).FirstOrDefault();
                if (user == null)
                {
                    throw new InvalidOperationException("User not found!..");
                }
                

                if (userDto.PhoneNumber.Length != 10 || !userDto.PhoneNumber.All(char.IsDigit))
                {
                    throw new InvalidOperationException("Phone Number is invalid!. The phone number must be in 10 digit format.");
                }

                user.PhoneNumber = userDto.PhoneNumber;
                user.Email = userDto.Email;

                string updateRole = userDto.RoleNameAssignment;
                
                if (updateRole != roleName)
                {
                    bool searchRoleName = await _roleManager.RoleExistsAsync(updateRole);
                    if (!searchRoleName)
                    {
                        throw new Exception($"Role '{updateRole}' does not exist.");
                    }

                    var userRoles = await _userManager.GetRolesAsync(user);
                    await _userManager.RemoveFromRolesAsync(user, userRoles);

                    await _userManager.AddToRoleAsync(user, updateRole);
                }
                
                await _userManager.UpdateAsync(user);
            }
            catch (Exception ex)
            {
                throw new Exception("EditUserAsync unsuccessful. Error: " + ex.Message);
            }
        }

        public async Task DeleteUserAsync(string id)
        {
            try
            {
                
                var user = await _userManager.FindByIdAsync(id);
                if (user == null)
                {
                    throw new InvalidOperationException("User not found!..");
                }
                await _userManager.DeleteAsync(user);
            }
            catch(Exception ex)
            {
                throw new Exception($"DeleteUserAsync unsuccessful. Error: {ex.Message}");
            }
        }

        public async Task<List<RolesNameDTO>> GetRolesAsync()
        {
            try
            {
                var r = await _roleManager.Roles.ToListAsync();
                List<RolesNameDTO> rolesDto = _mapper.Map<List<RolesNameDTO>>(r);
                return rolesDto;
            }
            catch (Exception ex)
            {
                throw new Exception($"GetRolesAsync unsuccessful. Error: {ex.Message}");
            }
        }
        
        private static bool IsValidPassword(string password)
        {
            string pattern = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{7,}$";
            Regex regex = new Regex(pattern);

            return regex.IsMatch(password);
        }
    }
}
