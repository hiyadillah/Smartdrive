using Smartdrive.Db;
using Smartdrive.Models;

namespace Smartdrive.Repositories.Master
{
    public class CarBrandRepository : IRepository<CarBrand>
    {
        private readonly SmartdriveContext _context;

        public CarBrandRepository(SmartdriveContext context)
        {
            _context = context;
        }

        public void Create(CarBrand entity)
        {
            using (var db = new SmartdriveContext())
            {

            }
        }

        public void Delete(dynamic id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CarBrand> FindAll()
        {
            //using (var db = new SmartdriveContext())
            //{
            //    IEnumerator<CarBrand> allItem = db.CarBrands.ToList().GetEnumerator();
            //    while (allItem.MoveNext())
            //    {
            //        yield return allItem.Current;
            //    }
            //}
            return _context.CarBrands;
        }

        public CarBrand? FindById(dynamic id)
        {
            using (var db = new SmartdriveContext())
            {
                var newId = (int)id;
                CarBrand? item = db.CarBrands.Where(x=>x.CabrId==newId).FirstOrDefault();
                return item;
            }
        }

        public void Update(dynamic id, CarBrand entity)
        {
            throw new NotImplementedException();
        }
    }
}
