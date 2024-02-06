using Smartdrive.Helper;
using Smartdrive.Models;
namespace Smartdrive.Repositories.Partners
{
    public interface IPartnerRepository
    {
        Task Create(Partner partner);
        Task Update(Partner partner);
        Task Delete(Partner partner);
        Task<Partner?> FindById (int id);
        Task<(List<Partner>, int)> Paginate(PaginationRequest paginationOptions);
    }
}
