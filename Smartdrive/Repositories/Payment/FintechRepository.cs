using Smartdrive.Db;
using Smartdrive.DTO.Payment;
using Smartdrive.Models;

namespace Smartdrive.Repositories.Payment
{
    public class FintechRepository : IRepository<Fintech>, IFintechRepo
    {
        private readonly SmartdriveContext _context;

        public FintechRepository(SmartdriveContext context)
        {
            _context = context;
        }

        public void Create(FintechResponse fintechResponse)
        {
            using var db = new SmartdriveContext();
            BusinessEntity business = new()
            {
                EntityModifiedDate = DateTime.Now,
            };
            db.BusinessEntities.Add(business);
            db.SaveChanges();
            Fintech fintech = new()
            {
                FintEntityid = business.Entityid,
                FintName = fintechResponse.fintName,
                FintDesc = fintechResponse.fintDesc
            };

            db.Finteches.Add(fintech);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            using var db = new SmartdriveContext();
            var businessEntities = db.BusinessEntities.Where(x => x.Entityid == id).FirstOrDefault();
            var fintech = db.Finteches.Where(x => x.FintEntityid == id).FirstOrDefault();

            db.Remove(fintech);
            db.SaveChanges();

            db.Remove(businessEntities);
            db.SaveChanges();
        }

        public IEnumerable<Fintech> FindAll()
        {
            return _context.Finteches;

        }

        public Fintech FindById(dynamic id)
        {
            using var db = new SmartdriveContext();
            int idToInt = id;
            Fintech data = db.Finteches.Where(x => x.FintEntityid == idToInt).FirstOrDefault();

            return data;
        }

        public void Update(int id, FintechResponse fintechResponse)
        {
            using var db = new SmartdriveContext();

            Fintech fint = db.Finteches.Where(x => x.FintEntityid == id).FirstOrDefault();
            fint.FintName = fintechResponse.fintName;
            fint.FintDesc = fintechResponse.fintDesc;

            db.SaveChanges();
        }
    }
}
