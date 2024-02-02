using AutoMapper;
using Smartdrive.DTO.Service_Order;
using Smartdrive.Models;

namespace Smartdrive.Extension
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Service, ServiceDto>().ReverseMap();
        }
    }
}
