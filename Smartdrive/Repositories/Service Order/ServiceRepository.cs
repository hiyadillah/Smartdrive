using AutoMapper;
using Smartdrive.Db;
using Smartdrive.DTO.Service_Order;
using Smartdrive.Models;

namespace Smartdrive.Repositories.Service_Order
{
    public class ServiceRepository : IRepository<Service>
    {
        private readonly SmartdriveContext _context;
        private readonly Mapper _mapper;

        public ServiceRepository(SmartdriveContext context, Mapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public IEnumerable<Service>? FindAll()
        {
            return _context.Services;
        }

        public Service? FindById(dynamic id)
        {
            var newId = (int)id;
            Service? item = _context.Services.Where(x => x.ServId == newId).FirstOrDefault();
            return item;
        }
        public int Create(ServiceDto serviceDto)
        {
            Service service= _mapper.Map<Service>(serviceDto);
            
            // do saving through _context
            _context.Services.Add(service);
            var res=_context.SaveChanges();
            return res;
        }
        public int Update(dynamic id, ServiceDto serviceDto)
        {
            // search corresponding id
            Service? service = FindById(id);
            if (service == null)
                Console.WriteLine("Id is Null");

            // convert from dto to entity
            Service newItem = _mapper.Map<Service>(serviceDto);
            
            // update through context
            _context.Services.Update(newItem);
            var res= _context.SaveChanges();
            return res;
        }
    }
}
