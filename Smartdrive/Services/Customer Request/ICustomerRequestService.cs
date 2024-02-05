using Smartdrive.DTO.Customer_Request;
using Smartdrive.Extension;

namespace Smartdrive.Services.Customer_Request
{
    public interface ICustomerRequestService
    {
        Task<ServiceResponse<List<CustomerRequestDto>>> GetAllCustomerRequest();
        Task<ServiceResponse<CustomerRequestDto>> GetCustomerRequestById(int id);
        Task<ServiceResponse<CustomerRequestDto>> CreateCustomerRequest(AddCustomerRequestDto newRequest);
        Task<ServiceResponse<CustomerRequestDto>> UpdateCustomerRequest(UpdateCustomerRequestDto updatedRequest);
        Task<ServiceResponse<CustomerRequestDto>> DeleteCustomerRequest(int id);
    }
}
