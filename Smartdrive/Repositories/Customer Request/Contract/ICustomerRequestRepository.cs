using Smartdrive.Models;

namespace Smartdrive.Repositories.Customer_Request.Contract
{
	public interface ICustomerRequestRepository
	{
		Task<List<CustomerRequest>> getAll(int id, string code);
		Task<CustomerRequest> get(int id);
	}
}
