using MaintenanceTrack.API.DTO;
using Microsoft.AspNetCore.Identity;

namespace MaintenanceTrack.API.Interface
{
    public interface IAuthManager
    {
        Task<IEnumerable<IdentityError>> Register(APIUserDto userDto);

        Task<bool> Login(LoginDto loginDto);
    }
}
