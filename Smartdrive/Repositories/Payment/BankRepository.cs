using Smartdrive.Db;
using Smartdrive.DTO.Payment;
using Smartdrive.Models;

namespace Smartdrive.Repositories.Payment
{
    public class BankRepository : IRepository<Bank>, IBankRepo
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

        public void Create(BankResponse bankResponse)
        {
            using var db = new SmartdriveContext();
            BusinessEntity business = new()
            {
                EntityModifiedDate = DateTime.Now,
            };
            db.BusinessEntities.Add(business);
            db.SaveChanges();
            Bank bank = new()
            {
                BankEntityid = business.Entityid,
                BankName = bankResponse.bankName,
                BankDesc = bankResponse.bankDesc
            };
            db.Banks.Add(bank);
            db.SaveChanges();
        }

        public void Update(BankResponse bankResponse)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            using var db = new SmartdriveContext();
            var businessEntities = db.BusinessEntities.Where(x => x.Entityid == id).FirstOrDefault();
            var bank = db.Banks.Where(x => x.BankEntityid == id).FirstOrDefault();

            db.Remove(bank);
            db.SaveChanges();

            db.Remove(businessEntities);
            db.SaveChanges();
        }
    }
}
