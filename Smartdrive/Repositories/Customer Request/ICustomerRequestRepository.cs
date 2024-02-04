using Smartdrive.Models;

namespace Smartdrive.Repositories.Customer_Request
{
    public interface ICustomerRequestRepository
    {
        Task<List<CustomerRequest>> GetAll();
    }
}
