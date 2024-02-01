using Smartdrive.DTO.Master;
using Smartdrive.Models;
using Smartdrive.Repositories;
using Smartdrive.Repositories.Master;

namespace Smartdrive.Services.Master
{
    public class CarBrandService : ICarBrandService
    {
        private readonly IRepository<CarBrand> _repo;

        public CarBrandService(IRepository<CarBrand> repo)
        {
            _repo = repo;
        }

        List<CarBrandResponse> ICarBrandService.FindAll()
        {
            var data = _repo.FindAll();
            List<CarBrandResponse> response = new();
            foreach (var item in data)
            {
                CarBrandResponse a = new(item.CabrId, item.CabrName);
                response.Add(a);
            }
            return response;
        }
    }
}
