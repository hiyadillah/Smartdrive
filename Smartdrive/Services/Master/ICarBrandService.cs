using Smartdrive.DTO.Master;
using Smartdrive.Models;

namespace Smartdrive.Services.Master
{
    public interface ICarBrandService
    {
        List<CarBrandResponse> FindAll();
    }
}
