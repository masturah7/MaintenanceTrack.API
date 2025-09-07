using MaintenanceTrack.API.Data;
using MaintenanceTrack.API.DTO;
using MaintenanceTrack.API.Interface;
using Microsoft.AspNetCore.Identity;

namespace MaintenanceTrack.API.Repository
{
    public class AuthManager : IAuthManager
    {
        private readonly UserManager<APIUser> userManager;
        public AuthManager(UserManager<APIUser> _userManager)
        {
            userManager = _userManager; 
        }

        public async Task<bool> Login(LoginDto loginDto)
        {
            bool isValidUser = false;

            try
            {
                var userExit = await userManager.FindByEmailAsync(loginDto.Email);

                isValidUser = await userManager.CheckPasswordAsync(userExit, loginDto.Password);

               

            }
            catch (Exception)
            {
                throw;
            }

            return isValidUser; 


        }

        public async Task<IEnumerable<IdentityError>> Register(APIUserDto userDto)
        {
            var user = new APIUser()
            {
                FirstName = userDto.Firstname,
                LastName = userDto.Lastname,
                Email = userDto.Email,  
                PasswordHash = userDto.Password,  
                UserName = userDto.Email,
            };

            var result = await userManager.CreateAsync(user,userDto.Password);

            if (result.Succeeded)
            {
                return Array.Empty<IdentityError>();
            }

            return result.Errors;
        }
    }
}
