using Smartdrive.Db;
using Smartdrive.Models;

namespace Smartdrive.Repositories.Payment
{
    public class BankRepository : IRepository<Bank>
    {
        private readonly SmartdriveContext _context;

        public BankRepository(SmartdriveContext context)
        {
            _context = context;
        }

        public IEnumerable<Bank> FindAll()
        {
            //using (var db = new SmartdriveContext())
            //{
            //    IEnumerator<UserAccount> item = db.UserAccounts.ToList().GetEnumerator();
            //    while (item.MoveNext())
            //    {
            //        yield return item.Current;
            //    }
            //};
            return _context.Banks;

        }

        public Bank FindById(dynamic id)
        {
            using var db = new SmartdriveContext();
            int idToInt = id;
            Bank data = db.Banks.Where(x => x.BankEntityid == idToInt).FirstOrDefault();

            return data;
        }

    }
}
