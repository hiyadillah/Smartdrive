
using Microsoft.EntityFrameworkCore;
using Smartdrive.Db;
using Smartdrive.Models;

namespace Smartdrive.Repositories.Customer_Request
{
    public class CustomerRequestRepository : ICustomerRequestRepository
    {
        private readonly SmartdriveContext _context;

        public CustomerRequestRepository(SmartdriveContext context)
        {
            _context = context;
        }
        public async Task<List<CustomerRequest>> GetAll()
        {
            return await _context.CustomerRequests.ToListAsync();
        }
    }
}
