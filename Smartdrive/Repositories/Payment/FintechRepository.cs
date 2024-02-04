using Smartdrive.Db;
using Smartdrive.Models;

namespace Smartdrive.Repositories.Payment
{
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
            using var db = new SmartdriveContext();
            int idToInt = id;
            Fintech data = db.Finteches.Where(x => x.FintEntityid == idToInt).FirstOrDefault();

            return data;
        }
    }
}
