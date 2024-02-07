using AutoMapper;
using Smartdrive.DTO.Customer_Request.Response;
using Smartdrive.Repositories.Customer_Request.Contract;
using Smartdrive.Services.Customer_Request.Contract;

namespace Smartdrive.Services.Customer_Request
{
	public class CustomerRequestService : ICustomerRequestService
	{
		private readonly ICustomerRequestRepository _customerRequestRepository;
		private readonly IMapper _mapper;

		public CustomerRequestService(ICustomerRequestRepository customerRequestRepository, IMapper mapper)
		{
			_customerRequestRepository = customerRequestRepository;
			_mapper = mapper;
		}

		public async Task<CustomerReqResponse> Get(int id)
		{
			var result = await _customerRequestRepository.get(id);
			var response = _mapper.Map<CustomerReqResponse>(result);
			response.CreqCust = _mapper.Map<UserDto>(result.CreqCustEntity);
			response.CreqAgen = _mapper.Map<EmployeeAreaWorkgroupDto>(result.CreqAgenEntity);

			return response;

		}

		public async Task<List<CustomerReqResponse>> GetAll(int id, string code)
		{
			var result = await _customerRequestRepository.getAll(id, code);
			var response = _mapper.Map<List<CustomerReqResponse>>(result);

			return response;
		}
	}
}
