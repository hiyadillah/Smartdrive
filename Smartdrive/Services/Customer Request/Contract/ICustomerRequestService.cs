using Smartdrive.DTO.Customer_Request.Response;
using Smartdrive.Repositories.Customer_Request.Contract;

namespace Smartdrive.Services.Customer_Request.Contract
{
	public interface ICustomerRequestService
	{
		Task<CustomerReqResponse> Get(int id);
		Task<List<CustomerReqResponse>> GetAll(int id, string code);
	}
}
