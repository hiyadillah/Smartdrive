using Smartdrive.Db;
using Smartdrive.Models;

namespace Smartdrive.Repositories.UserModule
{
    public class BusinessEntityRepository : IBusinessEntityRepository
    {
        private readonly SmartdriveContext _context;
        public BusinessEntityRepository(SmartdriveContext context)
        {
            _context = context;
        }

        public BusinessEntity CreateBusinessEntity()
        {
            BusinessEntity businessEntity = new BusinessEntity() { 
                EntityModifiedDate = DateTime.Now,
            };

            _context.Add(businessEntity);
            _context.SaveChanges();
            
            return businessEntity;
        }
    }
}
