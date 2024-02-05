using Smartdrive.Extension;
using Smartdrive.Models;

namespace Smartdrive.Repositories.Customer_Request
{
    public interface ICustomerRequestRepository
    {
        Task<List<CustomerRequest>> GetAll();
        Task<CustomerRequest> GetById(int id);
        Task<CustomerRequest> Add(CustomerRequest newRequest);
        Task<CustomerRequest> Edit(CustomerRequest updatedRequest);
        Task<CustomerRequest> Delete(int id);
    }
}
