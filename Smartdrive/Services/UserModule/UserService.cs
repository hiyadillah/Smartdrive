using AutoMapper;
using Azure;
using Smartdrive.Common;
using Smartdrive.DTO.UserModule;
using Smartdrive.Models;
using Smartdrive.Repositories;
using Smartdrive.Repositories.UserModule;

namespace Smartdrive.Services.UserModule
{
    public class UserService : IUserService
    {
        //private readonly IRepository<User> _repo;
        private readonly IUsersRepository _usersRepo;
        private readonly IBusinessEntityRepository _businessEntityRepo;
        private readonly IUserRolesRepository _userRolesRepo;
        private readonly Mapper _mapper;

        public UserService(
            //IRepository<User> repo, 
            IUsersRepository userRepo,
            IBusinessEntityRepository businessEntityRepo, 
            IUserRolesRepository userRolesRepo,
            Mapper mapper
            )
        {
            //_repo = repo;
            _usersRepo = userRepo;
            _businessEntityRepo = businessEntityRepo;
            _userRolesRepo = userRolesRepo;
            _mapper = mapper;
        }

        public UserRole AssignUserRole(int userId, string userRole)
        {
            var user = _usersRepo.FindById( userId );
            var roles = _userRolesRepo.AddUserRole(user, userRole);

            return roles;
        }

        public UserResponse CreateEmployee(UserRequest user)
        {
            //insert businessentity
            var newBusinessEntity = _businessEntityRepo.CreateBusinessEntity();
            //insert user with businessentity
            var newUser = _usersRepo.CreateUser(user, newBusinessEntity);
            //assign user role
            _userRolesRepo.AddUserRole(newUser, UserRoleType.EM);

            UserResponse response = new(
                            newUser.UserEntityid,
                            newUser.UserName,
                            newUser.UserFullName,
                            newUser.UserEmail,
                            newUser.UserBirthPlace,
                            newUser.UserBirthDate,
                            newUser.UserNationalId,
                            newUser.UserNpwp,
                            newUser.UserPhoto,
                            newUser.UserModifiedDate
                        );
            return response;

            //UserResponse response = new(
            //                999,
            //                user.UserName,
            //                user.UserFullName,
            //                user.UserEmail,
            //                user.UserBirthPlace,
            //                user.UserBirthDate,
            //                user.UserNationalId,
            //                user.UserNpwp,
            //                "photo",
            //                DateTime.Now
            //            );
            //return response;
        }

        public User? FindUserByUsername(string username)
        {
            var data = _usersRepo.FindByUsername(username);

            if (data == null) return null;

            //User response = new(
            //                data.UserEntityid,
            //                data.UserName,
            //                data.UserPassword,
            //                data.UserFullName,
            //                data.UserEmail,
            //                data.UserBirthPlace,
            //                data.UserBirthDate,
            //                data.UserNationalId,
            //                data.UserNpwp,
            //                data.UserPhoto,
            //                data.UserModifiedDate
            //            );
            User response = _mapper.Map<User>(data);

            return response;
        }

        public UserResponse? GetUserById(dynamic id)
        {
            var data = _usersRepo.FindById((int)id);

            if (data == null)
            {
                return null;
            }

            UserResponse response = new(
                            data.UserEntityid,
                            data.UserName,
                            data.UserFullName,
                            data.UserEmail,
                            data.UserBirthPlace,
                            data.UserBirthDate,
                            data.UserNationalId,
                            data.UserNpwp,
                            data.UserPhoto,
                            data.UserModifiedDate
                        );
            return response;
        }

        public List<UserRole> GetUserRoles(int userId)
        {
            var userRoles = _userRolesRepo.GetUserRoles(userId);
            return userRoles;
        }

        public List<UserResponse> GetUsers()
        {
            var efUsers = _usersRepo.FindAll();

            List<UserResponse> response = new();

            foreach (var item in efUsers)
            {
                UserResponse data = new(
                        item.UserEntityid,
                        item.UserName,
                        item.UserFullName,
                        item.UserEmail,
                        item.UserBirthPlace,
                        item.UserBirthDate,
                        item.UserNationalId,
                        item.UserNpwp,
                        item.UserPhoto,
                        item.UserModifiedDate
                    );
                response.Add(data);
            }

            return response;
        }
    }
}
