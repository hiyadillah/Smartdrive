using AutoMapper;
using Smartdrive.Db;
using Smartdrive.DTO.Customer_Request.Response;
using Smartdrive.Repositories.Customer_Request.Contract;
using Smartdrive.Services.Customer_Request.Contract;

namespace Smartdrive.Services.Customer_Request
{
	public class CustomerRequestService : ICustomerRequestService
	{
		private readonly ICustomerRequestRepository _customerRequestRepository;
		private readonly IMapper _mapper;
		private readonly SmartdriveContext _smartdriveContext;

        public CustomerRequestService(ICustomerRequestRepository customerRequestRepository, IMapper mapper, SmartdriveContext smartdriveContext)
        {
            _customerRequestRepository = customerRequestRepository;
            _mapper = mapper;
            _smartdriveContext = smartdriveContext;
        }

        public async Task<CustomerReqResponse> Get(int id)
		{
			var result = await _customerRequestRepository.get(id);
			if (result == null)
				return null;

			var response = _mapper.Map<CustomerReqResponse>(result);
			response.CreqCust = _mapper.Map<UserDto>(result.CreqCustEntity);

			return response;
		}

		public async Task<List<CustomerReqResponse>> GetAllByCustomer(int id)
		{
			var result = await _customerRequestRepository.getAllByCustomer(id);
			if (result == null)
			{
				return null;
			}
			var user = _smartdriveContext.Users.Find(id);
			
			var response = _mapper.Map<List<CustomerReqResponse>>(result);
			
			foreach( var item in response)
			{
				item.CreqCust = _mapper.Map<UserDto>(user);
            }

			return response;
		}

		public async Task<List<CustomerReqResponse>> GetAllByEmployee(string code)
		{
            var result = await _customerRequestRepository.getAllByEmployee(code);
            if (result == null)
            {
                return null;
            }

			var user = _smartdriveContext.Users;

            var response = _mapper.Map<List<CustomerReqResponse>>(result);

			foreach (var item in response)
			{
				item.CreqCust = _mapper.Map<UserDto>(user);
			}

			return response;
        }
	}
}
