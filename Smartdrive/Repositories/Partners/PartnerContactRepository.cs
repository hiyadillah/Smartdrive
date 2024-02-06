using Smartdrive.Db;
using Smartdrive.DTO.Partners;
using Smartdrive.Models;

namespace Smartdrive.Repositories.Partners
{
    public class PartnerContactRepository : IPartnertContactRepository
    {
        private readonly SmartdriveContext _context;

        public PartnerContactRepository(SmartdriveContext context)
        {
            _context = context;
        }

        public async Task Create(PartnertContactRequest request)
        {
            using var transaction = await _context.Database.BeginTransactionAsync();
            try
            {
                BusinessEntity entity = new()
                {
                    EntityModifiedDate = DateTime.Now,
                };
                await _context.BusinessEntities.AddAsync(entity);
                await _context.SaveChangesAsync();
                var userPassword = request.IsGrantedUser ? BCrypt.Net.BCrypt.HashPassword(request.PhoneNumber) : null;
                var username = request.IsGrantedUser ? request.PhoneNumber : null;
                User user = new()
                {
                    UserEntityid = entity.Entityid,
                    UserFullName = request.ContactName,
                    UserEmail = request.PhoneNumber,
                    UserPassword = userPassword,
                    UserNationalId = Guid.NewGuid().ToString().Substring(0, 20),
                    UserNpwp = request.PhoneNumber,
                    UserName = username
                };
                await _context.Users.AddAsync(user);
                await _context.SaveChangesAsync();
                UserPhone phone = new()
                {
                    UsphEntityid = entity.Entityid,
                    UsphPhoneNumber = request.PhoneNumber,
                    UsphStatus = nameof(PartnerStatus.ACTIVE) 
                };
                await _context.UserPhones.AddAsync(phone);
                await _context.SaveChangesAsync();
                if (request.IsGrantedUser is true)
                {
                    UserRole role = new()
                    {
                        UsroEntityid = entity.Entityid,
                        UsroRoleName = "PR",
                        UsroStatus = nameof(PartnerStatus.ACTIVE)
                    };
                    await _context.UserRoles.AddAsync(role);
                    await _context.SaveChangesAsync();
                }
                PartnerContact contact = new()
                {
                    PacoPatrnEntityid = request.PartnerId,
                    PacoUserEntityid = entity.Entityid,
                    PacoStatus = nameof(PartnerStatus.ACTIVE)
                };
                await _context.PartnerContacts.AddAsync(contact);
                await _context.SaveChangesAsync();
                await transaction.CommitAsync();
            }catch(Exception) {
                await transaction.RollbackAsync();
                throw;
            }
        }

        public async Task Delete(PartnerContact contact)
        {
            BusinessEntity entity = new()
            {
                Entityid = contact.PacoUserEntityid
            };
            User user = new()
            {
                UserEntity = entity,
            };
            UserRole roles = new()
            {
                UsroEntity = user
            };
            var findPhones = _context.UserPhones.Where(x => x.UsphEntityid == entity.Entityid).ToList();
            _context.UserPhones.RemoveRange(findPhones);
            var findRoles = _context.UserRoles.Find(entity.Entityid, "PR");
            if (findRoles is not null)
            {
                _context.UserRoles.Remove(roles);
            }
            _context.Users.Remove(user);
            _context.BusinessEntities.Remove(entity);
            _context.PartnerContacts.Remove(contact);
            await _context.SaveChangesAsync();
        }

        public async Task<PartnerContact?> FindByid(int partnerId, int userId)
        {
            return await _context.PartnerContacts.FindAsync(partnerId, userId);
        }

        public async Task Update(UpdatePartnerContactRequest contact, int userId)
        {
            var transaction = await _context.Database.BeginTransactionAsync();
            try
            {
                var user = _context.Users.Find(userId);
                var userPhone = _context.UserPhones.Find(userId, contact.OldPhone);
                if (userPhone is null) 
                {
                    throw new Exception($"users wiht userId {userId} not found");
                }
                if (userPhone is null)
                {
                    throw new Exception($"userPhone wiht userId {userId} not found");
                }

                if (userPhone.UsphPhoneNumber != contact.NewPhone)
                {
                    _context.UserPhones.Remove(userPhone);
                    await _context.SaveChangesAsync();
                    userPhone.UsphPhoneNumber = contact.NewPhone;
                    _context.UserPhones.Add(userPhone);
                    await _context.SaveChangesAsync();
                }

                if (user!.UserFullName != contact.NewContact)
                {
                    user.UserFullName = contact.NewContact;
                    user.UserNpwp = contact.NewPhone;
                    _context.Users.Update(user);
                    await _context.SaveChangesAsync();
                }
                await transaction.CommitAsync();
            }
            catch (Exception)
            {
                await transaction.RollbackAsync();
                throw;
            }
        }
    }
}
