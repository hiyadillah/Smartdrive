using Smartdrive.Db;
using Smartdrive.DTO.Payment;
using Smartdrive.Models;

namespace Smartdrive.Repositories.Payment
{
    public class UserAccountRepository : IRepository<UserAccount>, IUserAccountRepo
    {
        private readonly SmartdriveContext _context;

        public UserAccountRepository(SmartdriveContext context)
        {
            _context = context;
        }

        //UserId is UserEntitiyID from User table
        //it is refer to which id we want to add the account Number
        // because 1 user can add many UserAccount(bank or fintech) account
        public void Create(int userId, UserAccountResponse userAccountResponse)
        {
            using var db = new SmartdriveContext();
            var userData = db.Users.Where(x => x.UserEntityid == userId).FirstOrDefault();
            UserAccount userAccount = new UserAccount()
            {
                UsacUserEntityid = userData.UserEntityid,
                UsacAccountno = userAccountResponse.usacAccountNo,
                UsacDebet = userAccountResponse.usacDebet,
                UsacType = userAccountResponse.usacType
            };

            db.UserAccounts.Add(userAccount);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            using var db = new SmartdriveContext();
            var userAccount = db.UserAccounts.Where(x => x.UsacId == id).FirstOrDefault();

            db.Remove(userAccount);
            db.SaveChanges();
        }

        public IEnumerable<UserAccount> FindAll()
        {
            //using (var db = new SmartdriveContext())
            //{
            //    IEnumerator<UserAccount> item = db.UserAccounts.ToList().GetEnumerator();
            //    while (item.MoveNext())
            //    {
            //        yield return item.Current;
            //    }
            //};
            return _context.UserAccounts;

        }

        public UserAccount FindById(dynamic id)
        {
            using var db = new SmartdriveContext();
            int convertedID = id;
            UserAccount data = db.UserAccounts.Where(d => d.UsacId == convertedID).FirstOrDefault();

            return data;

        }

        public void Update(int usacId, UserAccountResponse userAccountResponse)
        {
            using var db = new SmartdriveContext();
            UserAccount userAccount = db.UserAccounts.Where(x => x.UsacId == usacId).FirstOrDefault();
             
            userAccount.UsacCredit = userAccountResponse.usacCredit;
            userAccount.UsacDebet = userAccountResponse.usacDebet;
            userAccount.UsacType = userAccountResponse.usacType;
            db.SaveChanges();
        }
    }
}
