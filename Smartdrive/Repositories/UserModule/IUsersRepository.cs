using Smartdrive.DTO.UserModule;
using Smartdrive.Models;

namespace Smartdrive.Repositories.UserModule
{
    public interface IUsersRepository
    {
        User CreateEmployee(User user);
        UserResponse CreateCustomer(User user);
        User CreateUser(UserRequest user, BusinessEntity businessEntity);
        IEnumerable<User> FindAll();
        User FindById(dynamic id);

        User FindByUsername(string username);
    }
}
