using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Smartdrive.DTO.Customer_Request;
using Smartdrive.Extension;
using Smartdrive.Models;
using Smartdrive.Repositories.Customer_Request;
using System.Net;

namespace Smartdrive.Services.Customer_Request
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

        public async Task<ServiceResponse<CustomerRequestDto>> CreateCustomerRequest(AddCustomerRequestDto newRequest)
        {
            var serviceResponse = new ServiceResponse<CustomerRequestDto>();

            var result = _mapper.Map<CustomerRequest>(newRequest);
            var custRequest = await _repository.Add(result);
            serviceResponse.Data = _mapper.Map<CustomerRequestDto>(custRequest);

            return serviceResponse;
        }

        public async Task<ServiceResponse<CustomerRequestDto>> DeleteCustomerRequest(int id)
        {
            var serviceResponse = new ServiceResponse<CustomerRequestDto>();

            try
            {
                var custRequest = await _repository.Delete(id);

                serviceResponse.Data = _mapper.Map<CustomerRequestDto>(custRequest);
            }
            catch (Exception)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = $"Character with id '{id}' is not found.";
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<CustomerRequestDto>>> GetAllCustomerRequest()
        {
            var serviceResponse = new ServiceResponse<List<CustomerRequestDto>>();
            var custRequest = await _repository.GetAll();
            serviceResponse.Data = custRequest.Select(c => _mapper.Map<CustomerRequestDto>(c)).ToList();

            return serviceResponse;
        }

        public async Task<ServiceResponse<CustomerRequestDto>> GetCustomerRequestById(int id)
        {
            var serviceResponse = new ServiceResponse<CustomerRequestDto>();

            try
            {
                var custRequest = await _repository.GetById(id);
                if (custRequest is null)
                    throw new Exception($"Character with id '{id}' is not found.");

                serviceResponse.Data = _mapper.Map<CustomerRequestDto>(custRequest);
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<CustomerRequestDto>> UpdateCustomerRequest(UpdateCustomerRequestDto updatedRequest)
        {
            var serviceResponse = new ServiceResponse<CustomerRequestDto>();

            try
            {
                var custRequest = await _repository.GetById(updatedRequest.CreqEntityid);
                if (custRequest is null)
                    throw new Exception($"Character with id '{updatedRequest.CreqEntityid}' is not found.");

                _mapper.Map<UpdateCustomerRequestDto>(custRequest);

                custRequest.CreqEntityid = updatedRequest.CreqEntityid;
                custRequest.CreqCreateDate = updatedRequest.CreqCreateDate;
                custRequest.CreqStatus = updatedRequest.CreqStatus;
                custRequest.CreqType = updatedRequest.CreqType;
                custRequest.CreqModifiedDate = updatedRequest.CreqModifiedDate;
                custRequest.CreqCustEntityid = updatedRequest.CreqCustEntityid;
                custRequest.CreqAgenEntityid = updatedRequest.CreqAgenEntityid;

                var result = await _repository.Edit(custRequest);

                serviceResponse.Data = _mapper.Map<CustomerRequestDto>(result);
            }
            catch(Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }
            
            return serviceResponse;
        }
    }
}
