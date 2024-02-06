using Smartdrive.DTO.UserModule;
using Smartdrive.Models;

namespace Smartdrive.Repositories.UserModule
{
    public interface IUserRolesRepository
    {
        UserRole AddUserRole(User user, string role);

        List<UserRole> GetUserRoles(int userId);
    }
}
