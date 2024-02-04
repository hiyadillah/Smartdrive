using Smartdrive.DTO.Customer_Request;
using Smartdrive.Extension;

namespace Smartdrive.Services.CustomerRequest
{
    public interface ICustomerRequestService
    {
        Task<ServiceResponse<List<CustomerRequestDto>>> GetAllCustomerRequest();
    }
}
