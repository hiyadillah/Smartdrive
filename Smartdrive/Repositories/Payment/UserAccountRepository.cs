using Smartdrive.Db;
using Smartdrive.Models;

namespace Smartdrive.Repositories.Payment
{
    public class UserAccountRepository : IRepository<UserAccount>
    {
        private readonly SmartdriveContext _context;

        public UserAccountRepository(SmartdriveContext context)
        {
            _context = context;
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
    }
}
