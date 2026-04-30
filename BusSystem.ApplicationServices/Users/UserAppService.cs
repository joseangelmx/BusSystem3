using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using AutoMapper;
using BusSystem.ApplicationServices.Shared.DTO.Users;
using BusSystem.Core.Users;
using BusSystem.DataAccess;
using BusSystem.DataAccess.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace BusSystem.ApplicationServices.Users;

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
                        Gender = user.Gender,
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
                ApplicationUser user = await _userManager.Users.Where(x => x.Id == id).FirstOrDefaultAsync();
                var roleName = (await _userManager.GetRolesAsync(user)).FirstOrDefault();
                //UserDto userDto = _mapper.Map<UserDto>(user);
                var userDto = new UserDTO
                {
                    Id = user.Id,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    DateOfBirth = user.DateOfBirth,
                    Gender = user.Gender,
                    PhoneNumber = user.PhoneNumber,
                    Email = user.Email,
                    Role = roleName
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
            try
            {
                
                var existingUserByEmail = await _userManager.FindByEmailAsync(userDto.Email);
                if (existingUserByEmail != null)
                {
                    throw new InvalidOperationException("Email already exists!.");
                }

                if (!userDto.Email.Contains("@") || !userDto.Email.Contains(".com"))
                {
                    throw new InvalidOperationException("Email is invalid!. correct are: user@example.com ");
                }

                if (userDto.PhoneNumber.Length != 10 || !userDto.PhoneNumber.All(char.IsDigit))
                {
                    throw new InvalidOperationException("Phone Number is invalid!. The phone number must be in 10 digit format.");
                }

                if (!IsValidPassword(userDto.Password))
                {
                    throw new InvalidOperationException("Password is invalid!. The password minimum length 7, must contain letters, numbers, and special character");
                }

                var u = _mapper.Map<ApplicationUser>(userDto);
                var result = await _userManager.CreateAsync(u, userDto.Password);
                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(u, userDto.RoleNameAssignment);
                }
            }
            catch(Exception ex)
            {
                throw new Exception($"AddUserAsync unsuccessful. Error: {ex.Message}");
            }
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

                if (userDto.UserName != user.UserName)
                {
                    var existingUserByUsername = await _userManager.FindByNameAsync(userDto.UserName);

                    if (existingUserByUsername != null)
                    {
                        throw new InvalidOperationException("Username is already exist!.");
                    }
                }

                if (userDto.PhoneNumber.Length != 10 || !userDto.PhoneNumber.All(char.IsDigit))
                {
                    throw new InvalidOperationException("Phone Number is invalid!. The phone number must be in 10 digit format.");
                }

                user.PhoneNumber = userDto.PhoneNumber;
                user.UserName = userDto.UserName;

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

                UserStore<IdentityUser> store = new UserStore<IdentityUser>(_context);
                if (store == null)
                {
                    throw new InvalidOperationException("The entity was not saved, the fileds are required");
                }
                await store.UpdateAsync(user);
            }
            catch (Exception ex)
            {
                throw;
            }
            
        }

        public async Task DeleteUserAsync(string id)
        {
            try
            {
                var user = await _userManager.FindByIdAsync(id);

                UserStore<IdentityUser> store = new UserStore<IdentityUser>(_context);
                await store.DeleteAsync(user);
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
                throw new Exception($"ERROR GetRolesAsync IN UserAppService SERVICE {ex.Message}");
            }
        }

        private static bool IsValidPassword(string password)
        {
            string pattern = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{7,}$";
            Regex regex = new Regex(pattern);

            return regex.IsMatch(password);
        }
}