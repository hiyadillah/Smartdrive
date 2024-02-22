using Smartdrive.Models;

namespace Smartdrive.Repositories.Customer_Request.Contract
{
	public interface ICustomerRequestRepository
	{
		Task<List<CustomerRequest>> getAllByCustomer(int id);
		Task<List<CustomerRequest>> getAllByEmployee(string code);
		Task<CustomerRequest> get(int id);
	}
}
