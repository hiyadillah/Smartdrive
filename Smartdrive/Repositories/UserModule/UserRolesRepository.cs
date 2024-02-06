using Smartdrive.Db;
using Smartdrive.Models;

namespace Smartdrive.Repositories.UserModule
{
    public class UserRolesRepository : IUserRolesRepository
    {
        private readonly SmartdriveContext _context;
        public UserRolesRepository(SmartdriveContext context)
        {
            _context = context;
        }

        public UserRole AddUserRole(User user, string role)
        {
            var assignRole = new UserRole()
            {
                UsroEntity = user,
                UsroRoleName = role,
                UsroStatus = "ACTIVE",
                UsroModifiedDate = DateTime.Now,
            };

            _context.Add(assignRole);
            _context.SaveChanges();

            return assignRole;
        }

        public List<UserRole> GetUserRoles(int userId)
        {
            var roles = _context.UserRoles.Where(x => x.UsroEntityid == userId).ToList();

            return roles;
        }
    }
}
