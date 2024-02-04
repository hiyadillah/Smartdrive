using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Smartdrive.DTO.Customer_Request;
using Smartdrive.Extension;
using Smartdrive.Repositories.Customer_Request;

namespace Smartdrive.Services.CustomerRequest
{
    public class CustomerRequestService : ICustomerRequestService
    {
        private readonly CustomerRequestRepository _repository;
        private readonly IMapper _mapper;

        public CustomerRequestService(CustomerRequestRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<ServiceResponse<List<CustomerRequestDto>>> GetAllCustomerRequest()
        {
            var serviceResponse = new ServiceResponse<List<CustomerRequestDto>>();
            var custRequest = await _repository.GetAll();
            serviceResponse.Data = custRequest.Select(c => _mapper.Map<CustomerRequestDto>(c)).ToList();

            return serviceResponse;
        }
    }
}
