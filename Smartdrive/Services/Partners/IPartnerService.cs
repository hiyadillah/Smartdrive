using Smartdrive.DTO.Partners;
using Smartdrive.Helper;
using Smartdrive.Models;

namespace Smartdrive.Services.Partners
{
    public interface IPartnerService
    {
        Task Create(PartnerRequest req);
        Task Delete(int id);
        Task Update(PartnerRequest request, int id);
        Task<PaginationResponse<PartnerResponse>> Paginate(PaginationRequest request);
        Task<Partner?> IsPartnerExist(int id);
    }
}
