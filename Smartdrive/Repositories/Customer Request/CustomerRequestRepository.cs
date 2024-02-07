using Microsoft.EntityFrameworkCore;
using Smartdrive.Db;
using Smartdrive.Models;
using Smartdrive.Repositories.Customer_Request.Contract;

namespace Smartdrive.Repositories.Customer_Request
{
	public class CustomerRequestRepository : ICustomerRequestRepository
	{
		private readonly SmartdriveContext _context;

		public CustomerRequestRepository(SmartdriveContext context)
		{
			_context = context;
		}

		public async Task<CustomerRequest> get(int id)
		{
			var result = await _context.CustomerRequests
				.Where(creq => creq.CreqEntityid == id)
				.Include(creq => creq.CreqCustEntity)
				.Include(creq => creq.CreqAgenEntity)
				.FirstOrDefaultAsync();

			return result;
		}

		public async Task<List<CustomerRequest>> getAll(int id, string code)
		{
			var result = await _context.CustomerRequests
				.Where(creq => creq.CreqCustEntityid == id)
				.Where(creq => creq.CreqAgenEntity.EawgArwgCode == code)
				.Include(creq => creq.CreqCustEntity)
				.Include(creq => creq.CreqAgenEntity)
				.ToListAsync();

			return result;
		}
	}
}

