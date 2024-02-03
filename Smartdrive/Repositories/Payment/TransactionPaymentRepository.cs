using Smartdrive.Db;
using Smartdrive.Models;

namespace Smartdrive.Repositories.Payment
{
    class TransactionPaymentRepository : IRepository<PaymentTransaction>
    {
        private readonly SmartdriveContext _context;

        public TransactionPaymentRepository(SmartdriveContext context)
        {
            _context = context;
        }

        public IEnumerable<PaymentTransaction> FindAll()
        {
            return _context.PaymentTransactions;
        }

        public PaymentTransaction FindById(dynamic id)
        {
            throw new NotImplementedException();
        }
    }
}
