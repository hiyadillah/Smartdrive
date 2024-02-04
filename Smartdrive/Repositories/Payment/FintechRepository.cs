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
            throw new NotImplementedException();
        }
    }
}
