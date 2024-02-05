using AutoMapper;
using Smartdrive.DTO.Customer_Request;
using Smartdrive.DTO.Service_Order;
using Smartdrive.Models;

namespace Smartdrive.Extension
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Service, ServiceDto>().ReverseMap();
            CreateMap<CustomerRequest, CustomerRequestDto>().ReverseMap();
            CreateMap<CustomerRequest, AddCustomerRequestDto>().ReverseMap();
            CreateMap<CustomerRequest, UpdateCustomerRequestDto>().ReverseMap();
        }
    }
}
