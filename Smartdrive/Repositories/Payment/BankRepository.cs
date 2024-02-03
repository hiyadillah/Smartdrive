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
            throw new NotImplementedException();
        }

    }

    public class FintechRepository : IRepository<Fintech>
    {
        private readonly SmartdriveContext _context;

        public FintechRepository(SmartdriveContext context)
        {
            _context = context;
        }

        public IEnumerable<Fintech> FindAll()
        {
            return _context.Finteches;

        }

        public Fintech FindById(dynamic id)
        {
            throw new NotImplementedException();
        }
    }
}
