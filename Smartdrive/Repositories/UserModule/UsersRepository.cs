using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Smartdrive.Db;
using Smartdrive.DTO.Service_Order;
using Smartdrive.DTO.UserModule;
using Smartdrive.Models;

namespace Smartdrive.Repositories.UserModule
{
    //public class UsersRepository : IRepository<User>, IUsersRepository
    public class UsersRepository :  IUsersRepository
    {
        private readonly SmartdriveContext _context;
        private readonly Mapper _mapper;


        public UsersRepository(SmartdriveContext context, Mapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public UserResponse CreateCustomer(User user)
        {
            throw new NotImplementedException();
        }

        public User CreateEmployee(User user)
        {
            throw new NotImplementedException();

            //create businessentity
            //BusinessEntity businessEntity = new BusinessEntity();
            //_context.Add(businessEntity);

            ////create user
            //string hashedPassword = BCrypt.Net.BCrypt.HashPassword(user.UserPassword);

            //User newUser = new User()
            //{
            //    UserEntityid = businessEntity.Entityid,
            //    UserName = user.UserName,
            //    UserPassword = hashedPassword,
            //    UserFullName = user.UserFullName,
            //    UserEmail = user.UserEmail,
            //    UserBirthPlace = user.UserBirthPlace,
            //    UserBirthDate = user.UserBirthDate,
            //    UserNationalId = user.UserNationalId,
            //    UserNpwp = user.UserNpwp
            //};

            //_context.Add(newUser);

            //UserRole role = new UserRole()
            //{
            //    UsroEntityid = newUser.UserEntityid,
            //    UsroRoleName = "EM",
            //    UsroStatus = "ACTIVE"
            //};

            //_context.Add(role);

            //_context.SaveChanges();

            //return newUser;
        }

        public User CreateUser(UserRequest user, BusinessEntity businessEntity)
        {

            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(user.UserPassword);

            User newUser = new User()
            {
                UserEntityid = businessEntity.Entityid,
                UserName = user.UserName,
                UserPassword = hashedPassword,
                UserFullName = user.UserFullName,
                UserEmail = user.UserEmail,
                UserBirthPlace = user.UserBirthPlace,
                UserBirthDate = user.UserBirthDate,
                UserNationalId = user.UserNationalId,
                UserNpwp = user.UserNpwp,
                UserModifiedDate = DateTime.Now
            };

            _context.Add(newUser);
            _context.SaveChanges();

            return newUser;
        }

        public IEnumerable<User> FindAll()
        {
            return _context.Users;
        }

        public User? FindByUsername(string username)
        {
            User item = _context.Users.Where(x => x.UserName == username).FirstOrDefault();
            //User item = _context.Users.Include(x => x.UserRoles).ToList();
            //if (item == null)
            //    return null;

            return item;
        }

        public User? FindById(dynamic id)
        {
            var newId = (int)id;
            User? item = _context.Users.Where(x => x.UserEntityid == newId).FirstOrDefault();
            return item;
        }
    }
}
