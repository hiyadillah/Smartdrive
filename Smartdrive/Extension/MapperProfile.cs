using AutoMapper;
using Smartdrive.DTO.Customer_Request;
using Smartdrive.DTO.Customer_Request.Response;
using Smartdrive.DTO.Service_Order;
using Smartdrive.Models;

namespace Smartdrive.Extension
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Service, ServiceDto>().ReverseMap();
            CreateMap<CustomerRequest, CustomerReqResponse>().ReverseMap();
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<EmployeeAreWorkgroup, EmployeeAreaWorkgroupDto>().ReverseMap();
        }
    }
}
