
using Microsoft.EntityFrameworkCore;
using Smartdrive.Db;
using Smartdrive.Extension;
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

        public async Task<CustomerRequest> Add(CustomerRequest newRequest)
        {
            BusinessEntity business = new()
            {
                EntityModifiedDate = DateTime.Now,
            };
            _context.BusinessEntities.Add(business);
            await _context.SaveChangesAsync();
            newRequest.CreqEntityid = business.Entityid;

            _context.CustomerRequests.Add(newRequest);
            await _context.SaveChangesAsync();

            return newRequest;
        }

        public async Task<CustomerRequest> Delete(int id)
        {
            var custReq = await _context.CustomerRequests.FirstOrDefaultAsync(c => c.CreqEntityid == id);
            _context.CustomerRequests.Remove(custReq);

            await _context.SaveChangesAsync();
            return custReq;
        }

        public async Task<CustomerRequest> Edit(CustomerRequest updatedRequest)
        {
            _context.Update(updatedRequest);
            await _context.SaveChangesAsync();

            return updatedRequest;

        }

        public async Task<List<CustomerRequest>> GetAll()
        {
            return await _context.CustomerRequests.ToListAsync();
        }

        public async Task<CustomerRequest> GetById(int id)
        {
            return await _context.CustomerRequests.FirstOrDefaultAsync(c => c.CreqEntityid == id);
        }
    }
}
