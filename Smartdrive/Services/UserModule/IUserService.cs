using Smartdrive.Common;
using Smartdrive.DTO.UserModule;
using Smartdrive.Models;

namespace Smartdrive.Services.UserModule
{
    public interface IUserService
    {
        List<UserResponse> GetUsers();
        User GetUserById(dynamic id);

        //UserResponse CreateEmployee(UserRequest user);
        UserResponse CreateEmployee(UserRequest user);

        User FindUserByUsername(string username);

        UserRole AssignUserRole(int userId, string userRole);

        List<UserRole> GetUserRoles(int userId);
    }
}
